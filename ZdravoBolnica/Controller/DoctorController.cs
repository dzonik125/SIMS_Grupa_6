// File:    DoctorService.cs
// Author:  Todor
// Created: Saturday, April 9, 2022 18:36:58
// Purpose: Definition of Class DoctorService

using System;
using System;
using System.Collections.Generic;
using Model;
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

        public Service.DoctorService doctorService = new Service.DoctorService();
   
   }
}