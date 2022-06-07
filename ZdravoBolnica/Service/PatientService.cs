// File:    PatientService.cs
// Author:  dZoNi
// Created: Thursday, April 7, 2022 18:12:03
// Purpose: Definition of Class PatientService

using Model;
using Repository;
using System.Collections.Generic;
namespace Service
{
    public class PatientService
    {
        private PatientRepository patientRepository = new PatientRepository();
        public Patient FindPatientById(int id)
        {
            return patientRepository.FindById(id);
        }

        public List<Patient> FindAllPatients()
        {
            return patientRepository.FindAll();
        }

        public bool DeletePatientById(int id)
        {
            patientRepository.DeleteById(id);
            return true;
        }

        public bool AddPatient(Patient patient)
        {
            patientRepository.Create(patient);
            return true;
        }

        public bool AddGuestPatient(Patient patient)
        {
            patientRepository.Create(patient);
            return true;
        }

        public bool UpdatePatient(Patient patient)
        {
            patientRepository.Update(patient);
            return true;
        }

    }
}