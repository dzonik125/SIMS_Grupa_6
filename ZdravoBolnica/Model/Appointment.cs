// File:    Appointment.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:12:45
// Purpose: Definition of Class Appointment

using System;
using System.Collections.Generic;
using System.ComponentModel;

using SIMS.Model;

namespace Model
{
    public class Appointment : Serializable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string s) {

            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(s));
            }
        }
        public DateTime startTime { get; set; }
        public int duration { get; set; }
        public string id { get; set; }


        public String AppointmentDate { get { return startTime.ToString("dd.MM.yyyy."); } }

        public String AppointmentTime { get { return startTime.ToString("HH:mm"); } }

        public string patientID { get; set; }
        public string doctorID
        {
            get; set;
        }
        public string roomID { get; set; }
        


        public AppointmentType Type { get; set; }

        public String AppointmentTypeString
        {
            get
            {
                if (Type == AppointmentType.examination)
                    return "Pregled";
                else
                    return "Operacija";
            }
        }
        

        public String GetDoctorName()
        {
            return Doctor.FullName;
        }

        public string Duration { get; set; }
             
      
      public Doctor Doctor
      {
            get;
            set;
      }
     
      
   
      public Room Room { get; set; }
      
      public Patient patient { get; set;}
    

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                id,
                patientID,
                doctorID,
                roomID,
                startTime.ToString(),
                duration.ToString(),
                Conversion.AppointmentTypeToString(Type),

            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            id = values[0];
            patientID = values[1];
            doctorID = values[2];
            roomID = values[3];
            startTime = DateTime.Parse(values[4]);
            duration = int.Parse(values[5]);
            Type = Conversion.StringToAppointmentType(values[6]);
        }

        

    }
}