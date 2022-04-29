using Model;
using Repository;
using SIMS.Model;
using SIMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service
{
    public class OccupiedRoomsService
    {
        private OccupiedRoomsRepository orr = new OccupiedRoomsRepository();
        private RoomsCRUD rr = new RoomsCRUD();
        public bool IsRoomOccupied(Room roomDestination, DateTime transferDate, int duration)
        {
            List<OccupiedRooms> occupiedRooms = new List<OccupiedRooms>();
            occupiedRooms = orr.FindAll();

           
            int id = FindRoomId(roomDestination);
            roomDestination.id = id;
            foreach (OccupiedRooms or in occupiedRooms)
            {
                if (or.roomId == roomDestination.id && DateTime.Compare(transferDate, or.date) == 0)
                {
                    return true;
                }
            }


            return false;
        }

        public int FindRoomId(Room roomDestination)
        {
            List<Room> rooms = new List<Room>();
            rooms = rr.FindAll();
            foreach (Room r in rooms)
            {
                if (r.floor == roomDestination.floor && r.roomNum == roomDestination.roomNum)
                {
                    return r.id;
                }
            }
            return 0;
        }
    }
}
