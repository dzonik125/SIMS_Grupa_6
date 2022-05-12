using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller
{
    class SeparateRoomsController
    {
        private SeparateRoomsService _separateRoomsService = new SeparateRoomsService();
        public void SaveFutureRenovationForRoomSeparation(SeparateRooms separateRooms)
        {
            _separateRoomsService.SaveFutureRenovationForRoomSeparation(separateRooms);
        }
    }
}
