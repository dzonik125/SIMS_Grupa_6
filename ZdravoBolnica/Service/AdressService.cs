using Model;
using System;
using System.Collections.Generic;

namespace Service
{
    public class AdressService
    {



        public Adress FindAdressById(int id)
        {
            return adressRepository.FindById(id);
        }

        public bool UpdateAdress(Adress r)
        {
            adressRepository.Update(r);
            return true;
        }

        public bool DeleteAdressById(int id)
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
