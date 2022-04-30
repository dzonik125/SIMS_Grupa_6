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
            roominventory = FindAll();
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
            List<RoomEquipment> roomInventory = new List<RoomEquipment>();
            roomInventory = FindAll();
            roomInventory.Add(entity);
            roomEquipmentSerializer.toCSV(filename, roomInventory);
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
            List<RoomEquipment> roomEquipment = new List<RoomEquipment>();
            roomEquipment = FindAll();
            foreach (RoomEquipment re in roomEquipment)
            {
                if (re.equipmentId == entity.equipmentId && re.roomId == entity.roomId)
                {
                    re.quantity = entity.quantity;
                    break;
                }

            }
            roomEquipmentSerializer.toCSV(filename, roomEquipment);
        }

        public bool Exists(RoomEquipment entity)
        {
            List<RoomEquipment> roomInventory = new List<RoomEquipment>();
            roomInventory = FindAll();
            foreach(RoomEquipment re in roomInventory)
            {
                if (re.equipmentId == entity.equipmentId && re.roomId == entity.roomId)
                {
                    return true;
                }
            
            }
            return false;
        }

        public void DeleteEntity(RoomEquipment entity)
        {
            List<RoomEquipment> roomEquipment = new List<RoomEquipment>();
            roomEquipment = FindAll();
            foreach (RoomEquipment re in roomEquipment)
            {
                if (re.equipmentId == entity.equipmentId && re.roomId == entity.roomId)
                {
                    roomEquipment.Remove(re);
                    break;
                }

            }
            roomEquipmentSerializer.toCSV(filename, roomEquipment);
        }
    }
}
