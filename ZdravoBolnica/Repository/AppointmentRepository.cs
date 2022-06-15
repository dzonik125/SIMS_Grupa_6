// File:    AppointmentRepository.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:47:04
// Purpose: Definition of Class AppointmentRepository

using Model;
using System;
using System.Collections.Generic;
using Model;
using SIMS;
using SIMS.Repository;

namespace Repository
{
    public class AppointmentRepository : IRepository<Appointment, int>, IAppointmentRepository
    {
        private String filename = @".\..\..\..\Data\appointments.txt";
        private Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
        
        private List<Appointment> patientAppointments = new();
        public Appointment FindById(int id)
        {
            Appointment returnAppointment = new();
            foreach (Appointment appointment in FindAll())
            {
                if (appointment.id == id)
                {
                    returnAppointment = appointment;
                    break;
                }
                else
                    returnAppointment = null;
            }
            return returnAppointment;
        }
        public List<Appointment> FindByPatientId(int patientId)
        {
            foreach (Appointment appointment in FindAll())
            {
                if (appointment.patient.id == patientId)
                    patientAppointments.Add(appointment);
            }
            return patientAppointments;
        }

        public List<Appointment> FindByRoomId(int rid)
        {
            List<Appointment> roomAppointments = new();
            foreach (Appointment appointment in FindAll())
            {
                if (appointment.room.id == rid)
                    roomAppointments.Add(appointment);
            }
            return roomAppointments;
        }

        public List<Appointment> FindByDoctorId(int doctorId)
        {
            List<Appointment> doctorAppointments = new();
            foreach (Appointment appointment in FindAll())
            {
                if (appointment.doctor.id == doctorId)
                    doctorAppointments.Add(appointment);
            }
            return doctorAppointments;
        }

        public List<Appointment> FindAll()
        {
            return appointmentSerializer.fromCSV(filename);
        }

        public void DeleteById(int id)
        {
            List<Appointment> appointments = FindAll();
            foreach (Appointment appointment in appointments)
            {
                if (appointment.id == id)
                {
                    appointments.Remove(appointment);
                    break;
                }
            }
            appointmentSerializer.toCSV(filename, appointments);
        }

        public void Create(Appointment entity)
        {
            List<Appointment> appointments = appointmentSerializer.fromCSV(filename);
            if (appointments.Count > 0)
            {
                entity.id = appointments[appointments.Count - 1].id;
                entity.id++;
            }
            else
            {
                entity.id = 1;
            }
            appointments.Add(entity);
            appointmentSerializer.toCSV(filename, appointments);
        }

        public void Update(Appointment entity)
        {
            List<Appointment> appointments = FindAll();
            foreach (Appointment a in appointments)
            {
                if (a.id == entity.id)
                {
                    int index = appointments.IndexOf(a);
                    if (index != -1)
                    {
                        appointments[index] = entity;
                        appointments[index].TimesEdited++;
                        break;
                    }
                }
            }
            appointmentSerializer.toCSV(filename, appointments);
        }
  

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

    }
}