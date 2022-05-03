using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model
{
    public class ExaminationReport : Serializable
    {
        public int id { get; set; }
        public Doctor doctor { get; set; }
        public String mainProblems { get; set; }
        public String diagnosis { get; set; }
        public String anamnesis { get; set; }
        public Appointment appointment { get; set; }
        public MedicalRecord medicalRecord { get; set; }
        public DateTime reportDate { get; set; }

        public string treatmentPlan { get; set; }

        public void FromCSV(string[] values)
        {
            id = int.Parse(values[0]);
            doctor = new Doctor();
            doctor.id = int.Parse(values[1]);
            medicalRecord = new MedicalRecord();
            medicalRecord.id = int.Parse(values[2]);
            mainProblems = values[3];
            diagnosis = values[4];
            anamnesis = values[5];
            reportDate = DateTime.Parse(values[6]);
            treatmentPlan = values[7];
            appointment = new Appointment();
            appointment.id = int.Parse(values[8]);
        }

        public string[] ToCSV()
        {
            String[] csvValues =
            {
                id.ToString(),
                doctor.id.ToString(),
                medicalRecord.id.ToString(),
                mainProblems,
                diagnosis,
                anamnesis,
                reportDate.ToString(),
                treatmentPlan,
                appointment.id.ToString(),
            };
            return csvValues;
        }
    }
}
