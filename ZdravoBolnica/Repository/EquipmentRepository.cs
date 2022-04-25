using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public void Update(Equipment entity)
        {
            List<Equipment> inventory = FindAll();
            foreach (Equipment e in inventory)
            {
                if (e.id.Equals(entity.id))
                {
                    e.item = entity.item;
                    e.type = entity.type;
                }
            }
            equipmentSerializer.toCSV(filename, inventory);
        }
    }
}
