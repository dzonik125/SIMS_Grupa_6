using Model;
using Service;
using SIMS.Model;
using SIMS.Repository;
using System;
using System.Collections.Generic;

namespace SIMS.Service
{
    public class EquipmentService
    {
        private EquipmentRepository equipmentRepository = new EquipmentRepository();
        private EquipmentForOrderRepository efo = new EquipmentForOrderRepository();
        private RoomEquipmentService roomEquipmentService = new RoomEquipmentService();
        private RoomService roomService = new RoomService();
        private bool exist = false;
        public List<Equipment> FindAll()
        {
            return equipmentRepository.FindAll();
        }

        public bool AddEquipment(Equipment equipment)
        {

            IncreaseRoomEquipmentQuantity(equipment);

            if (UpdateEquipmentQuantity(equipment)) return true;
            equipmentRepository.Create(equipment);
            RoomEquipmentDoesntExists(equipment);
            return true;
        }

        private void RoomEquipmentDoesntExists(Equipment equipment)
        {
            if (!exist)
            {
                RoomEquipment rEquipment = new RoomEquipment();
                rEquipment.equipmentId = GetEquipmentIdByItem(equipment);
                rEquipment.roomId = roomService.GetRoomIdByStorage(RoomType.storage);
                rEquipment.quantity = equipment.quantity;
                roomEquipmentService.CreateRoomEquipment(rEquipment);
            }
        }

        private bool UpdateEquipmentQuantity(Equipment equipment)
        {
            foreach (Equipment e in equipmentRepository.FindAll())
            {
                if (e.item.Equals(equipment.item))
                {
                    e.quantity += equipment.quantity;
                    UpdateEquipment(e);
                    return true;
                }
            }

            return false;
        }

        private void IncreaseRoomEquipmentQuantity(Equipment equipment)
        {
            foreach (RoomEquipment roomEquipment in roomEquipmentService.FindAll())
            {
                if (GetEquipmentItemNameById(roomEquipment.equipmentId).Equals(equipment.item) &&
                    roomService.GetRoomTypeById(roomEquipment.roomId).Equals("Magacin"))
                {
                    roomEquipment.quantity += equipment.quantity;
                    roomEquipmentService.UpdateRoomEquipment(roomEquipment);
                    exist = true;
                    break;
                }
            }
        }


        public bool AddEquipmentForOrder(Equipment equipment)
        {
            bool exist = false;
            if (CheckForUpdateAndUpdate(equipment))
            {
                exist = true;
            }
            else
            {
                efo.Create(equipment);
            }
            return exist;
        }

        private bool CheckForUpdateAndUpdate(Equipment equipment)
        {
            foreach (Equipment e in efo.FindAll())
            {
                if (e.item.Equals(equipment.item))
                {
                    //e.quantity += equipment.quantity;
                    UpdateEquipmentForOrder(e);
                    return true;
                }
            }

            return false;
        }




        public List<Equipment> GetEquipmentByType(EquipmentType type)
        {
            List<Equipment> inventory = new List<Equipment>();
            foreach (Equipment e in FindAll())
            {
                if (e.type == type)
                {
                    inventory.Add(e);
                }
            }
            return inventory;
        }


        private int GetEquipmentIdByItem(Equipment equipment)
        {
            int id = 0;
            foreach (Equipment e in FindAll())
            {
                if (e.item == equipment.item)
                {
                    id = e.id;
                }
            }
            return id;
        }

        public void UpdateQuantity(Equipment equipment)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEquipment(Equipment e)
        {
            equipmentRepository.Update(e);
            return true;
        }

        public bool UpdateEquipmentForOrder(Equipment e)
        {
            efo.Update(e);
            return true;
        }

        public void DeleteEquipmentById(int id)
        {
            roomEquipmentService.DeleteEquipmentFromRoomByEquipmentId(id);
            equipmentRepository.DeleteById(id);
        }

        public String GetEquipmentItemNameById(int id)
        {
            string equipmentName = "";
            foreach (Equipment e in FindAll())
            {
                if (e.id == id)
                {
                    equipmentName = e.item;
                }
            }
            return equipmentName;
        }

        public Equipment FindEquipmentById(int id)
        {
            Equipment equipment = null;
            foreach (Equipment e in FindAll())
            {
                if (e.id == id)
                {
                    equipment =  e;
                }
            }
            return equipment;
        }
    }
}
