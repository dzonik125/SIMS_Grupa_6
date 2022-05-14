using Model;
using Repository;
using SIMS.Model;
using System;
using System.Collections.Generic;

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

       
        public void DeleteById(int id)
        {
            List<Medication> medications = FindAll();
            foreach (Medication m in medications)
            {
                if (m.id.Equals(id))
                {
                    medications.Remove(m);
                    break;
                }
            }
            medicationSerializer.toCSV(filename, medications);
        }

        public List<Medication> FindAll()
        {
            return medicationSerializer.fromCSV(filename);
        }



        public Medication FindById(int key)
        {
            List<Medication> medications = FindAll();
            foreach (Medication m in medications)
            {
                if (m.id.Equals(key))
                {
                    return m;
                }
            }
            return null;
        }



        public void Update(Medication entity)
        {
            List<Medication> medications = FindAll();
            foreach(Medication m in medications)
            {
                if(m.id == entity.id)
                {
                    m.name = entity.name;
                    m.Amount = entity.Amount;
                    m.status = entity.status;
                    m.components = entity.components;
                    m.medicationReplacementIds = entity.medicationReplacementIds;
                    m.comment = entity.comment;
                    break;
                }
            }
            medicationSerializer.toCSV(filename, medications);
        }

    }
}
