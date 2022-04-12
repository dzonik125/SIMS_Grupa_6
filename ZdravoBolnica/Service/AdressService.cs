using System;
using Repository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public class AdressService
    {

       

        public Adress FindAdressById(string id)
        {
            return adressRepository.FindById(id);
        }

        public bool UpdateAdress(Adress r)
        {
            adressRepository.Update(r);
            return true;
        }

        public bool DeleteAdressById(string id)
        {
            
            return true;
        }

        public bool DeleteAllAdresses()
        {
            throw new NotImplementedException();
        }

        public bool AddAdress(Adress a)
        {
            adressRepository.Create(a);
            return true;
        }

        public List<Adress> FindAll()
        {
            throw new NotImplementedException();
        }
        public Repository.AdressRepository adressRepository = new();



    }
}
