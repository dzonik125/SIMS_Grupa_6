using Model;
using Repository;
using Service;
using SIMS.Model;
using SIMS.Repository;
using System;
using System.Collections.Generic;

namespace SIMS.Service
{
    class TransferEquipmentService
    {
        private EquipmentTransferRepository etr = new EquipmentTransferRepository();
        private OrderEquipmentRepository oer = new OrderEquipmentRepository();
        private RoomService rs = new RoomService();
        private RoomEquipmentService res = new RoomEquipmentService();
        public void MoveInventory()
        {
            foreach (EquipmentTransfer et in etr.FindAll())
            {
                if (DateTime.Compare(DateTime.Now, et.transferDate) == 0 || DateTime.Compare(et.transferDate, DateTime.Now) < 0)
                {
                    InvokeTimer(et);
                }
            }
        }

        private void InvokeTimer(EquipmentTransfer et)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                res.TransferEquipment(et);
                etr.Remove(et);
            });
        }


        public void SaveTransfer(Room roomSource, Room roomDestination, DateTime transferDate, int quantity, Equipment equipment)
        {
            EquipmentTransfer transferEquipment = new EquipmentTransfer();
            transferEquipment.roomSourceId = rs.FindRoomId(roomSource.floor, roomSource.roomNum);
            transferEquipment.roomDestiantionId = rs.FindRoomId(roomDestination.floor, roomDestination.roomNum);
            transferEquipment.transferDate = transferDate;
            transferEquipment.quantity = quantity;
            transferEquipment.equipmentId = equipment.id;
            etr.Create(transferEquipment);
        }
    }
}
