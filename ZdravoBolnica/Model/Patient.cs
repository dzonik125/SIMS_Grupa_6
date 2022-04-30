// File:    Patient.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:12:49
// Purpose: Definition of Class Patient

namespace Model
{
    public class Patient : Account, Serializable
    {
        public string lbo { get; set; }
        public Adress address { get; set; }

        public bool guest { get; set; }

        public MedicalRecord medicalRecord;
        public System.Collections.Generic.List<Appointment> appointment;

        public System.Collections.Generic.List<Appointment> Appointment
        {
            get
            {
                if (appointment == null)
                    appointment = new System.Collections.Generic.List<Appointment>();
                return appointment;
            }
            set
            {
                RemoveAllAppointment();
                if (value != null)
                {
                    foreach (Appointment oAppointment in value)
                        AddAppointment(oAppointment);
                }
            }
        }


        public void AddAppointment(Appointment newAppointment)
        {
            if (newAppointment == null)
                return;
            if (this.appointment == null)
                this.appointment = new System.Collections.Generic.List<Appointment>();
            if (!this.appointment.Contains(newAppointment))
            {
                this.appointment.Add(newAppointment);
                newAppointment.patient = this;
            }
        }


        public void RemoveAppointment(Appointment oldAppointment)
        {
            if (oldAppointment == null)
                return;
            if (this.appointment != null)
                if (this.appointment.Contains(oldAppointment))
                {
                    this.appointment.Remove(oldAppointment);
                    oldAppointment.patient = null;
                }
        }


        public void RemoveAllAppointment()
        {
            if (appointment != null)
            {
                System.Collections.ArrayList tmpAppointment = new System.Collections.ArrayList();
                foreach (Appointment oldAppointment in appointment)
                    tmpAppointment.Add(oldAppointment);
                appointment.Clear();
                foreach (Appointment oldAppointment in tmpAppointment)
                    oldAppointment.patient = null;
                tmpAppointment.Clear();
            }
        }

        public string[] ToCSV()
        {
            string[] csvValues =
           {
                id.ToString(),
                name.ToString(),
                surname.ToString(),
                email.ToString(),
                password.ToString(),
                username.ToString(),
                address.id.ToString(),
                phone.ToString(),
                lbo.ToString(),
                jmbg,
                birthdate.ToString(),
                guest.ToString(),
                medicalRecord.id.ToString(),

            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            medicalRecord = new MedicalRecord();
            address = new Adress();
            id = int.Parse(values[0]);
            name = values[1];
            surname = values[2];
            email = values[3];
            password = values[4];
            username = values[5];
            address.id = values[6];
            phone = values[7];
            lbo = values[8];
            jmbg = values[9];
            birthdate = values[10];
            guest = bool.Parse(values[11]);
            medicalRecord.id = int.Parse(values[12]);
        }
    }
}