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

        public void DeleteAppointmentById(int id)
        {
            appointmentService.DeleteAppointmentById(id);
        }

        public List<DateTime> getTenNextFreeAppointmentsForDoctor(int id)
        {
            return appointmentService.getTenNextFreeAppointmentsForDoctor(id);
        }

        public List<DateTime> getTenNextFreeAppointmentsForDoctorToday(int id)
        {
            return appointmentService.getTenNextFreeAppointmentsForDoctorToday(id);
        }

        public List<Appointment> getFutureAppointmentsForDoctor(int id)
        {
            return appointmentService.getFutureAppointmentsForDoctor(id);
        }

        public Appointment getFirstFuture(List<Appointment> apps)
        {
            return appointmentService.getFirstFuture(apps);
        }

        public List<Appointment> getFutureAppointmentsForPatient(string id)
        {
            return appointmentService.getFutureAppointmentsForPatient(id);
        }

        public List<Appointment> getAppointmentBySpecialization(Specialization s)
        {
            return appointmentService.getAppointmentBySpecialization(s);
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

        public bool isRoomOccupied(Room roomDestination, DateTime transferDate, int duration)
        {
            return appointmentService.isRoomOccupied(roomDestination, transferDate, duration);
        }

        public void bindPatientsWithAppointments(List<Patient> patients, List<Appointment> appointments)
        {
            appointmentService.bindPatientsWithAppointments(patients, appointments);
        }

        public String getFirstFreeAppointment(DateTime? start, DateTime? finish)
        {
            return appointmentService.getFirstFreeAppointment(start, finish);
        }

        public List<String> getFirstFiveFreeApointmentsForDate(DateTime? start, DateTime? end)
        {
            return appointmentService.getFirstFiveFreeApointmentsForDate(start, end);
        }


        public Appointment findPatientAppointment(Patient p)
        {
            return appointmentService.findPatientAppointment(p);
        }

        public List<Appointment> findAllAppointments()
        {
            return appointmentService.GetAllApointments();
        }

        public List<DateTime> getTenNextAppointmentsForDoctorForDate(DateTime? start, DateTime? end, int id)
        {
            return appointmentService.getTenNextAppointmentsForDoctorForDate(start, end, id);
        }

        public Boolean IsExist(int id)
        {
            return appointmentService.IsExist(id);
        }


        public Service.AppointmentService appointmentService = new Service.AppointmentService();

    }
}