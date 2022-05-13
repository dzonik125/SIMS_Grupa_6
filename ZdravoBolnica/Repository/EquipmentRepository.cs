using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace SIMS.Repository
{
    class EquipmentRepository : Repository<Equipment, int>
    {
        private String filename = @".\..\..\..\Data\equipment.txt";
        private Serializer<Equipment> equipmentSerializer = new Serializer<Equipment>();
        public void Create(Equipment entity)
        {
            List<Equipment> inventory = new List<Equipment>();
            inventory = equipmentSerializer.fromCSV(filename);
            int num = inventory.Count;
            if (num > 0)
            {

                entity.id = inventory[num - 1].id;
                entity.id++;

            }
            else
            {
                entity.id = 1;
            }

            inventory.Add(entity);
            equipmentSerializer.toCSV(filename, inventory);

        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
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
            List<Equipment> equipments = FindAll();
            foreach (Equipment e in equipments)
            {
                if (e.id.Equals(key))
                {
                    return e;
                }
            }
            return null;
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
    }
}
