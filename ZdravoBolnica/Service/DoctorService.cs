// File:    DoctorService.cs
// Author:  Todor
// Created: Saturday, April 9, 2022 18:34:34
// Purpose: Definition of Class DoctorService

using Model;
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

        public Doctor GetDoctorByID(string id)
        {
            return doctorRepository.FindById(id);
        }

        public Repository.DoctorRepository doctorRepository = new Repository.DoctorRepository();
   
   }
}