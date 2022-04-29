using Model;
using Repository;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller
{
    public class RoomEquipmentController
    {
        private RoomEquipmentService res = new RoomEquipmentService();
        public void setRoomEquipment(int id, List<Equipment> equipmentlist)
        {
            res.setRoomEquipment(id, equipmentlist);
        }
        public List<RoomEquipment> FindAll()
        {
            return res.FindAll();
        }

        public List<Equipment> GetRoomEquipment(List<Equipment> allInventory, List<RoomEquipment> roomEquipment, int roomId)
        {
            return res.GetRoomEquipment(allInventory, roomEquipment, roomId);
        }

        public void TransferEquipment(Room roomSource, Room roomDestination , Equipment selectedEquipment, int quantity)
        {
            res.TransferEquipment(roomSource,roomDestination, selectedEquipment, quantity);
        }
    }
}
