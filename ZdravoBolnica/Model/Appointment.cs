// File:    Appointment.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:12:45
// Purpose: Definition of Class Appointment

using Repository;
using SIMS.Model;
using System;
using System.ComponentModel;

namespace Model
{
    public class Appointment : Serializable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public RoomsCRUD roomRepository = new RoomsCRUD();
        protected virtual void OnPropertyChanged(string s)
        {

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(s));
            }
        }
        public DateTime startTime { get; set; }
        public int duration { get; set; }
        public int id { get; set; }
        public Doctor Doctor { get; set; }

        public Room Room { get; set; }

        public Patient patient { get; set; }

        public AppointmentType Type { get; set; }

        public int timesEdited = 0;

        public int TimesEdited
        {
            get => timesEdited;
            set => timesEdited = value;
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

        public DateTime GetAppointmentEndTime
        {
            get { return startTime.AddMinutes(duration); }
        }



        public String AppointmentTypeString
        {
            get
            {
                if (Type == AppointmentType.examination)
                    return "Pregled";
                else if (Type == AppointmentType.surgery)
                {
                    return "Operacija";
                }
                else
                    return "";
            }
        }

        public String GetDoctorName()
        {
            return Doctor.FullName;
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                id.ToString(),
                patient.id.ToString(),
                Doctor.id.ToString(),
                Room.id.ToString(),
                startTime.ToString(),
                duration.ToString(),
                Conversion.AppointmentTypeToString(Type),
                timesEdited.ToString(),
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            id = int.Parse(values[0]);
            patient = new Patient();
            patient.id = int.Parse(values[1]);
            Doctor = new Doctor();
            Doctor.id = int.Parse(values[2]);
            Room = roomRepository.FindById(int.Parse(values[3]));
            startTime = DateTime.Parse(values[4]);
            duration = int.Parse(values[5]);
            Type = Conversion.StringToAppointmentType(values[6]);
            timesEdited = int.Parse(values[7]);
        }



    }
}