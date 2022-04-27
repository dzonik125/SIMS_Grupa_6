using Model;
using SIMS.Model;
using SIMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service
{
    public class RoomEquipmentService
    {
        private RoomEquipmentRepository rer = new RoomEquipmentRepository();
        public void setRoomEquipment(int id, List<Equipment> equipmentlist)
        {
            rer.setRoomEquipment(id, equipmentlist);
        }

        public List<RoomEquipment> FindAll()
        {
            return rer.FindAll();
        }

        public int getQuantityByRoomId(int id, int roomId)
        {
            return rer.GetQuantityByRoomId(id, roomId);
        }

        public List<Equipment> GetRoomEquipment(List<Equipment> allInventory, List<RoomEquipment> roomEquipment, int roomId)
        {
            List<Equipment> roomInventory = new List<Equipment>();
            foreach (Equipment e in allInventory)
                {
                e.RoomNum = new List<int>();
                foreach (RoomEquipment re in roomEquipment)
                {

                    if (e.id == re.equipmentId)
                    {

                        e.RoomNum.Add(re.roomId);
                        e.quantity = getQuantityByRoomId(e.id, re.roomId);
                    }
                }
            }

            foreach (Equipment e in allInventory)
            {
                if (e.RoomNum != null)
                {
                    foreach (int rn in e.RoomNum)
                    {
                        if (rn == roomId)
                        {
                            roomInventory.Add(e);
                        }
                    }

                }
            }

            return roomInventory;

        }
    }
}
