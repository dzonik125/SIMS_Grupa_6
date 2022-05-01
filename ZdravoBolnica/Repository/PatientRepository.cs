// File:    PatientRepository.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:43:01
// Purpose: Definition of Class PatientRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class PatientRepository : Repository<Patient, int>
    {
        private String filename = @".\..\..\..\Data\patients.txt";
        private Serializer<Patient> patientSerializer = new Serializer<Patient>();
        public void Create(Patient entity)
        {
            List<Patient> patients = new List<Patient>();
            patients = patientSerializer.fromCSV(filename);
            int num = patients.Count;
            if (num > 0)
            {
                entity.id = patients[num - 1].id;
                entity.id++;
            }
            else
            {
                entity.id = 1;
            }
            patients.Add(entity);
            patientSerializer.toCSV(filename, patients);

        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            List<Patient> patients = FindAll();
            foreach (Patient p in patients)
            {
                if (id == p.id)
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

        public Patient FindById(int key)
        {
            throw new NotImplementedException();
        }


        public void Update(Patient entity)
        {
            List<Patient> patients = FindAll();
            foreach (Patient p in patients)
            {
                if (p.id.Equals(entity.id))
                {
                    p.name = entity.name;
                    p.surname = entity.surname;
                    p.email = entity.email;
                    p.phone = entity.phone;
                    p.birthdate = entity.birthdate;
                    p.jmbg = entity.jmbg;
                    p.lbo = entity.lbo;
                    p.username = entity.username;
                    p.password = entity.password;
                    p.gender = entity.gender;
                    break;
                }
            }
            patientSerializer.toCSV(filename, patients);
        }
    }
}