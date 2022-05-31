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
        public List<DateTime> GetTenNextFreeAppointmentsForDoctor(int id)
        {
            return appointmentService.getTenNextFreeAppointmentsForDoctor(id);
        }
        public List<DateTime> GetTenNextFreeAppointmentsForDoctorToday(int id)
        {
            return appointmentService.getTenNextFreeAppointmentsForDoctorToday(id);
        }
        public Appointment GetFirstFreeAppointmentInOneHour(Specialization specialization, Patient patient)
        {
            return appointmentService.getFirstFreeAppointmentInOneHour(specialization, patient);
        }
        public List<Appointment> GetFutureAppointmentsForDoctor(int id)
        {
            return appointmentService.getFutureAppointmentsForDoctor(id);
        }
        public List<Appointment> GetAppointmentsForDoctors(List<Doctor> doctors)
        {
            return appointmentService.getAppointmentsForDoctors(doctors);
        }
        public Appointment GetFirstAppointmentForDoctor(List<Appointment> appointments)
        {
            return appointmentService.getFirstAppointmentForDoctor(appointments);
        }
        public void SaveBusyAppointment(Appointment appointment, Patient patient, Specialization specialization)
        {
            appointmentService.SaveBusyAppointment(appointment, patient, specialization);
        }
        public List<Appointment> GetFutureAppointmentsForPatient(int id)
        {
            return appointmentService.getFutureAppointmentsForPatient(id);
        }
        public List<Appointment> GetAppointmentBySpecialization(Specialization specialization)
        {
            return appointmentService.getAppointmentBySpecialization(specialization);
        }
        public void SaveAppointment(Appointment appointment)
        {
            appointmentService.SaveAppointment(appointment);
        }
        public bool IntersectionWithAppointments(int patientId, int doctorId, int roomId, DateTime date, int duration)
        {
            return appointmentService.IntersectionWithAppointments(patientId, doctorId, roomId, date, duration);
        }
        public Appointment GetAppointmentById(int id)
        {
            throw new NotImplementedException();
        }
        public void BindRoomsWithAppointments(List<Room> rooms, List<Appointment> appointments)
        {
            appointmentService.bindRoomsWithAppointments(rooms, appointments);
        }
        public void BindDoctorsWithAppointments(List<Doctor> doctors, List<Appointment> appointments)
        {
            appointmentService.bindDoctorsWithAppointments(doctors, appointments);
        }
        public bool IsRoomOccupied(Room roomDestination, DateTime transferDate, int duration)
        {
            return appointmentService.isRoomOccupied(roomDestination, transferDate, duration);
        }
        public void BindPatientsWithAppointments(List<Patient> patients, List<Appointment> appointments)
        {
            appointmentService.bindPatientsWithAppointments(patients, appointments);
        }
        public String GetFirstFreeAppointment(DateTime? start, DateTime? finish)
        {
            return appointmentService.getFirstFreeAppointment(start, finish);
        }
        public List<String> GetFirstFiveFreeAppointmentsForDate(DateTime? start, DateTime? end)
        {
            return appointmentService.getFirstFiveFreeApointmentsForDate(start, end);
        }
        public Appointment FindPatientAppointment(Patient patient)
        {
            return appointmentService.findPatientAppointment(patient);
        }
        public List<Appointment> FindAllAppointments()
        {
            return appointmentService.GetAllApointments();
        }
        public List<DateTime> GetTenNextAppointmentsForDoctorForDate(DateTime? start, DateTime? end, int id)
        {
            return appointmentService.getTenNextAppointmentsForDoctorForDate(start, end, id);
        }

    }
}