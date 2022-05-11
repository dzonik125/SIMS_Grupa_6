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
    class MergeRoomsRepository : Repository<MergeRooms, int>
    {
        private String filename = @".\..\..\..\Data\mergeRooms.txt";
        private Serializer<MergeRooms> _mergeRoomSerializer = new Serializer<MergeRooms>();
        public void Create(MergeRooms entity)
        {
            List<MergeRooms> mergeRoomsList = new List<MergeRooms>();
            mergeRoomsList = FindAll();
           
            mergeRoomsList.Add(entity);
            _mergeRoomSerializer.toCSV(filename, mergeRoomsList);
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<MergeRooms> FindAll()
        {
            return _mergeRoomSerializer.fromCSV(filename);
        }

        public MergeRooms FindById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(MergeRooms entity)
        {
            throw new NotImplementedException();
        }
    }
}
