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

            foreach (RoomEquipment roomEquipment in roomEquipmentService.FindAll())
            {
                if (GetEquipmentItemNameById(roomEquipment.equipmentId).Equals(equipment.item) && roomService.GetRoomTypeById(roomEquipment.roomId).Equals("Magacin"))
                {
                    roomEquipment.quantity += equipment.quantity;
                    roomEquipmentService.UpdateRoomEquipment(roomEquipment);
                    exist = true;
                    break;
                }
            }

            foreach (Equipment e in equipmentRepository.FindAll())
            {
                if (e.item.Equals(equipment.item))
                {
                    e.quantity += equipment.quantity;
                    UpdateEquipment(e);
                    return true;
                }
            }
            equipmentRepository.Create(equipment);
            if (!exist)
            {
                RoomEquipment rEquipment = new RoomEquipment();
                rEquipment.equipmentId = GetEquipmentIdByItem(equipment);
                rEquipment.roomId = roomService.GetRoomIdByStorage(RoomType.storage);
                rEquipment.quantity = equipment.quantity;
                roomEquipmentService.CreateRoomEquipment(rEquipment);
            }
            return true;
        }



        public bool AddEquipmentForOrder(Equipment equipment)
        {
            List<Equipment> inventory = new List<Equipment>();
            inventory = efo.FindAll();
            //bool exist = false;
            foreach (Equipment e in inventory)
            {
                if (e.item.Equals(equipment.item))
                {
                    //e.quantity += equipment.quantity;
                    UpdateEquipmentForOrder(e);
                    return true;
                }
            }
            efo.Create(equipment);
            /*     if (!exist)
                 {
                     RoomEquipment rEquipment = new RoomEquipment();
                     rEquipment.equipmentId = GetEquipmentIdByItem(equipment);
                     rEquipment.roomId = rs.GetRoomIdByStorage(RoomType.storage);
                     rEquipment.quantity = equipment.quantity;
                     res.CreateRoomEquipment(rEquipment);
                 }*/
            return true;
        }




        public List<Equipment> GetiEquipmentByType(EquipmentType type)
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
            List<Equipment> invetory = new List<Equipment>();
            invetory = FindAll();
            foreach (Equipment e in invetory)
            {
                if (e.item == equipment.item)
                {
                    return e.id;
                }
            }
            return 0;
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
            List<Equipment> invetory = new List<Equipment>();
            invetory = FindAll();
            foreach (Equipment e in invetory)
            {
                if (e.id == id)
                {
                    return e.item;
                }
            }
            return "";
        }

        public Equipment FindEquipmentById(int id)
        {
            List<Equipment> invetory = new List<Equipment>();
            invetory = FindAll();
            foreach (Equipment e in invetory)
            {
                if (e.id == id)
                {
                    return e;
                }
            }
            return null;
        }
    }
}
