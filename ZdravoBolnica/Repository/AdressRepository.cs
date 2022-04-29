using Model;
using System;
using System.Collections.Generic;
namespace Repository
{
    public class AdressRepository : Repository<Adress, int>
    {
        private Serializer<Adress> adressSerializer = new();
        private String filename = @".\..\..\..\Data\adress.txt";
        public void Create(Adress entity)
        {
            List<Adress> adresses = new List<Adress>();
            adresses = adressSerializer.fromCSV(filename);
            int num = adresses.Count;
            if (num > 0)
            {
                entity.id = adresses[num - 1].id;
                entity.id++;
            }
            else
            {
                entity.id = 1;
            }
            adresses.Add(entity);
            adressSerializer.toCSV(filename, adresses);

        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {

        }


        public List<Adress> FindAll()
        {
            return adressSerializer.fromCSV(filename);
        }




        public Adress FindById(int key)
        {
            List<Adress> adresses = FindAll();
            foreach (Adress a in adresses)
            {
                if (a.id.Equals(key))
                {
                    return a;
                    break;
                }
            }
            return null;
        }

        public void Update(Adress entity)
        {
            List<Adress> adresses = FindAll();
            foreach (Adress a in adresses)
            {
                if (a.id.Equals(entity.id))
                {
                    a.number = entity.number;
                    a.street = entity.street;
                    a.city = entity.city;
                    a.country = entity.country;
                    break;
                }
            }
            adressSerializer.toCSV(filename, adresses);
        }
    }
}

