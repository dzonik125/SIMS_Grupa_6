using SIMS.Model;
using SIMS.Repository;
using System.Collections.Generic;

namespace SIMS.Service
{
    public class AllergiesService
    {
        public List<Allergen> FindAll()
        {
            AllergenRepository ar = new AllergenRepository();
            return ar.FindAll();
        }

        public void DeleteById(int id)
        {
            AllergenRepository ar = new AllergenRepository();
            ar.DeleteById(id);
        }
    }
}
