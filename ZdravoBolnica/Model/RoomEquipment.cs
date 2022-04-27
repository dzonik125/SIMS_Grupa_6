using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model
{
   public class RoomEquipment : Serializable
    {
        public int equipmentId { get; set; }
        public int roomId { get; set; }
        public int quantity { get; set; }

        public string[] ToCSV()
        {

            string[] csvValues =
            {
               equipmentId.ToString(),
               roomId.ToString(),
               quantity.ToString(),

            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            equipmentId = int.Parse(values[0]);
            roomId = int.Parse(values[1]);
            quantity = int.Parse(values[2]);
    
        }
    }
}
