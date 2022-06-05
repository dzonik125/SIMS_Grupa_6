using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace SIMS.Repository
{
    public class ManagerRepository : Repository<Manager, int>
    {
        private String filename = @".\..\..\..\Data\manager.txt";
        private Serializer<Manager> managerSerializer = new Serializer<Manager>();

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

        public List<Manager> FindAll()
        {
            return managerSerializer.fromCSV(filename);
        }

        public Manager FindById(int key)
        {
            List<Manager> managers = FindAll();
            foreach (Manager manager in managers)
            {
                if (manager.id == key)
                {
                    return manager;
                }
            }
            return null;
        }

        /*  public List<Manager> GetAllManagersForMeeting(int id)
          {
              List<Manager> managers = FindAll();
              foreach (Manager manager in managers)
              {
                  if (manager.id == id)
              }
          }*/



        public void Update(Manager entity)
        {
            throw new NotImplementedException();
        }
    }
}
