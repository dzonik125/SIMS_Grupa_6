// File:    AppointmentController.cs
// Author:  dZoNi
// Created: Thursday, April 7, 2022 18:38:45
// Purpose: Definition of Class AppointmentController

using Model;
using SIMS.Util;
using System;
using System.Collections.Generic;


namespace Controller
{
    public class AppointmentController
    {
        private readonly Service.AppointmentService appointmentService = new Service.AppointmentService();
        public List<Appointment> GetAllAppointmentsForPatient(int id)
        {
            return appointmentService.GetAllAppointmentsForPatient(id);
        }
        public List<Appointment> GetAllAppointments()
        {
            return appointmentService.GetAllApointments();
        }
        public void UpdateAppointment(Appointment a)
        {
            appointmentService.UpdateAppointment(a);
        }
        public void DeleteAppointmentById(int id)
        {
            appointmentService.DeleteAppointmentById(id);
        }

        public Appointment GetFirstFreeAppointmentInOneHour(Scheduler scheduler, Patient patient)
        {
            return appointmentService.GetFirstFreeAppointmentInOneHour(scheduler, patient);
        }
        public List<Appointment> GetFutureAppointmentsForDoctor(int id)
        {
            return appointmentService.GetFutureAppointmentsForDoctor(id);
        }
        public List<Appointment> GetAppointmentsForDoctors(List<Doctor> doctors)
        {
            return appointmentService.GetAppointmentsForDoctors(doctors);
        }
        public Appointment GetFirstAppointmentForDoctor(List<Appointment> appointments)
        {
            return appointmentService.GetFirstAppointmentForDoctor(appointments);
        }
        public void SaveBusyAppointment(Appointment appointment, Specialization specialization)
        {
            appointmentService.SaveBusyAppointment(appointment, specialization);
        }

        public Appointment FindFreeAppointmentForPatient(Patient patient, Specialization specialization)
        {
            return appointmentService.FindFreeAppointmentForPatient(patient, specialization);
        }
        public List<Appointment> GetFutureAppointmentsForPatient(int id)
        {
            return appointmentService.GetFutureAppointmentsForPatient(id);
        }
        public void SaveAppointment(Appointment appointment)
        {
            appointmentService.SaveAppointment(appointment);
        }
        public Appointment GetAppointmentById(int id)
        {
            throw new NotImplementedException();
        }
        public void BindRoomsWithAppointments(List<Room> rooms, List<Appointment> appointments)
        {
            appointmentService.BindRoomsWithAppointments(rooms, appointments);
        }
        public void BindDoctorsWithAppointments(List<Doctor> doctors, List<Appointment> appointments)
        {
            appointmentService.BindDoctorsWithAppointments(doctors, appointments);
        }

        public void BindPatientsWithAppointments(List<Patient> patients, List<Appointment> appointments)
        {
            appointmentService.BindPatientsWithAppointments(patients, appointments);
        }

        public Appointment FindPatientAppointment(Patient patient)
        {
            return appointmentService.FindPatientAppointment(patient);
        }
        public List<Appointment> FindAllAppointments()
        {
            return appointmentService.GetAllApointments();
        }

    }
}