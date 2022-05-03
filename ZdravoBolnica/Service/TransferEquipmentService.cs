using Model;
using Repository;
using Service;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service
{
    class TransferEquipmentService
    {
        private EquipmentTransferRepository etr = new EquipmentTransferRepository();
        private RoomService rs = new RoomService();
        private EquipmentService es = new EquipmentService();
        private RoomEquipmentService res = new RoomEquipmentService();
        public void MoveInventory()
        {
            List<EquipmentTransfer> moveEquipment = new List<EquipmentTransfer>();
            moveEquipment = etr.FindAll();
            foreach (EquipmentTransfer et in moveEquipment)
            {
                if (DateTime.Compare(DateTime.Now, et.transferDate) == 0 || DateTime.Compare(et.transferDate, DateTime.Now) < 0)
                {
                   
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        Room rSource = new Room();
                        rSource = rs.FindRoomById(et.roomSourceId);
                        Room rDestionation = new Room();
                        rDestionation = rs.FindRoomById(et.roomDestiantionId);
                        Equipment equip = new Equipment();
                        equip = es.FindEquipmentById(et.equipmentId);
                        res.TransferEquipment(rSource, rDestionation, equip, et.quantity);
                        etr.Remove(et);
                    });
                }    


            }
        }

        public void SaveTransfer(Room roomSource, Room roomDestination, DateTime transferDate, int quantity, Equipment equipment)
        {
            EquipmentTransfer transferEquipment = new EquipmentTransfer();
            transferEquipment.roomSourceId = rs.FindRoomId(roomSource.floor,roomSource.roomNum);
            transferEquipment.roomDestiantionId = rs.FindRoomId(roomDestination.floor, roomDestination.roomNum);
            transferEquipment.transferDate = transferDate;
            transferEquipment.quantity = quantity;
            transferEquipment.equipmentId = equipment.id;
            etr.Create(transferEquipment);
        }
    }
}
