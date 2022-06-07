using Model;
using Repository;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Repository
{
    class MedicationRepository : IRepository<Medication, int>
    {
        private Serializer<Medication> medicationSerializer = new();
        private String filename = @".\..\..\..\Data\medications.txt";

        public void Create(Medication entity)
        {
            List<Medication> medications = new List<Medication>();
            medications = medicationSerializer.fromCSV(filename);
            if (medications.Count > 0)
            {
                entity.id = medications[medications.Count - 1].id;
                entity.id++;
            }
            else
            {
                entity.id = 1;
            }
            medications.Add(entity);
            medicationSerializer.toCSV(filename, medications);
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
            Medication returnMedication = new();
            foreach (Medication m in FindAll())
            {
                if (m.id.Equals(key))
                {
                    returnMedication = m;
                    break;
                }
                else
                {
                    returnMedication = null; 
                }
            }
            return returnMedication;
        }



        public void Update(Medication entity)
        {
            List<Medication> medications = FindAll();
            foreach(Medication m in medications)
            {
                if(m.id == entity.id)
                {
                    int index = medications.IndexOf(m);
                    if (index != -1)
                    {
                        medications[index] = entity;
                        break;
                    }
                }
            }
            medicationSerializer.toCSV(filename, medications);
        }
        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

    }
}
