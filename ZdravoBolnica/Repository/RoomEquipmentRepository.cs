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

        public void setRoomEquipment(int id, List<Equipment> equipmentlist)
        {
            List<RoomEquipment> roominventory = new List<RoomEquipment>();
            foreach (Equipment e in equipmentlist)
            {
                RoomEquipment entity = new RoomEquipment();
                entity.equipmentId = e.id;
                entity.roomId = id;
                entity.quantity = 1;
                roominventory.Add(entity);
           
            }
            roomEquipmentSerializer.toCSV(filename, roominventory);
        }

        public int GetQuantityByRoomId(int id, int roomId)
        {
            List<RoomEquipment> roomInventory = new List<RoomEquipment>();
            roomInventory = FindAll();
            foreach (RoomEquipment re in roomInventory)
            {
                if ((re.equipmentId == id) && (re.roomId == roomId))
                {
                    return re.quantity;
                }
            
            }
            return 0;


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

        public List<RoomEquipment> FindAll()
        {
            return roomEquipmentSerializer.fromCSV(filename);
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
