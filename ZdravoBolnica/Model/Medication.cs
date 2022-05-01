using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model
{
    public class Medication : Serializable
    {
        public int id { get; set; }
        public String name { get; set; }

        public void FromCSV(string[] values)
        {
            id = int.Parse(values[0]);
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
