// File:    MedicalRecordService.cs
// Author:  Todor
// Created: Saturday, April 9, 2022 17:19:14
// Purpose: Definition of Class MedicalRecordService

using Model;
using Repository;
using SIMS.Model;
using SIMS.Service;
using System.Collections.Generic;

namespace Service
{
    public class MedicalRecordService
    {
        public Repository.MedicalRecordRepository medicalRecordRepository = new();

        internal MedicalRecord FindMedicalRecordById(int id)
        {
            return medicalRecordRepository.FindById(id);
        }

        public void AddMedicalRecord(MedicalRecord mr)
        {
            medicalRecordRepository.Create(mr);
        }

        public List<MedicalRecord> findAll()
        {
            return medicalRecordRepository.FindAll();
        }

        public void UpdateMedicalRecord(MedicalRecord mr)
        {
            medicalRecordRepository.Update(mr);
        }

        public bool checkIfPatientisAllergic(Medication medication, MedicalRecord medicalRecord)
        {
            MedicationService medicationService = new MedicationService();
            bool isAllergicToMedication = checkIfPatientIsAllergicToMedication(medication, medicalRecord);
            bool isAllergicToIngredient = medicationService.IsAllergicToIngredientOfMedication(medicalRecord.ingredientAllergies, medication);
            return isAllergicToIngredient || isAllergicToMedication;
        }

        private bool checkIfPatientIsAllergicToMedication(Medication medication, MedicalRecord medicalRecord)
        {
            bool isPatientAllergic = false;
            foreach (Medication med in medicalRecord.medicationAllergies)
            {
                if (med.name.Equals(medication.name))
                {
                    isPatientAllergic = true;
                }
            }
            return isPatientAllergic;
        }
    }
}