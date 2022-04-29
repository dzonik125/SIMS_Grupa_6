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
            throw new NotImplementedException();
        }
        public RoomEquipment FindById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(RoomEquipment entity)
        {
            throw new NotImplementedException();
        }
    }
}

