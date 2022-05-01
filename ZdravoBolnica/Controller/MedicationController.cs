using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller
{
    public class MedicationController
    {
        MedicationService medicationService = new();


        public void Create(Medication entity)
        {
            medicationService.Create(entity);
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
            return medicationService.FindAll();
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
