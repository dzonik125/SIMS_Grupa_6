using Model;
using System;

namespace SIMS.Model
{
    public class Ingredients : Serializable
    {
        public int id;
        public string name { get; set; }

        public void FromCSV(string[] values)
        {
            id = Convert.ToInt32(values[0]);
            name = values[1];
        }

        public string[] ToCSV()
        {
            string[] csvValues =
         {
                id.ToString(),
                name,
            };
            return csvValues;
        }
    }
}
