using Model;
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
        public List<Equipment> FindAll()
        {
            return er.FindAll();
        }

        public bool AddEquipment(Equipment equipment)
        {
            er.Create(equipment);
            return true;
        }

        public bool UpdateEquipment(Equipment e)
        {
            er.Update(e);
            return true;
        }

        internal void DeleteEquipmentById(int id)
        {
            er.DeleteById(id);
        }
    }
}
