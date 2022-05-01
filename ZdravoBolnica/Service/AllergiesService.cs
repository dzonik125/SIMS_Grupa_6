using SIMS.Model;
using SIMS.Repository;
using System.Collections.Generic;

namespace SIMS.Service
{
    public class AllergiesService
    {
        //public AllergiesRepository ar = new AllergiesRepository();
        public List<Allergies> FindAll()
        {
            AllergiesRepository ar = new AllergiesRepository();
            return ar.FindAll();
        }

        public void DeleteById(int id)
        {
            AllergiesRepository ar = new AllergiesRepository();
            ar.DeleteById(id);
        }
    }
}
