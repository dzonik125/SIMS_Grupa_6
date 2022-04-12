using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Repository
{
    public class AdressRepository : Repository<Adress, string>
    {
        private Serializer<Adress> adressSerializer = new();
        private String filename = @".\..\..\..\Data\adress.txt";
        public void Create(Adress entity)
        {
            List<Adress> adress = new List<Adress>();
            adress = adressSerializer.fromCSV(filename);
            adress.Add(entity);
            adressSerializer.toCSV(filename, adress);

        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            
        }


        public List<Adress> FindAll()
        {
            return adressSerializer.fromCSV(filename);
        }

       
   

        public Adress FindById(string key)
        {
            List<Adress> adresses = FindAll();
            foreach(Adress a in adresses)
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
            foreach(Adress a in adresses)
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

