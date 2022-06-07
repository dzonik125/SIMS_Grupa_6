using Model;
using System;
using System.Collections.Generic;

namespace SIMS.Repository
{
    internal class EquipmentForOrderRepository
    {
        private String filename = @".\..\..\..\Data\equipmentForOrder.txt";
        private Serializer<Equipment> equipmentSerializer = new Serializer<Equipment>();
        public void Create(Equipment entity)
        {
            List<Equipment> inventory = new List<Equipment>();
            inventory = equipmentSerializer.fromCSV(filename);
            if (inventory.Count > 0)
            {

                entity.id = inventory[inventory.Count - 1].id;
                entity.id++;

            }
            else
            {
                entity.id = 1;
            }

            inventory.Add(entity);
            equipmentSerializer.toCSV(filename, inventory);
        }

        public void DeleteById(int id)
        {
            List<Equipment> inventory = new List<Equipment>();
            inventory = FindAll();
            foreach (Equipment e in inventory)
            {
                if (e.id == id)
                {
                    inventory.Remove(e);
                    break;
                }
            }
            equipmentSerializer.toCSV(filename, inventory);

        }

        public List<Equipment> FindAll()
        {
            return equipmentSerializer.fromCSV(filename);

        }

        public Equipment FindById(int key)
        {
            Equipment returnEquipment = new();
            foreach (Equipment e in FindAll())
            {
                if (e.id.Equals(key))
                {
                    returnEquipment = e;
                    break;
                }
                else
                {
                    returnEquipment = null;
                }
            }
            return returnEquipment;
        }

        public void Update(Equipment entity)
        {
            List<Equipment> inventory = FindAll();
            foreach (Equipment e in inventory)
            {
                if (e.id.Equals(entity.id))
                {
                    e.item = entity.item;
                    e.quantity = entity.quantity;
                    e.type = entity.type;
                }
            }
            equipmentSerializer.toCSV(filename, inventory);
        }
        public void DeleteAll()
        {
            throw new NotImplementedException();
        }
    }
}
