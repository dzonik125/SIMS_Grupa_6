using Model;
using Repository;
using Service;
using SIMS.Model;
using SIMS.Repository;
using System.Collections.Generic;

namespace SIMS.Service
{
    public class RoomEquipmentService
    {
        private RoomEquipmentRepository rer = new RoomEquipmentRepository();
        private RoomRepository rr = new RoomRepository();
        private RoomService _roomService = new RoomService();
        public void setRoomEquipment(int id, List<Equipment> equipmentlist)
        {
            rer.setRoomEquipment(id, equipmentlist);
        }

        public List<RoomEquipment> FindAll()
        {
            return rer.FindAll();
        }

        public int getQuantityByRoomId(int id, int roomId)
        {
            return rer.GetQuantityByRoomId(id, roomId);
        }

        public void UpdateRoomEquipment(RoomEquipment roomEquipment)
        {
            foreach (RoomEquipment re in FindAll())
            {
                IncreaseQuantityAndUpdate(roomEquipment, re);
            }

        }

        private void IncreaseQuantityAndUpdate(RoomEquipment roomEquipment, RoomEquipment re)
        {
            if (re.equipmentId == roomEquipment.equipmentId && re.roomId == roomEquipment.roomId)
            {
                re.quantity += roomEquipment.quantity;
                rer.Update(re);
            }
        }

        public List<Equipment> GetRoomEquipment(List<Equipment> allInventory, int roomId)
        {
            FindAllEquipmentInRoom(allInventory,roomId);
            return  GetRoomInventory(allInventory, roomId);;
        }

        private static List<Equipment> GetRoomInventory(List<Equipment> allInventory, int roomId)
        {
            List<Equipment> roomInventory = new List<Equipment>();
            foreach (Equipment e in allInventory)
            {
                if (e.roomNum != null)
                {
                    foreach (int rn in e.roomNum)
                    {
                        if (rn == roomId)
                        {
                            roomInventory.Add(e);
                        }
                    }
                }
            }

            return roomInventory;
        }

        private void FindAllEquipmentInRoom(List<Equipment> allInventory, int roomId)
        {
            foreach (Equipment e in allInventory)
            {
                e.roomNum = new List<int>();
                foreach (RoomEquipment re in FindAll())
                {
                    if (e.id == re.equipmentId)
                    {
                        e.roomNum.Add(re.roomId);
                        e.quantity = getQuantityByRoomId(e.id, roomId);
                    }
                }
            }
        }

        public void ExecuteEquipmentMovingToWarehouse(int storageId, List<RoomEquipment> roomEquipment)
        {
            foreach(RoomEquipment re in roomEquipment)
            {
                FindEquipmentInWarehouse(re, storageId);
            }
        }

        public void CreateRoomEquipment(RoomEquipment roomEquipment)
        {
            rer.Create(roomEquipment);
        }

        public void TransferEquipment( EquipmentTransfer equipmentTransfer)
        {
            List<RoomEquipment> roomEquipment = new List<RoomEquipment>();
            foreach (Room r in rr.FindAll())
            {
                FindRoomDestinationAndUpdateInventory( r, equipmentTransfer);
                FinRoomSourceAndUpdateInventory(r,equipmentTransfer);
            }
        }

        private void FinRoomSourceAndUpdateInventory( Room r, EquipmentTransfer equipmentTransfer)
        {
            Room roomSource = _roomService.FindRoomById(equipmentTransfer.roomSourceId);
            if (r.floor == roomSource.floor && r.roomNum == roomSource.roomNum)
            {
                RoomEquipment roomEq = new RoomEquipment();
                roomEq.roomId = r.id;
                roomEq.equipmentId = equipmentTransfer.equipmentId;
                UpdateRoomSourceEquipmentAfterTransfer(equipmentTransfer.quantity, roomEq);
            }
        }

        private void FindRoomDestinationAndUpdateInventory( Room r, EquipmentTransfer equipmentTransfer)
        {
            Room roomDestination = _roomService.FindRoomById(equipmentTransfer.roomDestiantionId);
            if (r.floor == roomDestination.floor && r.roomNum == roomDestination.roomNum)
            {
                UpdateOrCreateEquipmentInRoomDestinationAfterTrasnfer( r, equipmentTransfer);
            }
        }

