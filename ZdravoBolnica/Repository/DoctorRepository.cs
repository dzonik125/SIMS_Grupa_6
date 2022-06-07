// File:    DoctorRepository.cs
// Author:  Todor
// Created: Saturday, April 9, 2022 18:33:43
// Purpose: Definition of Class DoctorRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class DoctorRepository : IRepository<Doctor, int>
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


        public List<Doctor> FindAll()
        {
            return doctorSerializer.fromCSV(filename);
        }

        public Doctor FindById(int key)
        {
            Doctor returnDoctor = new();
            foreach (Doctor d in FindAll())
            {
                if (d.id == key)
                {
                    returnDoctor = d;
                    break;
                }
                else
                {
                    returnDoctor = null;
                }
            }
            return returnDoctor;
        }

        public void Update(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> findBySpecialization(Specialization specialization)
        {
            List<Doctor> returnDoctors = new List<Doctor>();
            foreach (Doctor d in FindAll())
            {
                if (d.specialization == specialization)
                    returnDoctors.Add(d);
            }
            return returnDoctors;
        }
    }
}