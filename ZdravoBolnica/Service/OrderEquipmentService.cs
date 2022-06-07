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
        private EquipmentService equipmentService = new EquipmentService();
        private BindingList<Equipment> equipmentList = new BindingList<Equipment>();
        private Equipment equipmentForAdd = new Equipment();
        public void CreateOrder()
        {
            foreach (OrderEquipment order in orderEquipmentRepository.FindAll())
            {
                if (DateTime.Compare(DateTime.Now, order.transferDate) == 0 || DateTime.Compare(order.transferDate, DateTime.Now) < 0)
                {
                    InvokeTimer();
                    orderEquipmentRepository.Remove(order);
                }
            }
        }

        private void InvokeTimer()
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                foreach (Equipment equipment in equipmentList)
                {
                    equipmentForAdd = equipment;
                    equipmentService.AddEquipment(equipmentForAdd);
                }
            });
        }

        public void SaveOrder(OrderEquipment orderEquipment)
        {
            orderEquipmentRepository.Create(orderEquipment);
        }

        public void SendEquipment(BindingList<Equipment> equipments)
        {
            equipmentList = equipments;
        }
    }
}
