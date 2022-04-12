// File:    PatientAppointmentService.cs
// Author:  dZoNi
// Created: Thursday, April 7, 2022 17:48:18
// Purpose: Definition of Class PatientAppointmentService


using System;
using System.Collections.Generic;
using Model;

namespace Service
{
   public class PatientAppointmentService
   {
      public List<Appointment> GetPatientAppointments(Patient p)
      {
         throw new NotImplementedException();
      }
      
      public int GetNumberOfFinishedAppointments(Patient p)
      {
         throw new NotImplementedException();
      }
      
      public List<Appointment> GetPastAppointmentsForPatient(Patient p)
      {
         throw new NotImplementedException();
      }
      
      public List<Appointment> GetFutureAppointments(Patient p)
      {
         throw new NotImplementedException();
      }
      
      public Repository.AppointmentRepository appointmentRepository;
   
   }
}