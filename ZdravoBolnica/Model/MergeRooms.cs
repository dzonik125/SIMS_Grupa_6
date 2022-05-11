using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model
{
    public class MergeRooms : Serializable
    {
        public int roomId1 { get; set; }
        public int roomId2 { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public RoomType newRoomType { get; set; }

        public void FromCSV(string[] values)
        {
            roomId1 = int.Parse(values[0]);
            roomId2 = int.Parse(values[1]);
            newRoomType = Conversion.StringToRoomType(values[2]);
            startDate = DateTime.Parse(values[3]);
            endDate = DateTime.Parse(values[4]);

        }

        public string[] ToCSV()
        {
            string[] csvValues =
          {
               roomId1.ToString(),
               roomId2.ToString(),
               Conversion.RoomTypeToString(newRoomType),
               startDate.ToString(),
               endDate.ToString()
            };
            return csvValues;
        }
    }
}
