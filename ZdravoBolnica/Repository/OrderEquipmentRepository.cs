using Model;
using Repository;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Repository
{
    class OrderEquipmentRepository : IRepository<OrderEquipment, int>
    {
        private String filename = @".\..\..\..\Data\orders.txt";
        private Serializer<OrderEquipment> orderEquipmentSerilizer = new Serializer<OrderEquipment>();
        public void Create(OrderEquipment entity)
        {
            List<OrderEquipment> orderEquipment = new List<OrderEquipment>();
            orderEquipment = orderEquipmentSerilizer.fromCSV(filename);

            orderEquipment.Add(entity);
            orderEquipmentSerilizer.toCSV(filename, orderEquipment);
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderEquipment> FindAll()
        {
            return orderEquipmentSerilizer.fromCSV(filename);
        }

        public OrderEquipment FindById(int key)
        {
            throw new NotImplementedException();
        }

        internal void Remove(OrderEquipment oe)
        {

            List<OrderEquipment> orderEquipment = new List<OrderEquipment>();
            orderEquipment = FindAll();
            foreach (OrderEquipment o in orderEquipment)
            {
                if (DateTime.Compare(o.transferDate, oe.transferDate) == 0)
                {
                    orderEquipment.Remove(o);
                    break;
                }
            }
            orderEquipmentSerilizer.toCSV(filename, orderEquipment);
        }

        public void Update(OrderEquipment entity)
        {
            throw new NotImplementedException();
        }

        /*      internal void Remove(OrderEquipment oe)
              {
                  List<OrderEquipment> orderEquipment = new List<OrderEquipment>();
                  orderEquipment = FindAll();
                  foreach (OrderEquipment e in orderEquipment)
                  {
                      if (e.roomSourceId == oe.roomSourceId && DateTime.Compare(e.transferDate, oe.transferDate) == 0)
                      {
                          equipTransfer.Remove(e);
                          break;
                      }
                  }
                  transferEquipmentSerilizer.toCSV(filename, equipTransfer);
              }*/
    }
}
