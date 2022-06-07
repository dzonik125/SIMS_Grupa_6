using Model;
using SIMS.Repository;
using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    public class OrderEquipment : Serializable
    {
        public List<Equipment> equipments = new List<Equipment>();


        public int roomDestiantionId { get; set; }
        public DateTime transferDate { get; set; }
        public int quantity { get; set; }

        public void FromCSV(string[] values)
        {
            roomDestiantionId = int.Parse(values[0]);
            transferDate = DateTime.Parse(values[1]);

        }


        public string[] ToCSV()
        {

            string[] csvValues =
            {
                roomDestiantionId.ToString(),
                transferDate.ToString(),
            };
            return csvValues;
        }
    }
}
