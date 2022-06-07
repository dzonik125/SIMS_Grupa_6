using Model;
using SIMS.Repository;
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
        public string name { get; set; }
        public List<int> medicationReplacementIds = new List<int>();
        public List<Ingredients> components = new List<Ingredients>();
        public MedicationStatusType status { get; set; }
        public int Amount { get; set; }

        public string ids = "";
        public string componentsName = "";
        public string comment { get; set; }

        public String MedicationStatusTypeString
        {
            get
            {
                if (status == MedicationStatusType.accepted)
                    return "Odobreno";
                else if (status == MedicationStatusType.waiting)
                    return "Na cekanju";
                else if (status == MedicationStatusType.rejected)
                    return "Odbijeno";
                else
                    return "Na cekanju";
            }
        }
        

        public void FromCSV(string[] values)
        {
            id = int.Parse(values[0]);
            name = values[1];
            status = Conversion.StringToMedicationStatusType(values[2]);
            Amount = int.Parse(values[3]);
            List<int> idsMed = new List<int>();
            if (values[4] != "")
            {
                string[] parts = values[4].Split(',');
                foreach (string s in parts)
                {
                    idsMed.Add(int.Parse(s));
                }
                foreach (int i in idsMed)
                {
                    medicationReplacementIds.Add(i);
                }

            }
            List<string> componentsN = new List<string>();
            if (values[5] != "")
            {
                string[] parts = values[5].Split(',');
                foreach (string s in parts)
                {
                    componentsN.Add(s);
                }
                foreach(string s in componentsN)
                {
                    components.Add(ir.FindById(s));
                }
            }
            comment = values[6];

            }

            public string[] ToCSV()
        {
            foreach (int m in medicationReplacementIds)
            {
                ids = ids + m + ",";
            }
            if (ids != "")
            {
                ids = ids.Remove(ids.Length - 1, 1);
            }
            foreach (Ingredients i in components)
            {
                componentsName = componentsName + i.name + ",";
            }
            if (componentsName != "")
            {
                componentsName = componentsName.Remove(componentsName.Length - 1, 1);
            }


            string[] csvValues =
            {

                
                id.ToString(),
                name,
                Conversion.MedicationStatusTypeToString(status),
                Amount.ToString(),
                ids.ToString(),
                componentsName.ToString(),
                comment.ToString(),


            };
            return csvValues;


        }
        private MedicationRepository mr = new MedicationRepository();
        private IngredientsRepository ir = new IngredientsRepository();
    }
}
