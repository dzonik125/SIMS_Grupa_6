using Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller
{
    public class OccupiedRoomsController
    {
        private OccupiedRoomsService ors = new OccupiedRoomsService();
        public bool IsRoomOccupied(Room roomDestination, DateTime transferDate, int duration)
        {
           return ors.IsRoomOccupied(roomDestination, transferDate, duration);
        }
    }
}
