using Model;
using Service;
using SIMS.Model;
using SIMS.Repository;
using System;
using System.ComponentModel;

namespace SIMS.Service
{
    class OrderEquipmentService
    {
        public OrderEquipmentRepository orderEquipmentRepository = new OrderEquipmentRepository();
        private EquipmentRepository er = new EquipmentRepository();
        private EquipmentService equipmentService = new EquipmentService();
        private RoomService rs = new RoomService();
        private EquipmentService es = new EquipmentService();
        private BindingList<Equipment> equipmentList = new BindingList<Equipment>();
        //private List<OrderEquipment> orderEquipment;
        private Equipment equipment = new Equipment();
        public void CreateOrder()
        {
            //orderEquipment = oer.FindAll();
            CheckIsTimeNow();
        }

        public void CheckIsTimeNow()
        {
            foreach (OrderEquipment order in orderEquipmentRepository.FindAll())
            {
                if (DateTime.Compare(DateTime.Now, order.transferDate) == 0 || DateTime.Compare(order.transferDate, DateTime.Now) < 0)
                {
                    DispatcherForAdd();
                    orderEquipmentRepository.Remove(order);
                }
            }
        }
        public void DispatcherForAdd()
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                AddEquipmentToStorage();
            });
        }

        public void AddEquipmentToStorage()
        {
            foreach (Equipment e in equipmentList)
            {
                equipment = e;
                equipmentService.AddEquipment(equipment);
            }
        }

        public void SaveOrder(OrderEquipment equipment)
        {
            orderEquipmentRepository.Create(equipment);
        }

        public void SendEquipment(BindingList<Equipment> equipments)
        {
            equipmentList = equipments;
        }
    }
}
