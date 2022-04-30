using Model;

namespace SIMS.Model
{
    public class Allergies : Serializable
    {
        public int id { get; set; }
        public string name { get; set; }

        public Allergies(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Allergies()
        {
        }

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
                name.ToString(),
            };
            return csvValues;
        }


    }
}
