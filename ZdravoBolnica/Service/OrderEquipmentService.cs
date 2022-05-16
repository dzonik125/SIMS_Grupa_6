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
        private List<Equipment> equipment = new List<Equipment>();
        public void CreateOrder()
        {
            List<OrderEquipment> orderEquipment = new List<OrderEquipment>();
            orderEquipment = oer.FindAll();
            // List<Equipment> equipments = new List<Equipment>();
            // equipments = er.FindAll();
            int id = 0;
            foreach (OrderEquipment oe in orderEquipment)
            {
                foreach (Equipment ee in oe.equipments)
                {
                    //    orderEquipment.ids = ee.id;
                }
                if (DateTime.Compare(DateTime.Now, oe.transferDate) == 0 || DateTime.Compare(oe.transferDate, DateTime.Now) < 0)
                {
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        Equipment equip = new Equipment();
                        foreach (Equipment e in equipment)
                        {

                            //  equip.id = es.FindEquipmentById(Int32.Parse(oe.equipments));
                        }
                        /* Room rDestionation = new Room();
                         rDestionation = rs.FindRoomById(oe.roomDestiantionId);
                         List<Equipment> equip = new List<Equipment>();
                         foreach (Equipment e in equip)
                         {
                             equip = es.FindEquipmentById(e.id);
                         }*/
                        //foreach (Equipment e in equipment)
                        //   {
                        equipmentService.AddEquipment(equip);

                        //  }

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
            // equipmentList = eq;
        }
    }
}
