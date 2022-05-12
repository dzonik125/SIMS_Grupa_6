using Model;
using Repository;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository
{
    public class SeparateRoomsRepository : Repository<SeparateRooms, int>
    {
        private String filename = @".\..\..\..\Data\separateRooms.txt";
        private Serializer<SeparateRooms> _separateRoomSerializer = new Serializer<SeparateRooms>();
        public void Create(SeparateRooms entity)
        {
            List<SeparateRooms> separateRoomsList = new List<SeparateRooms>();
            separateRoomsList = FindAll();

            separateRoomsList.Add(entity);
            _separateRoomSerializer.toCSV(filename, separateRoomsList);
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<SeparateRooms> FindAll()
        {
            return _separateRoomSerializer.fromCSV(filename);
        }

        public SeparateRooms FindById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(SeparateRooms entity)
        {
            throw new NotImplementedException();
        }
    }
}
