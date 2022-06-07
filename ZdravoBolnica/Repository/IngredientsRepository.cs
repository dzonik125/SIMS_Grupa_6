using Model;
using Repository;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Repository
{
    public class IngredientsRepository : Repository<Ingredients, string>
    {
        private Serializer<Ingredients> ingrediantsSerializer = new Serializer<Ingredients>();
        private String filename = @".\..\..\..\Data\ingredients.txt";

        public void Create(Ingredients entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Ingredients> FindAll()
        {
            return ingrediantsSerializer.fromCSV(filename);
        }

        public Ingredients FindById(string key)
        {
            List<Ingredients> ingredients = FindAll();
            foreach (Ingredients i in ingredients)
            {
                if (i.name.Equals(key))
                {
                    return i;
                }
            }
            return null;
        }

        public Ingredients FindById2(int key)
        {
            List<Ingredients> ingredients = FindAll();
            foreach (Ingredients i in ingredients)
            {
                if (i.id.Equals(key))
                {
                    return i;
                }
            }
            return null;
        }



        public void Update(Ingredients entity)
        {
            throw new NotImplementedException();
        }
    }
}
