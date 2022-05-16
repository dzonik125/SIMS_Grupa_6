﻿using SIMS.Model;
using SIMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service
{
    public class IngredientsService
    {
        public IngredientsRepository _ingredientsRepository = new IngredientsRepository();
        public List<Ingredients> FindAll()
        {
            return _ingredientsRepository.FindAll();
        }
    }
}
