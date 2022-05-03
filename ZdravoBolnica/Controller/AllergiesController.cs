using SIMS.Model;
using SIMS.Service;
using System.Collections.Generic;

namespace SIMS.Controller
{
    public class AllergiesController
    {
        // public AllergiesService as = AllergiesService();
        public List<Allergies> FindAll()
        {

            AllergiesService als = new AllergiesService();
            return als.FindAll();
        }

        public void DeleteById(int id)
        {
            AllergiesService als = new AllergiesService();
            als.DeleteById(id);
        }



        //public Service.AllergiesService allergiesService;
    }
}
