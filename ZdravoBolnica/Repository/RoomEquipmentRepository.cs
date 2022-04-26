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
    class RoomEquipmentRepository : Repository<RoomEquipment, int>

    {
        private String filename = @".\..\..\..\Data\room_equipment.txt";
        private Serializer<RoomEquipment> roomEquipmentSerializer = new Serializer<RoomEquipment>();
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

        public List<RoomEquipment> FindAll()
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
