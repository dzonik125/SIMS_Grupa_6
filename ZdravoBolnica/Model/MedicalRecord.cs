// File:    MedicalRecord.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:19:06
// Purpose: Definition of Class MedicalRecord

using SIMS.Model;
using System;
using System.Collections.Generic;

namespace Model
{
    public class MedicalRecord : Serializable
    {
        public int cardNum;
        public BloodType bloodType;
        public int id;
        public List<String> hronicalDeseasses;
        public Allergies allergies;
        public List<Prescription> prescriptions;
        public List<ExaminationReport> reports;
     

        public MedicalRecord(int cardNum, BloodType bt)
        {
            this.cardNum = cardNum;
            this.bloodType = bt;
        }



        public MedicalRecord()
        {

        }

        public void FromCSV(string[] values)
        {
            cardNum = Convert.ToInt32(values[0]);
            bloodType = Conversion.StringToBloodType(values[1]);
            id = Convert.ToInt32(values[2]);
            //allergies = values[3];
            //hronicalDeseasses = values[3];
        }

        public string[] ToCSV()
        {
            string[] csvValues = {
            cardNum.ToString(),
            bloodType.ToString(),
            id.ToString(),
            //hronicalDeseasses.ToString()
        };
            return csvValues;
        }
    }
}