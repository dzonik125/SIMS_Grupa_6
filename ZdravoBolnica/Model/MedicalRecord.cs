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
        public string cardNum;
        public BloodType bloodType;
        public int id;
        public List<Ingredient> ingredientAllergies = new List<Ingredient>();
        public List<Prescription> prescriptions = new List<Prescription>();
        public List<Medication> medicationAllergies = new List<Medication>();
        public List<String> hronicalDeseasses;

        public string ids = "";
        public string medids = "";


        public IngredientsRepository ir = new IngredientsRepository();
        private MedicationRepository mr = new MedicationRepository();

        public List<ExaminationReport> reports;

        public MedicalRecord()
        {

        }

        public void FromCSV(string[] values)
        {
            cardNum = values[0];
            bloodType = Conversion.StringToBloodType(values[1]);
            id = Convert.ToInt32(values[2]);

            List<int> ids = new List<int>();
            if (values[3] != "")
            {
                string[] parts = values[3].Split(',');

                foreach (string s in parts)
                {
                    ids.Add(Convert.ToInt32(s));
                }
                foreach (int i in ids)
                {
                    ingredientAllergies.Add(ir.FindById(i));
                }
            }


            List<int> medids = new List<int>();
            if (values[4] != "")
            {
                string[] medparts = values[4].Split(',');
                foreach (string s in medparts)
                {
                    medids.Add(Convert.ToInt32(s));
                }

                foreach (int i in medids)
                {
                    medicationAllergies.Add(mr.FindById(i));
                }
            }
        }

        public string[] ToCSV()
        {

            foreach (Ingredient ing in ingredientAllergies)
            {
                ids = ids + ing.id + ",";
            }
            if (ids != "")
            {
                ids = ids.Remove(ids.Length - 1, 1);
            }

            foreach (Medication m in medicationAllergies)
            {
                medids = medids + m.id + ",";
            }
            if (medids != "")
            {
                medids = medids.Remove(medids.Length - 1, 1);
            }

            string[] csvValues = {
            cardNum.ToString(),
            Conversion.BloodTypeToString(bloodType),
            id.ToString(),
            ids.ToString(),
            medids.ToString(),
            //hronicalDeseasses.ToString()
        };

            return csvValues;
        }
    }
}