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

        public Doctor GetDoctorById(int id)
        {
            return doctorRepository.FindById(id);
        }
        public List<Doctor> FindBySpecialization(Specialization spec)
        {
            return doctorRepository.findBySpecialization(spec);
        }

        public bool freeDoctorExistsForAppointment(Appointment appointment, DateRange dateRange)
        {
            bool freeDoctorExists = false; 
            foreach (Doctor doctor in FindBySpecialization(dateRange.specializationType))
            {
                if (!checkIfDoctorIsBusy(doctor, dateRange))
                {
                    appointment.Doctor = doctor;
                    freeDoctorExists = true;
                }
            }
            return freeDoctorExists;
        }


        public bool checkIfDoctorIsBusy(Doctor d, DateRange dateRange)
        {
            bool doctorIsBusy = false;
            AppointmentRepository appointmentRepository = new AppointmentRepository();
            List<Appointment> appointments = appointmentRepository.FindByDoctorId(d.id);
            foreach (Appointment a in appointments)
            {
                if (dateRange.checkForIntersection(a.startTime, a.duration))
                    doctorIsBusy = true;
            }
            return doctorIsBusy;
        }
        
        public Repository.DoctorRepository doctorRepository = new Repository.DoctorRepository();
    }
}