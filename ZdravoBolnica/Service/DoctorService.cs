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

        public void SaveDoctor(Doctor doctor)
        {
            doctorRepository.Create(doctor);
        }

        public Doctor GetDoctorById(int id)
        {
            return doctorRepository.FindById(id);
        }
        public List<Doctor> FindBySpecialization(Specialization specialization)
        {
            return doctorRepository.findBySpecialization(specialization);
        }

        public bool freeDoctorExistsForAppointment(Appointment appointment, Scheduler scheduler)
        {
            bool freeDoctorExists = false; 
            foreach (Doctor doctor in FindBySpecialization(scheduler.specializationType))
            {
                if (!checkIfDoctorIsBusy(doctor, scheduler))
                {
                    appointment.doctor = doctor;
                    freeDoctorExists = true;
                }
            }
            return freeDoctorExists;
        }


        public bool checkIfDoctorIsBusy(Doctor doctor, Scheduler scheduler)
        {
            bool doctorIsBusy = false;
            AppointmentRepository appointmentRepository = new AppointmentRepository();
            List<Appointment> appointments = appointmentRepository.FindByDoctorId(doctor.id);
            foreach (Appointment appointment in appointments)
            {
                if (scheduler.overlapsWithExistingTerm(appointment.startTime, appointment.duration))
                    doctorIsBusy = true;
            }
            return doctorIsBusy;
        }

        public void UpdateDoctor(Doctor d)
        {
            throw new NotImplementedException();
        }

        public void DeleteDoctor(Doctor d)
        {
            throw new NotImplementedException();
        }

        public Repository.DoctorRepository doctorRepository = new Repository.DoctorRepository();

        public List<Doctor> FindAll()
        {
            return doctorRepository.FindAll();
        }
    }
}