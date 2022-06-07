using Model;

namespace SIMS.Model
{
    public class Allergen : Serializable
    {
        public int id { get; set; }
        public string name { get; set; }

        public Allergen(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Allergen()
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
