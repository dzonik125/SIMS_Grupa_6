using Model;
using SIMS.Model;
using SIMS.Service;
using System.ComponentModel;

namespace SIMS.Controller
{
    public class OrderEquipmentController
    {
        public OrderEquipmentService oes = new OrderEquipmentService();

        public void CreateOrder(object state)
        {
            oes.CreateOrder();
        }


        public void SaveOrder(OrderEquipment equipment)
        {
            oes.SaveOrder(equipment);
        }

        public void SendEquipment(BindingList<Equipment> eq)
        {
            oes.SendEquipment(eq);
        }
    }
}
