// File:    AppointmentService.cs
// Author:  dZoNi
// Created: Thursday, April 7, 2022 17:38:26
// Purpose: Definition of Class AppointmentService

using Model;
using Repository;
using SIMS.Util;
using System;
using System.Collections.Generic;

namespace Service
{
    public class AppointmentService
    {
        public PatientService patientService = new PatientService();
        public AppointmentRepository appointmentRepository = new AppointmentRepository();
        public DoctorService doctorService = new DoctorService();


        public List<Appointment> GetAllApointments()
        {
            return appointmentRepository.FindAll();
        }

        public void UpdateAppointment(Appointment appointment)
        {
            appointmentRepository.Update(appointment);
        }

        public void DeleteAppointmentById(int id)
        {
            appointmentRepository.DeleteById(id);
        }

        public void SaveAppointment(Appointment appointment)
        {
            appointmentRepository.Create(appointment);
        }

        public void BindRoomsWithAppointments(List<Room> rooms, List<Appointment> appointments)
        {
            foreach (Room room in rooms)
            {
                foreach (Appointment appointment in appointments)
                {
                    if (appointment.room.id == room.id)
                        appointment.room = room;
                }
            }
        }

        public void BindDoctorsWithAppointments(List<Doctor> doctors, List<Appointment> appointments)
        {
            foreach (Doctor doctor in doctors)
            {
                foreach (Appointment appointment in appointments)
                {
                    if (appointment.doctor.id == doctor.id)
                        appointment.doctor = doctor;
                }
            }
        }

        public void BindPatientsWithAppointments(List<Patient> patients, List<Appointment> appointments)
        {
            foreach (Patient patient in patients)
            {
                foreach (Appointment appointment in appointments)
                {
                    if (appointment.patient.id == patient.id)
                        appointment.patient = patient;
                }
            }
        }



        public List<Appointment> GetFutureAppointmentsForDoctor(int id)
        {
            List<Appointment> futureAppointments = new List<Appointment>();
            foreach (Appointment appointment in GetAllApointments())
            {
                if (appointment.doctor.id == id)
                {
                    if (appointment.startTime.AddMinutes(appointment.duration) >= DateTime.Now)
                        futureAppointments.Add(appointment);
                }
            }
            return futureAppointments;
        }

        public List<Appointment> GetFutureAppointmentsForPatient(int id)
        {
            List<Appointment> futureAppointments = new List<Appointment>();
            foreach (Appointment appointment in GetAllApointments())
            {
                if (appointment.patient.id == id)
                {
                    if (appointment.startTime >= DateTime.Now)
                        futureAppointments.Add(appointment);
                }

            }
            return futureAppointments;
        }

        public List<Appointment> GetAppointmentsForDoctors(List<Doctor> doctors)
        {
            List<Appointment> returnAppointments = new();
            foreach (Doctor doctor in doctors)
            {
                List<Appointment> appointmentsForDoctor = GetAppointmentsByDoctorId(doctor.id);
                returnAppointments.AddRange(appointmentsForDoctor);
            }
            return returnAppointments;
        }

        public Appointment GetFirstFreeAppointmentInOneHour(Scheduler scheduler, Patient patient)
        {
            Appointment firstFree = new Appointment();
            List<Appointment> freeAppointments = FindFreeTermsForReferral(scheduler, patient);
            if (freeAppointments.Count > 0)

                if (freeAppointments.Count > 0)
                {
                    firstFree = freeAppointments[0];
                }
            return firstFree;
        }

        public Appointment GetFirstAppointmentForDoctor(List<Appointment> apps)
        {
            Appointment firstFreeAppointment = new Appointment();
            foreach (Appointment appointment in apps)
            {
                if ((appointment.startTime.CompareTo(DateTime.Now.AddHours(2)) < 0) && appointment.startTime > DateTime.Now)
                    firstFreeAppointment = appointment;
            }
            return firstFreeAppointment;
        }

