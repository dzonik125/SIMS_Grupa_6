// File:    PatientRepository.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:43:01
// Purpose: Definition of Class PatientRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class PatientRepository : IRepository<Patient, int>
    {
        private String filename = @".\..\..\..\Data\patients.txt";
        private Serializer<Patient> patientSerializer = new Serializer<Patient>();
        public void Create(Patient entity)
        {
            List<Patient> patients = new List<Patient>();
            patients = patientSerializer.fromCSV(filename);
            if (patients.Count > 0)
            {
                entity.id = patients[patients.Count - 1].id;
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
        }

        public Patient FindById(int key)
        {
            Patient returnPatient = new();
            foreach (Patient p in FindAll())
            {
                if (p.id == key)
                {
                    returnPatient = p;
                    break;
                }
                else
                {
                    returnPatient = null;
                }
            }
            return returnPatient;
        }


        public void Update(Patient entity)
        {
            List<Patient> patients = FindAll();
            foreach (Patient p in patients)
            {
                if (p.id.Equals(entity.id))
                {
                    int index = patients.IndexOf(p);
                    if (index != -1)
                    {
                        patients[index] = entity;
                        break;
                    }
                }
            }
            patientSerializer.toCSV(filename, patients);
        }
    }
}