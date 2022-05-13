using Model;
using Service;
using SIMS.Model;
using SIMS.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Service
{
    class OrderEquipmentService
    {
        private OrderEquipmentRepository oer = new OrderEquipmentRepository();
        private EquipmentRepository er = new EquipmentRepository();
        private EquipmentService equipmentService = new EquipmentService();
        private RoomService rs = new RoomService();
        private EquipmentService es = new EquipmentService();
        private BindingList<Equipment> equipmentList;
        public void CreateOrder()
        {
            List<OrderEquipment> orderEquipment = new List<OrderEquipment>();
            orderEquipment = oer.FindAll();
            List<Equipment> equipments = new List<Equipment>();
            equipments = er.FindAll();
            foreach (OrderEquipment oe in orderEquipment)
            {
                if (DateTime.Compare(DateTime.Now, oe.transferDate) == 0 || DateTime.Compare(oe.transferDate, DateTime.Now) < 0)
                {
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        /* Room rDestionation = new Room();
                         rDestionation = rs.FindRoomById(oe.roomDestiantionId);
                         List<Equipment> equip = new List<Equipment>();
                         foreach (Equipment e in equip)
                         {
                             equip = es.FindEquipmentById(e.id);
                         }*/
                        foreach (Equipment e in equipmentList)
                        {
                            equipmentService.AddEquipment(e);

                        }

                        //res.TransferEquipment(rSource, rDestionation, equip, et.quantity);
                        oer.Remove(oe);
                    });

                }
            }
        }

        public void SaveOrder(OrderEquipment equipment)
        {
            oer.Create(equipment);
        }

        public void SendEquipment(BindingList<Equipment> eq)
        {
            equipmentList = eq;
        }
    }
}
