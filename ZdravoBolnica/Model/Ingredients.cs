using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model
{
    public class Ingredients : Serializable
    {
        public string name { get; set; }

        public void FromCSV(string[] values)
        {
            name = values[0];
        }

        public string[] ToCSV()
        {
            string[] csvValues =
         {
                name,
            };
            return csvValues;
        }
    }
}