        public void SaveBusyAppointment(Appointment appointment, Specialization specialization)
        {
            Appointment newAppointment = new Appointment();
            newAppointment = FindFreeAppointmentForPatient(appointment.patient, specialization);
            newAppointment.patient = patientService.FindPatientById(appointment.patient.id);
            newAppointment.duration = 30;
            appointmentRepository.Create(newAppointment);
            UpdateBusyAppointment(appointment);
        }

        private void UpdateBusyAppointment(Appointment busyAppointment)
        {
            Appointment appointmentForUpdate = new Appointment();
            appointmentForUpdate = busyAppointment;
            appointmentForUpdate.patient = busyAppointment.patient;
            appointmentRepository.Update(appointmentForUpdate);
        }

        public Appointment FindFreeAppointmentForPatient(Patient patient, Specialization specialization)
        {
            Scheduler scheduler = new Scheduler();
            scheduler.startTime = DateTime.Now;
            scheduler.endTime = DateTime.Now.AddDays(3);
            scheduler.duration = 30;
            scheduler.specializationType = specialization;
            scheduler.roomType = RoomType.examination;

            List<Appointment> appointments = FindFreeTermsForReferral(scheduler, patient);
            return appointments[0];
        }

        public List<Appointment> FindFreeTermsForReferral(Scheduler scheduler, Patient patient)
        {
            List<Appointment> patientAppointments = GetAllAppointmentsForPatient(patient.id);
            return FindFreeTerms(patientAppointments, scheduler);
        }

        public List<Appointment> GetAllAppointmentsForPatient(int id)
        {
            List<Appointment> patientAppointments = new List<Appointment>();
            foreach (Appointment appointment in GetAllApointments())
            {
                if (appointment.patient.id == id)
                    patientAppointments.Add(appointment);
            }
            return patientAppointments;
        }

        public List<Appointment> FindFreeTerms(List<Appointment> patientAppointments, Scheduler scheduler)
        {
            List<Appointment> potentialAppointments = new();
            while (scheduler.startTime < scheduler.endTime)
            {
                if (!OverlapsWithPatientAppointments(patientAppointments, scheduler))
                {
                    Appointment potentialAppointment = new();
                    if (CheckForRoomAndDoctorForAppointment(potentialAppointment, scheduler))
                        potentialAppointments.Add(potentialAppointment);
                }
                scheduler.step();
            }
            return potentialAppointments;
        }

        public bool OverlapsWithPatientAppointments(List<Appointment> patientAppointments, Scheduler scheduler)
        {
            bool overlapExists = false;
            foreach (Appointment appointment in patientAppointments)
            {
                if (scheduler.overlapsWithExistingTerm(appointment.startTime, appointment.duration))
                    overlapExists = true;
            }
            return overlapExists;
        }

        private bool CheckForRoomAndDoctorForAppointment(Appointment potentialAppointment, Scheduler scheduler)
        {
            RoomService roomService = new RoomService();
            potentialAppointment.startTime = scheduler.startTime;
            bool foundRoomAndDoctorForAppointment = false;
            if (roomService.freeRoomExistsForAppointment(potentialAppointment, scheduler)
                && doctorService.freeDoctorExistsForAppointment(potentialAppointment, scheduler))
                foundRoomAndDoctorForAppointment = true;
            return foundRoomAndDoctorForAppointment;
        }

        public List<Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            return appointmentRepository.FindByDoctorId(doctorId);
        }

        public List<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            return appointmentRepository.FindByPatientId(patientId);
        }

        public List<Appointment> GetAppointmentsByRoomId(int roomId)
        {
            return appointmentRepository.FindByRoomId(roomId);
        }

        public Appointment FindPatientAppointment(Patient patient)
        {
            Appointment patientAppointment = new();
            foreach (Appointment appointment in GetAppointmentsByPatientId(patient.id))
            {
                if (appointment.startTime <= DateTime.Now && appointment.startTime.AddMinutes(appointment.duration) >= DateTime.Now)
                    patientAppointment = appointment;
            }
            return patientAppointment;
        }

    }
}