// File:    AppointmentService.cs
// Author:  dZoNi
// Created: Thursday, April 7, 2022 17:38:26
// Purpose: Definition of Class AppointmentService

using Model;
using Repository;
using System;
using System.Collections.Generic;
using SIMS;

namespace Service
{
   public class AppointmentService
   {
      public List<Appointment> GetAllApointments()
      {
            return appointmentRepository.FindAll();
      }
      
      public void UpdateAppointment(Appointment a)
      {
            appointmentRepository.Update(a);
      }
      
      public void DeleteAppointmentById(string id)
      {
            appointmentRepository.DeleteById(id);
        }
      
      public void SaveAppointment(Appointment a)
      {
            appointmentRepository.Create(a);
      }

        public void bindRoomsWithAppointments(List<Room> rooms, List<Appointment> appointments)
        {
            foreach (Room r in rooms)
            {
                foreach (Appointment a in appointments)
                {
                    if (a.roomID == r.id)
                    {
                        a.Room = r;
                    }
                }
            }
            
        }

        public void bindDoctorsWithAppointments(List<Doctor> doctors, List<Appointment> appointments)
        {
            foreach (Doctor d in doctors)
            {
                foreach (Appointment a in appointments)
                {
                    if (a.doctorID == d.id)
                    {
                        a.Doctor = d;
                    }
                }
            }
        }

        public void bindPatientsWithAppointments(List<Patient> patients, List<Appointment> appointments)
        {
            foreach (Patient p in patients)
            {
                foreach (Appointment a in appointments)
                {
                    if (a.patientID == p.id)
                    {
                        a.patient = p;
                    }
                    
                }
            }
        }

        public List<Appointment> getFutureAppointmentsForDoctor(string id)
        {
            List<Appointment> potentialAppointments = GetAllApointments();
            List<Appointment> futureAppointments = new List<Appointment>();
            foreach (Appointment a in potentialAppointments)
            {
                if (a.doctorID.Equals(id))
                {
                    if (a.startTime >= DateTime.Now)
                    {

                        futureAppointments.Add(a);
                        
                    }
                }
            }
            return futureAppointments;
        }

        public List<Appointment> getFutureAppointmentsForPatient(string id)
        {
            List<Appointment> potentialAppointments = GetAllApointments();
            List<Appointment> futureAppointments = new List<Appointment>();
            foreach (Appointment a in potentialAppointments)
            {
                if (a.patientID.Equals(id))
                {
                    if (a.startTime >= DateTime.Now)
                    {

                        futureAppointments.Add(a);

                    }

                }

                

            }

            return futureAppointments;

        }

        public List<Appointment> getAppointmentsByDoctorId(string doctorID)
        {
            return appointmentRepository.FindByDoctorId(doctorID);
        }

        public List<Appointment> getAppointmentsByPatientId(string patientID)
        {
            return appointmentRepository.FindByPatientId(patientID);
        }

        public List<Appointment> getAppointmentsByRoomId(string roomID)
        {
            return appointmentRepository.FindByRoomId(roomID);
        }


        public bool IntersectionWithAppointments(string patientID, string doctorID, string roomID, DateTime date, int duration)
        {
            List<Appointment> doctorAppointments = getAppointmentsByDoctorId(doctorID);
            List<Appointment> roomAppointments = getAppointmentsByRoomId(roomID);
            List<Appointment> patientAppointments = getAppointmentsByPatientId(patientID);
            
            foreach(Appointment a in doctorAppointments)
            {
                if(!((a.startTime.AddMinutes(a.duration) < date && a.startTime < date || (date.AddMinutes(duration) < a.startTime && date < a.startTime))))
                {
                    return true;
                }
            }
            foreach (Appointment a in roomAppointments)
            {
                if (!((a.startTime.AddMinutes(a.duration) < date && a.startTime < date || (date.AddMinutes(duration) < a.startTime && date < a.startTime))))
                {
                    return true;
                }
            }
            foreach (Appointment a in patientAppointments)
            {
                if (!((a.startTime.AddMinutes(a.duration) < date && a.startTime < date || (date.AddMinutes(duration) < a.startTime && date < a.startTime))))
                {
                    return true;
                }
            }

            return false;
        }

        


        public Appointment GetAppointmentByID(string id)
        {
            throw new NotImplementedException();
        }

        public RoomsCRUD roomsCRUD = new();
        public AppointmentRepository appointmentRepository = new AppointmentRepository();
        
   }
}