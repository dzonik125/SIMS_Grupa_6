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
            return medicationRepository.FindAll();
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
