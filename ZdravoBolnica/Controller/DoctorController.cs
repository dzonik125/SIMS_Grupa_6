// File:    DoctorService.cs
// Author:  Todor
// Created: Saturday, April 9, 2022 18:36:58
// Purpose: Definition of Class DoctorService

using Model;
using System;
using System.Collections.Generic;
namespace Controller
{
    public class DoctorController
    {
        public Service.DoctorService doctorService = new Service.DoctorService();
        public Doctor findFreeDoctor()
        {
            return null;
        }
        public List<Doctor> GetAllDoctors()
        {
            return doctorService.GetAllDoctors();
        }
        
        public void UpdateDoctor(Doctor d)
        {
            throw new NotImplementedException();
        }
        public List<Doctor> FindBySpecialization(Specialization specialization)
        {
            return doctorService.FindBySpecialization(specialization);
        }
        public void DeleteDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }
        public void SaveDoctor(Doctor doctor)
        {
            doctorService.SaveDoctor(doctor);
        }
        public Doctor GetDoctorById(int id)
        {
            return doctorService.GetDoctorById(id);
        }

        public List<Doctor> FindAll()
        {
            return doctorService.FindAll();
        }
    }
}