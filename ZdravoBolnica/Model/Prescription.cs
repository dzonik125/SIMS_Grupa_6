﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model
{
    public class Prescription : Serializable
    {
        public int id;
        public Medication medication { get; set; }
        public Doctor doctor { get; set; }
        public MedicalRecord medicalRecord;
        public DateTime startTime;
        public DateTime endTime;
        public String comment;
        public int timesPerDay;
        public DateTime prescriptionDate { get; set; }

        public void FromCSV(string[] values)
        {
            id = int.Parse(values[0]);
            medication = new Medication();
            medication.id = int.Parse(values[1]);
            doctor = new Doctor();
            doctor.id = int.Parse(values[2]);
            medicalRecord = new MedicalRecord();
            medicalRecord.id = int.Parse(values[3]);
            startTime = DateTime.Parse(values[4]);
            endTime = DateTime.Parse(values[5]);
            comment = values[6];
            timesPerDay = int.Parse(values[7]);
            prescriptionDate = DateTime.Parse(values[8]);
        }

        public string[] ToCSV()
        {
            String[] values =
            {
                id.ToString(),
                medication.id.ToString(),
                doctor.id.ToString(),
                medicalRecord.id.ToString(),
                startTime.ToString(),
                endTime.ToString(),
                comment,
                timesPerDay.ToString(),
                prescriptionDate.ToString(),
            };
            return values;
        }
    }
}
