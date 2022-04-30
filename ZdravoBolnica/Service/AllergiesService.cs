using SIMS.Model;
using SIMS.Repository;
using System.Collections.Generic;

namespace SIMS.Service
{
    public class AllergiesService
    {
        public AllergiesRepository ar = new AllergiesRepository();
        public List<Allergies> FindAll()
        {

            return ar.FindAll();
        }
    }
}
