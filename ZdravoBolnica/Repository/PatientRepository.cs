// File:    PatientRepository.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:43:01
// Purpose: Definition of Class PatientRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class PatientRepository : Repository<Patient, string>
    {

        private String filename = @".\..\..\..\Data\patients.txt";
        private Serializer<Patient> patientSerializer = new Serializer<Patient>();

        public void Create(Patient entity)
        {
            List<Patient> patients = new List<Patient>();
            patients = patientSerializer.fromCSV(filename);
            patients.Add(entity);
            patientSerializer.toCSV(filename, patients);

        }


        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Patient> FindAll()
        {
            return patientSerializer.fromCSV(filename);
        }

        public Patient FindById(string key)
        {
            throw new NotImplementedException();
        }

        public void Update(Patient entity)
        {
            throw new NotImplementedException();
        }
    }
}