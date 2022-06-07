// File:    Patient.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:12:49
// Purpose: Definition of Class Patient

using SIMS.Model;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Patient : Account, Serializable
    {
        public string lbo { get; set; }
        public Adress address { get; set; }

        public bool guest { get; set; }

        public MedicalRecord medicalRecord = new MedicalRecord();
        public List<Appointment> appointments;


        public string[] ToCSV()
        {
            string[] csvValues =
           {
                id.ToString(),
                name.ToString(),
                surname.ToString(),
                email.ToString(),
                password.ToString(),
                username.ToString(),
                address.id.ToString(),
                phone.ToString(),
                lbo.ToString(),
                jmbg,
                birthdate.ToString(),
                guest.ToString(),
                ((int) gender).ToString(),
                medicalRecord.id.ToString(),
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            address = new Adress();
            id = int.Parse(values[0]);
            name = values[1];
            surname = values[2];
            email = values[3];
            password = values[4];
            username = values[5];
            address.id = int.Parse(values[6]);
            phone = values[7];
            lbo = values[8];
            jmbg = values[9];
            birthdate = values[10];
            guest = bool.Parse(values[11]);
            gender = (Gender)Int32.Parse(values[12]);
            medicalRecord.id = int.Parse(values[13]);
        }
    }
}