// File:    DoctorRepository.cs
// Author:  Todor
// Created: Saturday, April 9, 2022 18:33:43
// Purpose: Definition of Class DoctorRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class DoctorRepository : Repository<Doctor, string>
    {
        private String filename = @".\..\..\..\Data\doctors.txt";
        private Serializer<Doctor> doctorSerializer = new Serializer<Doctor>();
        public void Create(Doctor entity)
        {
            List<Doctor> doctors = new List<Doctor>();
            doctors = doctorSerializer.fromCSV(filename);
            doctors.Add(entity);
            doctorSerializer.toCSV(filename, doctors);
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> FindAll()
        {
            return doctorSerializer.fromCSV(filename);
        }

      

        public Doctor FindById(string key)
        {
            List<Doctor> doctors = FindAll();
            foreach(Doctor d in doctors)
            {
                if(d.id.Equals(key))
                {
                    return d;
                    break;
                }
            }
            return null;
        }

        public void Update(Doctor entity)
        {
            throw new NotImplementedException();
        }
    }
}