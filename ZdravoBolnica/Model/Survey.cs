using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace SIMS.Model
{
    public class Survey : Serializable, INotifyPropertyChanged
    {

        public int id { get; set; }
        public DateTime sentToUser { get; set; }
        public DateTime? completed { get; set; }

        public Patient patient { get; set; }

        public double avg { get; set; }

        public String displayName
        {
            get
            {

                if (id == 1)
                {
                    return "Anketa o bolnici";
                }

                return "Anketa za pregled: " + sentToUser.AddMinutes(-30).ToString();
            }
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                sentToUser.ToString(),
                completed.ToString(),
                id.ToString(),
                avg.ToString(),
            };

            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            sentToUser = DateTime.Parse(values[0]);
            completed = DateTime.Parse(values[1]);
            id = Int32.Parse(values[2]);
            avg = double.Parse(values[3]);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
