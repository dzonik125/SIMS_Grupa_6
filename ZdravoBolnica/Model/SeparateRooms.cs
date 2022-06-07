using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model
{
    public class SeparateRooms : Serializable
    {
        public Room roomOne { get; set; }
        public Room roomTwo { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public void FromCSV(string[] values)
        {
            roomOne = new Room();
            roomTwo = new Room();
            roomOne.id = int.Parse(values[0]);
            roomOne.roomType = Conversion.StringToRoomType(values[3]);
            roomTwo.id = int.Parse(values[2]);
            roomTwo.roomNum = int.Parse(values[3]);
            roomTwo.roomType = Conversion.StringToRoomType(values[4]);
            startDate = DateTime.Parse(values[5]);
            endDate = DateTime.Parse(values[6]);
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                  roomOne.id.ToString(),
                  Conversion.RoomTypeToString(roomOne.roomType),
                  roomTwo.id.ToString(),
                  roomTwo.roomNum.ToString(),
                  Conversion.RoomTypeToString(roomTwo.roomType),
                  startDate.ToString(),
                  endDate.ToString()


            };
            return csvValues;
          
        }
    }
}