        private void UpdateOrCreateEquipmentInRoomDestinationAfterTrasnfer(Room r, EquipmentTransfer equipmentTransfer)
        {
            RoomEquipment roomEq = new RoomEquipment();
            roomEq.roomId = r.id;
            roomEq.equipmentId = equipmentTransfer.equipmentId;
            if (rer.Exists(roomEq))
            {
                UpdateRoomInvetoryAfterTrasnfer(equipmentTransfer.quantity, roomEq);
            }
            else
            {
                roomEq.quantity = equipmentTransfer.quantity;
                rer.Create(roomEq);
            }
        }

        private void UpdateRoomSourceEquipmentAfterTransfer(int quantity, RoomEquipment roomEq)
        {
            foreach (RoomEquipment re in rer.FindAll())
            {
                if (re.roomId == roomEq.roomId && re.equipmentId == roomEq.equipmentId)
                {
                    RemoveEquipmentAfterTransfer(quantity, re);
                    break;
                }
            }
        }

        private void RemoveEquipmentAfterTransfer(int quantity, RoomEquipment re)
        {
            int sum = re.quantity - quantity;
            re.quantity = sum;
            rer.Update(re);
            if (re.quantity == 0)
            {
                rer.DeleteEntity(re);
            }
        }

        private void UpdateRoomInvetoryAfterTrasnfer(int quantity,  RoomEquipment roomEq)
        {
            foreach (RoomEquipment re in rer.FindAll())
            {
                if (re.roomId == roomEq.roomId && re.equipmentId == roomEq.equipmentId)
                {
                    re.quantity += quantity;
                    rer.Update(re);
                    break;
                }
            }
        }

        public void MoveEquipmentToWarehouse(int roomId1, int roomId2)
        {
            int storageId = _roomService.GetRoomIdByStorage(RoomType.storage);
            foreach(RoomEquipment re in FindAll())
            {
                if(re.roomId == roomId1 || re.roomId == roomId2)
                {
                    FindEquipmentInWarehouse(re, storageId);
                }
            }
        }

        public void FindEquipmentInWarehouse(RoomEquipment roomInventory, int storageId)
        {
            RoomEquipment storageEquipment = new RoomEquipment();
            storageEquipment.roomId = storageId;
            storageEquipment.equipmentId = roomInventory.equipmentId;
            storageEquipment.quantity = roomInventory.quantity;
            CreateOrUpdateRoomEquipmentInStorage(storageEquipment);
            DeleteRoomEquipment(roomInventory);
        }

        private void CreateOrUpdateRoomEquipmentInStorage( RoomEquipment storageEquipment)
        {
            if (RoomEquipmentExsist(storageEquipment))
            {
                UpdateRoomEquipment(storageEquipment);
            }
            else
            {
                CreateRoomEquipment(storageEquipment);
            }
        }

        public void DeleteRoomEquipment(RoomEquipment roomEquipment)
        {
            rer.DeleteEntity(roomEquipment);
        }

        public bool RoomEquipmentExsist(RoomEquipment roomInventory)
        {
            bool exists = false;
            foreach (RoomEquipment re in FindAll())
            {
               if(re.equipmentId == roomInventory.equipmentId && re.roomId == roomInventory.roomId)
               {
                    exists = true; 
               }
            }
            return exists;
        }
        public void DeleteEquipmentFromRoomByEquipmentId(int id)
        {
            foreach (RoomEquipment re in FindAll())
            {
                if (re.equipmentId == id)
                {
                    rer.DeleteEntity(re);
                }
            }
        }

        public List<RoomEquipment> GetEquipmentByRoom(Room room)
        {
            List<RoomEquipment> roomEquipmentInRoom = new List<RoomEquipment>();
            foreach (RoomEquipment re in FindAll())
            {
                if(re.roomId == room.id)
                {
                    roomEquipmentInRoom.Add(re);
                }
            }
            return roomEquipmentInRoom;
        }
    }
}
