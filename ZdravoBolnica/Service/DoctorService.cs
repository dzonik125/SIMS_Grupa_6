// File:    DoctorService.cs
// Author:  Todor
// Created: Saturday, April 9, 2022 18:34:34
// Purpose: Definition of Class DoctorService

using Model;
using Repository;
using SIMS.Util;
using System;
using System.Collections.Generic;

namespace Service
{
    public class DoctorService
    {
        private Doctor findFreeDoctor()
        {
            return null;
        }

        public List<Doctor> GetAllDoctors()
        {
            return doctorRepository.FindAll();
        }

        public void UpdateDoctor(Doctor d)
        {
            throw new NotImplementedException();
        }

        public void DeleteDoctor(Doctor d)
        {
            throw new NotImplementedException();
        }

        public void SaveDoctor(Doctor d)
        {
            doctorRepository.Create(d);
        }

        public Doctor GetDoctorByID(int id)
        {
            return doctorRepository.FindById(id);
        }
        public List<Doctor> findBySpecialization(Specialization spec)
        {
            return doctorRepository.findBySpecialization(spec);
        }

        public Appointment getAppointmentWithDoctor(Appointment appointment, DateRange dateRange)
        {

            List<Doctor> doctors = findBySpecialization(dateRange.specializationType);
            foreach (Doctor d in doctors)
            {
                if (!checkIfDoctorIsBusy(d, dateRange))
                {
                    appointment.Doctor = d;
                    return appointment;
                }
            }
            return null;
        }


        public bool checkIfDoctorIsBusy(Doctor d, DateRange dateRange)
        {
            AppointmentRepository appointmentRepository = new AppointmentRepository();
            List<Appointment> appointments = appointmentRepository.FindByDoctorId(d.id);
            foreach (Appointment a in appointments)
            {
                if (dateRange.checkForIntersection(a.startTime, a.duration))
                    return true;
            }
            return false;
        }


        // public List<string> GetSpecializationString()
        // {
        //     return doctorRepository.GetSpecializationString();
        // }

        public Repository.DoctorRepository doctorRepository = new Repository.DoctorRepository();
    }
}