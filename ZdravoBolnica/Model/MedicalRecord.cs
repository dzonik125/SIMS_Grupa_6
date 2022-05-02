// File:    MedicalRecord.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:19:06
// Purpose: Definition of Class MedicalRecord

using SIMS.Model;
using SIMS.Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public class MedicalRecord : Serializable
    {
        public int cardNum;
        public BloodType bloodType;
        public int id;
        public List<Allergies> allergies = new List<Allergies>();

        public List<String> hronicalDeseasses;

        public string ids;

        public AllergiesRepository ar = new AllergiesRepository();


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

            List<int> ids = new List<int>();
            string[] parts = values[3].Split(',');
            foreach (string s in parts)
            {
                ids.Add(Convert.ToInt32(s));
            }
            foreach (int i in ids)
            {
                allergies.Add(ar.FindById(i));
            }

            //hronicalDeseasses = values[3];
        }

        public string[] ToCSV()
        {
            foreach (Allergies a in allergies)
            {
                ids = ids + a.id + ",";
            }
            ids = ids.Remove(ids.Length - 1, 1);


            string[] csvValues = {
            cardNum.ToString(),
            Conversion.BloodTypeToString(bloodType),
            id.ToString(),
            ids.ToString(),
            //hronicalDeseasses.ToString()
        };

            return csvValues;
        }
    }
}