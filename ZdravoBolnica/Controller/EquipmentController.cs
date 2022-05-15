﻿using Model;
using SIMS.Service;
using System.Collections.Generic;

namespace SIMS.Controller
{
    public class EquipmentController
    {
        private EquipmentService es = new EquipmentService();
        public List<Equipment> FindAll()
        {
            return es.FindAll();

        }

        public bool AddEquipment(Equipment equipment)
        {
            es.AddEquipment(equipment);
            return true;
        }

        public bool AddEquipmentForOrder(Equipment equipment)
        {
            es.AddEquipmentForOrder(equipment);
            return true;
        }

        /* public bool AddDynamicEquipment(BindingList<Equipment> equipment)
         {
             es.AddDynamicEquipment(equipment);
             return true;
         }*/

        public bool UpdateEquipment(Equipment e)
        {
            es.UpdateEquipment(e);
            return true;
        }

        public bool UpdateEquipmentForOrder(Equipment e)
        {
            es.UpdateEquipmentForOrder(e);
            return true;
        }

        public bool DeleteEquipmentById(int id)
        {
            es.DeleteEquipmentById(id);
            return true;
        }
    }
}
