using Model;
using Repository;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository
{
    class MedicationRepository : Repository<Medication, int>
    {
        private Serializer<Medication> medicationSerializer = new();
        private String filename = @".\..\..\..\Data\medications.txt";

        public void Create(Medication entity)
        {
            List<Medication> medications = new List<Medication>();
            medications = medicationSerializer.fromCSV(filename);
            int num = medications.Count;
            if (num > 0)
            {
                entity.id = medications[num - 1].id;
                entity.id++;
            }
            else
            {
                entity.id = 1;
            }
            medications.Add(entity);
            medicationSerializer.toCSV(filename, medications);

        }
    

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(Medication id)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Medication> FindAll()
        {
            return medicationSerializer.fromCSV(filename);
        }

      

        public Medication FindById(int key)
        {
            throw new NotImplementedException();
        }

        

        public void Update(Medication entity)
        {
            throw new NotImplementedException();
        }

    }
}
