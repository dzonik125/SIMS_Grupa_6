using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace SIMS.Repository
{
    public class SecretaryRepository : IRepository<Secretary, int>
    {

        private String filename = @".\..\..\..\Data\secretary.txt";
        private Serializer<Secretary> secretarySerializer = new Serializer<Secretary>();

        public void Create(Secretary entity)
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

        public List<Secretary> FindAll()
        {
            return secretarySerializer.fromCSV(filename);
        }

        public Secretary FindById(int key)
        {
            Secretary returnSecretary = new();
            foreach (Secretary secretary in FindAll())
            {
                if (secretary.id == key)
                {
                    returnSecretary = secretary;
                    break;
                }
                else
                {
                    returnSecretary = null;
                }
            }
            return returnSecretary;
        }

        public void Update(Secretary entity)
        {
            throw new NotImplementedException();
        }
    }
}
