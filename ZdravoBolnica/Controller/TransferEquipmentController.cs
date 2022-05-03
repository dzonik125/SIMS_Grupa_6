using Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SIMS.Controller
{
    public class TransferEquipmentController
    {
        private TransferEquipmentService tes = new TransferEquipmentService();
        public void MoveInventory(object state)
        {
            tes.MoveInventory();
        }

        public void SaveTransfer(Room roomSource, Room roomDestination, DateTime transferDate, int quantity, Equipment equipment)
        {
            tes.SaveTransfer(roomSource,roomDestination,transferDate,quantity,equipment);
        }
    }
}
