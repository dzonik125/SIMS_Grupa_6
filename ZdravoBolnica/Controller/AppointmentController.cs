// File:    AppointmentController.cs
// Author:  dZoNi
// Created: Thursday, April 7, 2022 18:38:45
// Purpose: Definition of Class AppointmentController

using Model;
using System;
using System.Collections.Generic;


namespace Controller
{
   public class AppointmentController
   {
      public List<Appointment> GetAllApointments()
      {

            return appointmentService.GetAllApointments();
      }
      
      public void UpdateAppointment(Appointment a)
      {
            appointmentService.UpdateAppointment(a);
      }
      
      public void DeleteAppointmentById(string id)
      {
            appointmentService.DeleteAppointmentById(id);
      }
      
      public List<Appointment> getFutureAppointmentsForDoctor(string id)
        {
            return appointmentService.getFutureAppointmentsForDoctor(id);
        }

      public void SaveAppointment(Appointment a)
      {
            appointmentService.SaveAppointment(a);
      }
      
      public bool IntersectionWithAppointments(string patientID, string doctorID, string roomID, DateTime date, int duration)
        {
            return appointmentService.IntersectionWithAppointments(patientID, doctorID, roomID, date, duration);
        }

      public Appointment GetAppointmentByID(int id)
      {
         throw new NotImplementedException();
      }

      public void bindRoomsWithAppointments(List<Room> rooms, List<Appointment> appointments) 
        {
            appointmentService.bindRoomsWithAppointments(rooms, appointments);
        }

        public void bindDoctorsWithAppointments(List<Doctor> doctors, List<Appointment> appointments)
        {
            appointmentService.bindDoctorsWithAppointments(doctors, appointments);
        }

        public void bindPatientsWithAppointments(List<Patient> patients, List<Appointment> appointments)
        {
            appointmentService.bindPatientsWithAppointments(patients, appointments);
        }


        public Service.RoomService roomService = new();
        public Service.AppointmentService appointmentService = new Service.AppointmentService();
        
   }
}