using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace SIMS.Repository
{
    public class ManagerRepository : IRepository<Manager, int>
    {
        private String filename = @".\..\..\..\Data\manager.txt";
        private Serializer<Manager> managerSerializer = new Serializer<Manager>();

        public List<Manager> FindAll()
        {
            return managerSerializer.fromCSV(filename);
        }

        public Manager FindById(int key)
        {
            Manager returnManager = new();
            foreach (Manager manager in FindAll())
            {
                if (manager.id == key)
                {
                    returnManager = manager;
                    break;
                }
                else
                {
                    returnManager = null;
                }
            }
            return returnManager;
        }

        /*  public List<Manager> GetAllManagersForMeeting(int id)
          {
              List<Manager> managers = FindAll();
              foreach (Manager manager in managers)
              {
                  if (manager.id == id)
              }
          }*/

        public void Create(Manager entity)
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

        public void Update(Manager entity)
        {
            throw new NotImplementedException();
        }
    }
}
