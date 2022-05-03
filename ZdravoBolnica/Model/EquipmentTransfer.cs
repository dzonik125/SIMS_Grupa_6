using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model
{
   public class EquipmentTransfer : Serializable
    {
        public int roomSourceId { get; set; }
        public int roomDestiantionId { get; set; }
        public DateTime transferDate { get; set; }
        public int quantity { get; set; }
        public int equipmentId { get; set; }

        public void FromCSV(string[] values)
        {
            roomSourceId = int.Parse(values[0]);
            roomDestiantionId = int.Parse(values[1]);
            transferDate = DateTime.Parse(values[2]);
            equipmentId = int.Parse(values[3]);
            quantity = int.Parse(values[4]);
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                roomSourceId.ToString(),
                roomDestiantionId.ToString(),
                transferDate.ToString(),
                equipmentId.ToString(),
                quantity.ToString(),


            };
            return csvValues;
        }
    }
}
