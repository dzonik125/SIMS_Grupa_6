using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class AdressController
    {
            public Adress FindAdressById(string id)
        {
            return adressService.FindAdressById(id);
        }

        public bool UpdateAdress(Adress r)
        {
            adressService.UpdateAdress(r);
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
            adressService.AddAdress(a);
            return true;
        }

        public List<Adress> FindAll()
        {
            throw new NotImplementedException();
        }

        public Service.AdressService adressService = new AdressService();
        
    }
}
