using Model;
using Repository;
using SIMS.Model;
using SIMS.Repository;
using System.Collections.Generic;

namespace SIMS.Service
{
    public class RoomEquipmentService
    {
        private RoomEquipmentRepository rer = new RoomEquipmentRepository();
        private RoomsCRUD rr = new RoomsCRUD();
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
            List<RoomEquipment> roomInventory = new List<RoomEquipment>();
            roomInventory = FindAll();
            foreach (RoomEquipment re in roomInventory)
            {
                if (re.equipmentId == roomEquipment.equipmentId && re.roomId == roomEquipment.roomId)
                {
                    re.quantity = roomEquipment.quantity;
                    rer.Update(re);
                }
            }

        }

        public List<Equipment> GetRoomEquipment(List<Equipment> allInventory, List<RoomEquipment> roomEquipment, int roomId)
        {
            List<Equipment> roomInventory = new List<Equipment>();
            foreach (Equipment e in allInventory)
            {
                e.RoomNum = new List<int>();
                foreach (RoomEquipment re in roomEquipment)
                {

                    if (e.id == re.equipmentId)
                    {

                        e.RoomNum.Add(re.roomId);
                        e.quantity = getQuantityByRoomId(e.id, roomId);
                    }
                }
            }

            foreach (Equipment e in allInventory)
            {
                if (e.RoomNum != null)
                {
                    foreach (int rn in e.RoomNum)
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

        public void CreateRoomEquipment(RoomEquipment roomEquipment)
        {
            rer.Create(roomEquipment);
        }

        public void TransferEquipment(Room roomSource, Room roomDestination, Equipment selectedEquipment, int quantity)
        {
            List<Room> rooms = new List<Room>();
            rooms = rr.FindAll();
            RoomEquipment roomEq = new RoomEquipment();
            List<RoomEquipment> roomEquipment = new List<RoomEquipment>();
            foreach (Room r in rooms)
            {
                if (r.floor == roomDestination.floor && r.roomNum == roomDestination.roomNum)
                {
                    roomEquipment = rer.FindAll();
                    roomEq.roomId = r.id;
                    roomEq.equipmentId = selectedEquipment.id;
                    if (rer.Exists(roomEq))
                    {
                        foreach (RoomEquipment re in roomEquipment)
                        {
                            if (re.roomId == roomEq.roomId && re.equipmentId == roomEq.equipmentId)
                            {
                                re.quantity += quantity;
                                rer.Update(re);
                                break;
                            }


                        }
                    }
                    else
                    {
                        roomEq.quantity = quantity;
                        rer.Create(roomEq);
                        break;
                    }
                }
                if (r.floor == roomSource.floor && r.roomNum == roomSource.roomNum)
                {
                    roomEquipment = rer.FindAll();
                    roomEq.roomId = r.id;
                    roomEq.equipmentId = selectedEquipment.id;
                    foreach (RoomEquipment re in roomEquipment)
                    {
                        if (re.roomId == roomEq.roomId && re.equipmentId == roomEq.equipmentId)
                        {
                            int sum = re.quantity - quantity;
                            re.quantity = sum;
                            rer.Update(re);
                            if (re.quantity == 0)
                            {
                                rer.DeleteEntity(re);
                            }
                            break;
                        }


                    }

                }
            }

        }

        public void DeleteEquipmentFromRoomByEquipmentId(int id)
        {
            List<RoomEquipment> roomInventory = new List<RoomEquipment>();
            roomInventory = FindAll();
            foreach (RoomEquipment re in roomInventory)
            {
                if (re.equipmentId == id)
                {
                    rer.DeleteEntity(re);
                }
            }

        }
    }
}
