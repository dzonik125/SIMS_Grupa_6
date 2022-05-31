// File:    Doctor.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:12:43
// Purpose: Definition of Class Doctor

using SIMS.Model;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Doctor : Account, Serializable
    {
        public Double grade;

        public System.Collections.Generic.List<Appointment> appointments { get; set; }

        public List<VacationPeriod> vacationPeriods { get; set; }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                id.ToString(),
                name,
                surname,
                Conversion.SpecializationToString(specialization),
                password,
                username,
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            id = int.Parse(values[0]);
            name = values[1];
            surname = values[2];
            specialization = Conversion.StringToSpecialization(values[3]);
            password = values[4];
            username = values[5];
        }

        public Specialization specialization;
        public Specialization Specialization
        {
            get
            {
                return specialization;
            }

        }

    }
}