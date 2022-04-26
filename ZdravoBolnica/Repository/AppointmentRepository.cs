// File:    AppointmentRepository.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:47:04
// Purpose: Definition of Class AppointmentRepository

using System;
using System.Collections.Generic;
using Model;

namespace Repository
{
    public class AppointmentRepository : Repository<Appointment, string>
    {
        private String filename = @".\..\..\..\Data\appointments.txt";
        private Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
        public Appointment FindAppointmentById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> FindByPatientId(int pid)
        {
            List<Appointment> appointments = new();
            List<Appointment> patientAppointments = new();
            appointments = FindAll();
            foreach (Appointment a in appointments)
            {
                if (a.patient.id == pid)
                {
                    patientAppointments.Add(a);
                }
            }
            return patientAppointments;
        }

        public List<Appointment> FindByRoomId(int rid)
        {
            List<Appointment> appointments = new();
            List<Appointment> roomAppointments = new();
            appointments = FindAll();
            foreach (Appointment a in appointments)
            {
                if (a.Room.id.Equals(rid))
                {
                    roomAppointments.Add(a);
                }
            }
            return roomAppointments;
        }

        public List<Appointment> FindByDoctorId(int did)
        {
            List<Appointment> appointments = new();
            List<Appointment> doctorAppointments = new();
            appointments = FindAll();
            foreach (Appointment a in appointments)
            {
                if (a.Doctor.id==did)
                {
                    doctorAppointments.Add(a);
                }
            }
            return doctorAppointments;
        }

        public List<Appointment> FindAll()
        {
            return appointmentSerializer.fromCSV(filename);
        }

        public Appointment FindById(string key)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            List<Appointment> appointments = FindAll();
            foreach (Appointment a in appointments)
            {
                if (a.id.Equals(id))
                {
                    appointments.Remove(a);
                    break;
                }
            }
            appointmentSerializer.toCSV(filename, appointments);
        }

        public void Create(Appointment entity)
        {
            _ = new List<Appointment>();
            List<Appointment> appointments = appointmentSerializer.fromCSV(filename);
            appointments.Add(entity);
            appointmentSerializer.toCSV(filename, appointments);
        }

        public void Update(Appointment entity)
        {
            List<Appointment> appointments = FindAll();
            foreach (Appointment a in appointments)
            {
                if (a.id.Equals(entity.id))
                {
                    int index = appointments.IndexOf(a);
                    if (index != -1)
                    {
                        appointments[index] = entity;
                        break;
                    }
                }
            }
            appointmentSerializer.toCSV(filename, appointments);
        }

    }
}