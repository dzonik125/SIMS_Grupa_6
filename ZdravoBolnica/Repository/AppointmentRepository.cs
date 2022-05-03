// File:    AppointmentRepository.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:47:04
// Purpose: Definition of Class AppointmentRepository

using System;
using System.Collections.Generic;
using Model;
using SIMS;

namespace Repository
{
    public class AppointmentRepository : Repository<Appointment, int>
    {
        private String filename = @".\..\..\..\Data\appointments.txt";
        private Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
        public Appointment FindById(int id)
        {
            List<Appointment> appointments = FindAll();
            foreach (Appointment a in appointments)
            {
                if (a.id == id)
                {
                    return a;
                }
            }

            return null;
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
                if (a.Room.id == rid)
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

        public void DeleteById(int id)
        {
            List<Appointment> appointments = FindAll();
            foreach (Appointment a in appointments)
            {
                if (a.id == id)
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
            int num = appointments.Count;
            if (num > 0)
            {
                entity.id = appointments[num - 1].id;
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
                if (a.id.Equals(entity.id))
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

    }
}