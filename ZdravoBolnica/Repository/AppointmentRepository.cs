// File:    AppointmentRepository.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:47:04
// Purpose: Definition of Class AppointmentRepository

using Model;
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
        
        private List<Appointment> patientAppointments = new();
        public Appointment FindById(int id)
        {
            foreach (Appointment appointment in FindAll())
            {
                if (appointment.id == id)
                    return appointment;
            }
            return null;
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
                if (appointment.Room.id == rid)
                    roomAppointments.Add(appointment);
            }
            return roomAppointments;
        }

        public List<Appointment> FindByDoctorId(int doctorId)
        {
            List<Appointment> doctorAppointments = new();
            foreach (Appointment appointment in FindAll())
            {
                if (appointment.Doctor.id == doctorId)
                    doctorAppointments.Add(appointment);
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

    }
}