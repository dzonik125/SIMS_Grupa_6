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




        //public Service.AllergiesService allergiesService;
    }
}
