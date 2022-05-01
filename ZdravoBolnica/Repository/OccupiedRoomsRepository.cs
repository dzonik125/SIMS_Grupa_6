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
    public class OccupiedRoomsRepository : Repository<OccupiedRooms, int>
    {
        private String filename = @".\..\..\..\Data\occupied_rooms.txt";
        private Serializer<OccupiedRooms> occupiedRoomsSerializer = new Serializer<OccupiedRooms>();
        public void Create(OccupiedRooms entity)
        {
            List<OccupiedRooms> occupiedRooms = new List<OccupiedRooms>();
            occupiedRooms = FindAll();
            occupiedRooms.Add(entity);
            occupiedRoomsSerializer.toCSV(filename, occupiedRooms);
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<OccupiedRooms> FindAll()
        {
            return occupiedRoomsSerializer.fromCSV(filename);
        }

        public OccupiedRooms FindById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(OccupiedRooms entity)
        {
            throw new NotImplementedException();
        }
    }
}
