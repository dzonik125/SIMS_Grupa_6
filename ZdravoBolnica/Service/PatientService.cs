// File:    PatientService.cs
// Author:  dZoNi
// Created: Thursday, April 7, 2022 18:12:03
// Purpose: Definition of Class PatientService

using System;
using System.Collections.Generic;
using Model;

namespace Service
{
   public class PatientService
   {
      public Patient FindPatientById(int id)
      {
         throw new NotImplementedException();
      }
      
      public List<Patient> FindAllPatients()
      {
            return patientRepository.FindAll();
      }
      
      public bool DeletePatientById(int id)
      {
         throw new NotImplementedException();
      }
      
      public bool AddPatient(Patient p)
      {
            patientRepository.Create(p);
            return true;
      }
      
      public bool UpdatePatienttById(int id)
      {
         throw new NotImplementedException();
      }
      
      public Repository.PatientRepository patientRepository = new Repository.PatientRepository();
   
   }
}