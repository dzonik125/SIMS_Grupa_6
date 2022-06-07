using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller
{
    public class IngredientsController
    {
        public IngredientsService _ingredientsService = new IngredientsService();
        public List<Ingredient> FindAll()
        {
            return _ingredientsService.FindAll();
        }
    }
}
