using Model;
using Service;
using SIMS.Model;
using SIMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service
{
     public class EquipmentService
    {
        private EquipmentRepository er = new EquipmentRepository();
        private RoomEquipmentService res = new RoomEquipmentService();
        private RoomService rs = new RoomService();
        public List<Equipment> FindAll()
        {
            return er.FindAll();
        }

        public bool AddEquipment(Equipment equipment)
        {
            List<Equipment> inventory = new List<Equipment>();
            inventory = er.FindAll();
            List<RoomEquipment> roomInvetory = new List<RoomEquipment>();
            roomInvetory = res.FindAll();
            bool exist = false;
            foreach (RoomEquipment re in roomInvetory)
            {
                if (GetEquipmentItemNameById(re.equipmentId).Equals(equipment.item) && rs.GetRoomTypeById(re.roomId).Equals("Magacin"))
                {
                    re.quantity += equipment.quantity;
                    res.UpdateRoomEquipment(re);
                    exist = true;
                    break;
                }
            
            }
           
            foreach (Equipment e in inventory)
            {
                if (e.item.Equals(equipment.item))
                {
                    e.quantity += equipment.quantity;
                    UpdateEquipment(e);
                    return true;
                
                }

            }
            er.Create(equipment);
            if (!exist)
            {
                RoomEquipment rEquipment = new RoomEquipment();
                rEquipment.equipmentId = GetEquipmentIdByItem(equipment);
                rEquipment.roomId = rs.GetRoomIdByStorage(RoomType.storage);
                rEquipment.quantity = equipment.quantity;
                res.CreateRoomEquipment(rEquipment);
            }
            return true;
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
            er.Update(e);
            return true;
        }

        public void DeleteEquipmentById(int id)
        {
            res.DeleteEquipmentFromRoomByEquipmentId(id);
            er.DeleteById(id);
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
