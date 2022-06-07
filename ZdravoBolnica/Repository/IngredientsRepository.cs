using Model;
using Repository;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Repository
{
    public class IngredientsRepository : IRepository<Ingredient, int>
    {
        private Serializer<Ingredient> ingrediantsSerializer = new Serializer<Ingredient>();
        private String filename = @".\..\..\..\Data\ingredients.txt";

        public void Create(Ingredient entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ingredient> FindAll()
        {
            return ingrediantsSerializer.fromCSV(filename);
        }

        public Ingredient FindByName(string key)
        {
            List<Ingredient> ingredients = FindAll();
            foreach (Ingredient i in ingredients)
            {
                if (i.name.Equals(key))
                {
                    return i;
                }
            }
            return null;
        }

        public Ingredient FindById(int key)
        {
            List<Ingredient> ingredients = FindAll();
            foreach (Ingredient i in ingredients)
            {
                if (i.id.Equals(key))
                {
                    return i;
                }
            }
            return null;
        }


        public void Update(Ingredient entity)
        {
            throw new NotImplementedException();
        }
    }
}
