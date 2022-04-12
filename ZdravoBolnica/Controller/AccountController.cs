// File:    AccountController.cs
// Author:  dZoNi
// Created: Thursday, April 7, 2022 18:38:45
// Purpose: Definition of Class AccountController

using Model;
using System;
using System.Collections.Generic;


namespace Controller
{
   public class AccountController
   {
      public Account FindAccountById(int id)
      {
         throw new NotImplementedException();
      }
      
      public List<Patient> FindAllAccounts()
      {
            return patientService.FindAllPatients();
      }
      
      public bool DeleteAccountById(int id)
      {
         throw new NotImplementedException();
      }
      
      public bool AddAccount(Patient p)
      {
            patientService.AddPatient(p);
            return true;
      }
      
      public bool UpdateAccountById(int id)
      {
         throw new NotImplementedException();
      }
      
      public Service.PatientService patientService = new Service.PatientService();
   
   }
}