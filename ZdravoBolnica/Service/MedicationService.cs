using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using SIMS.Model;
using SIMS.Repository;

namespace SIMS.Service
{
    class MedicationService
    {
        private MedicationRepository medicationRepository = new();
        public void Create(Medication entity)
        {
            medicationRepository.Create(entity);
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            medicationRepository.DeleteById(id);
        }

       

        public List<Medication> FindAll()
        {
            return medicationRepository.FindAll();
        }



        public Medication FindById(int key)
        {
            return medicationRepository.FindById(key);
        }



        public void Update(Medication entity)
        {
            medicationRepository.Update(entity);
        }

        public List<Medication> FindAllWithoutThisOne(string name)
        {
            List<Medication> medications = FindAll();
            medications = RemoveMedicineFromList(medications, name);
            return medications;
        }

        public List<Medication> RemoveMedicineFromList(List<Medication> medications, string name)
        {
            foreach (Medication m in medications)
            {
                if (m.name.Equals(name))
                {
                    medications.Remove(m);
                    break;
                }
            }
            return medications;
        }
    }
}
