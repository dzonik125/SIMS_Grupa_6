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
        private MedicationService _medicationService = new MedicationService();
        


        public void Create(Medication entity)
        {
            _medicationService.Create(entity);
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

     

        public void DeleteById(int id)
        {
            _medicationService.DeleteById(id);
        }

        public List<Medication> FindAll()
        {
            return _medicationService.FindAll();
        }



        public Medication FindById(int key)
        {
            return _medicationService.FindById(key);
        }



        public void Update(Medication entity)
        {
            _medicationService.Update(entity);
        }

        public List<Medication> FindAllWithoutThisOne(string name)
        {
            return _medicationService.FindAllWithoutThisOne(name);
        }
    }
}
