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

        public List<Appointment> getFutureAppointmentsForDoctor(int id)
        {
            return appointmentService.getFutureAppointmentsForDoctor(id);
        }

        public List<Appointment> getFutureAppointmentsForPatient(string id)
        {
            return appointmentService.getFutureAppointmentsForPatient(id);
        }

        public void SaveAppointment(Appointment a)
        {
            appointmentService.SaveAppointment(a);
        }
      
      public bool IntersectionWithAppointments(int patientID, int doctorID, int roomID, DateTime date, int duration)

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



        public Service.AppointmentService appointmentService = new Service.AppointmentService();

    }
}