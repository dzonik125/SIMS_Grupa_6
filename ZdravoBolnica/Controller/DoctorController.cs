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

        public List<Doctor> findBySpecialization(Specialization spec)
        {
            return doctorService.findBySpecialization(spec);
        }
        public void DeleteDoctor(Doctor d)
        {
            throw new NotImplementedException();
        }

        public void SaveDoctor(Doctor d)
        {
            doctorService.SaveDoctor(d);
        }

        public Doctor GetDoctorByID(int id)
        {
            return doctorService.GetDoctorByID(id);
        }

        // public List<string> GetSpecializationString()
        // {

        //     return doctorService.GetSpecializationString();
        //  }

        public Service.DoctorService doctorService = new Service.DoctorService();

    }
}