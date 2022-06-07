// File:    Appointment.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:12:45
// Purpose: Definition of Class Appointment

using SIMS.Model;
using System;
using System.ComponentModel;

namespace Model
{
    public class Appointment : Serializable
    {
        
        public DateTime startTime { get; set; }
        public int duration { get; set; }
        public int id { get; set; }
        public Doctor doctor { get; set; }

        public Room room { get; set; }

        public Patient patient { get; set; }

        public AppointmentType type { get; set; }

        

        public int timesEdited = 0;

        public int TimesEdited
        {
            get => timesEdited;
            set => timesEdited = value;
        }



        public String AppointmentTypeString
        {
            get
            {
                if (type == AppointmentType.examination)
                    return "Pregled";
                else if (type == AppointmentType.surgery)
                {
                    return "Operacija";
                }
                else
                    return "";
            }
        }

        public String GetDoctorName()
        {
            return doctor.FullName;
        }

        public String AppointmentDate { get { return startTime.ToString("dd.MM.yyyy."); } }

        public String AppointmentTime { get { return startTime.ToString("HH:mm"); } }

        public String GetAppoitmentTime()
        {
            return startTime.ToString("HH:mm");
        }

        public DateTime GetEndTime()
        {
            return startTime.AddMinutes(duration);
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                id.ToString(),
                patient.id.ToString(),
                doctor.id.ToString(),
                room.id.ToString(),
                startTime.ToString(),
                duration.ToString(),
                Conversion.AppointmentTypeToString(type),
                timesEdited.ToString(),
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            id = int.Parse(values[0]);
            patient = new Patient();
            patient.id = int.Parse(values[1]);
            doctor = new Doctor();
            doctor.id = int.Parse(values[2]);
            room = new Room();
            room.id = int.Parse(values[3]);
            startTime = DateTime.Parse(values[4]);
            duration = int.Parse(values[5]);
            type = Conversion.StringToAppointmentType(values[6]);
            timesEdited = int.Parse(values[7]);
        }



    }
}