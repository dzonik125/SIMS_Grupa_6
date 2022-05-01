using Model;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Repository
{
    public class AllergiesRepository
    {
        private String filename = @".\..\..\..\Data\allergies.txt";
        private Serializer<Allergies> allergiesSerializer = new Serializer<Allergies>();

        public List<Allergies> FindAll()
        {
            return allergiesSerializer.fromCSV(filename);
        }

        public void Create(RoomEquipment entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            List<Allergies> allergies = FindAll();
            foreach (Allergies a in allergies)
            {
                if (a.id.Equals(id))
                {
                    allergies.Remove(a);
                    break;
                }
            }
            allergiesSerializer.toCSV(filename, allergies);
        }
        public Allergies FindById(int key)
        {
            List<Allergies> allergies = FindAll();
            foreach (Allergies a in allergies)
            {
                if (a.id.Equals(key))
                {
                    return a;
                }
            }
            return null;
        }

        public void Update(RoomEquipment entity)
        {
            throw new NotImplementedException();
        }
    }
}

