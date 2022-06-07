using Model;
using System;
using System.Collections.Generic;
namespace Repository
{
    public class AdressRepository : IRepository<Adress, int>
    {
        private Serializer<Adress> adressSerializer = new();
        private String filename = @".\..\..\..\Data\adress.txt";
        public void Create(Adress entity)
        {
            List<Adress> adresses = new List<Adress>();
            adresses = adressSerializer.fromCSV(filename);
            if (adresses.Count > 0)
            {
                entity.id = adresses[adresses.Count - 1].id;
                entity.id++;
            }
            else
            {
                entity.id = 1;
            }
            adresses.Add(entity);
            adressSerializer.toCSV(filename, adresses);

        }


        public List<Adress> FindAll()
        {
            return adressSerializer.fromCSV(filename);
        }




        public Adress FindById(int key)
        {
            Adress returnAddress = new();
            foreach (Adress a in FindAll())
            {
                if (a.id.Equals(key))
                {
                    returnAddress = a;
                    break;
                }
                else
                {
                    returnAddress = null;
                }
            }
            return returnAddress;
        }


        public void Update(Adress entity)
        {
            List<Adress> adresses = FindAll();
            foreach (Adress a in adresses)
            {
                if (a.id.Equals(entity.id))
                {
                    int index = adresses.IndexOf(a);
                    if (index != -1)
                    {
                        adresses[index] = entity;
                        break;
                    }
                }
            }
            adressSerializer.toCSV(filename, adresses);
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

