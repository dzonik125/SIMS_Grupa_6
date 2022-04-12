// File:    Patient.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:12:49
// Purpose: Definition of Class Patient

using System;

namespace Model
{
   public class Patient : Account, Serializable
   {
      public String lbo;
      
      public MedicalRecord medicalRecord;
      public System.Collections.Generic.List<Appointment> appointment;
      
      /// <summary>
      /// Property for collection of Appointment
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
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
      
      /// <summary>
      /// Add a new Appointment in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
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
      
      /// <summary>
      /// Remove an existing Appointment from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
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
      
      /// <summary>
      /// Remove all instances of Appointment from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
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
                id,
                lbo,
                name,
                surname,
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            id = values[0];
            lbo = values[1];
            name = values[2];
            surname = values[3];
        }
    }
}