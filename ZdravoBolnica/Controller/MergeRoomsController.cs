using Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Model;

namespace SIMS.Controller
{
    public class MergeRoomsController
    {
        private MergeRoomsService _mergeRoomsService = new MergeRoomsService();

        public void SaveRoomsMerging(Room room1, Room room2, RoomType roomType, DateTime startTimeRenovation, DateTime endTimeRenovation)
        {
            MergeRooms mergeRooms = new MergeRooms();
            mergeRooms.roomId1 = room1.id;
            mergeRooms.roomId2 = room2.id;
            mergeRooms.endDate = endTimeRenovation;
            mergeRooms.startDate = startTimeRenovation;
            mergeRooms.newRoomType = roomType;
            _mergeRoomsService.SaveRoomMerging( mergeRooms);
        }



    }
}
