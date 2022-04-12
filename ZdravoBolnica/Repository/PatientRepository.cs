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
            List<Patient> patients = FindAll();
            foreach(Patient p in patients)
            {
                if (id.Equals(p.id))
                {
                    patients.Remove(p);
                    break;
                }
            }
            patientSerializer.toCSV(filename, patients);
        }

        public List<Patient> FindAll()
        {
            
            return patientSerializer.fromCSV(filename);
            System.Diagnostics.Trace.WriteLine("ovde");
        }

        public Patient FindById(string key)
        {
            throw new NotImplementedException();
        }

        public void Update(Patient entity)
        {
            List<Patient> patients = FindAll();
            foreach(Patient p in patients)
            {
                if (p.id.Equals(entity.id))
                {
                    p.name = entity.name;
                    System.Diagnostics.Trace.WriteLine(p.name);
                    p.surname = entity.surname;
                    p.email = entity.email;
                    p.phone = entity.phone;
                    p.birthdate = entity.birthdate;
                    p.jmbg = entity.jmbg;
                    p.lbo = entity.lbo;
                    p.username = entity.username;
                    p.password = entity.password;
                    break;
                }
            }
            patientSerializer.toCSV(filename, patients);
        }
    }
}