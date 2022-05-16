using Model;
using SIMS.Repository;
using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    public class OrderEquipment : Serializable
    {
        public List<Equipment> equipments = new List<Equipment>();
        public string ids = "";
        public string q = "";

        private EquipmentRepository er = new EquipmentRepository();
        private EquipmentForOrderRepository efo = new EquipmentForOrderRepository();
        public int roomDestiantionId { get; set; }
        public DateTime transferDate { get; set; }
        public int quantity { get; set; }
        //    public int equipmentId { get; set; }

        public void FromCSV(string[] values)
        {
            roomDestiantionId = int.Parse(values[0]);
            transferDate = DateTime.Parse(values[1]);
            List<int> q = new List<int>();
            if (values[2] != "")
            {
                string[] parts = values[2].Split(',');

                foreach (string s in parts)
                {
                    q.Add(Convert.ToInt32(s));
                }
                foreach (int i in q)
                {
                    equipments.Add(efo.FindById(i));
                }
            }

            List<int> ids = new List<int>();
            if (values[3] != "")
            {
                string[] parts = values[3].Split(',');

                foreach (string s in parts)
                {
                    ids.Add(Convert.ToInt32(s));
                }
                foreach (int i in ids)
                {
                    equipments.Add(efo.FindById(i));
                }
            }

        }


        public string[] ToCSV()
        {
            foreach (Equipment e in equipments)
            {
                ids = ids + e.id + ",";
            }
            if (ids != "")
            {
                ids = ids.Remove(ids.Length - 1, 1);
            }

            foreach (Equipment e in equipments)
            {
                q = q + e.quantity + ",";
            }
            if (q != "")
            {
                q = q.Remove(q.Length - 1, 1);
            }

            string[] csvValues =
            {
                roomDestiantionId.ToString(),
                transferDate.ToString(),
                q.ToString(),
                ids.ToString(),
            };
            return csvValues;
        }
    }
}
