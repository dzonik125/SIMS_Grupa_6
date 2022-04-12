// File:    ScheduleAppointmentController.cs
// Author:  dZoNi
// Created: Thursday, April 7, 2022 18:38:45
// Purpose: Definition of Class ScheduleAppointmentController

using System;
using System;
using System.Collections.Generic;
using Model;

namespace Controller
{
   public class ScheduleAppointmentController
   {
      private List<Appointment> GetScheduledAppointmentsForDate(DateTime d)
      {
         throw new NotImplementedException();
      }
      
      public bool CancelAppointment(Appointment a)
      {
         throw new NotImplementedException();
      }
      
      public bool ChangeAppointment(Appointment a)
      {
         throw new NotImplementedException();
      }
      
      public List<String> GetAvailableTimeOfAppointment()
      {
         throw new NotImplementedException();
      }
      
      public bool ScheduleAppointment()
      {
         throw new NotImplementedException();
      }
      
      public Service.ScheduleAppointmentService scheduleAppointmentService;
   
   }
}