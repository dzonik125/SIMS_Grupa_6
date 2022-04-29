using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model
{
    public class OccupiedRooms : Serializable
    {
        public DateTime date { get; set; }
        public int roomId { get; set; }

        public int duration { get; set; }

        public void FromCSV(string[] values)
        {
           
            roomId = int.Parse(values[0]);
            date = DateTime.Parse(values[1]);
            duration = int.Parse(values[2]);
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
               roomId.ToString(),
               date.ToString(),
               duration.ToString(),

            };
            return csvValues;
        }
    }
}
