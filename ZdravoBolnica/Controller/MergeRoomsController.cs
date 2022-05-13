using Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller
{
    public class MergeRoomsController
    {
        private MergeRoomsService _mergeRoomsService = new MergeRoomsService();

        public void SaveRoomsMerging(Room room1, Room room2, RoomType roomType, DateTime startTimeRenovation, DateTime endTimeRenovation)
        {
            _mergeRoomsService.SaveRoomMerging(room1, room2, roomType, startTimeRenovation, endTimeRenovation);
        }



    }
}
