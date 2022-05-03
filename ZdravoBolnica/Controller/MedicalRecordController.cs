// File:    MedicalRecordController.cs
// Author:  Todor
// Created: Saturday, April 9, 2022 17:21:02
// Purpose: Definition of Class MedicalRecordController

using Model;
using Service;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class MedicalRecordController
    {
        public MedicalRecord FindMedicalRecordById(int id)
        {
            return medicalRecordService.FindMedicalRecordById(id);
        }

        public bool UpdateMedicalRecord(MedicalRecord mr)
        {
            medicalRecordService.UpdateMedicalRecord(mr);
            return true;
        }

        public bool DeleteMedicalRecordById(int id)
        {

            return true;
        }

        public bool DeleteAllMedicalRecords()
        {
            throw new NotImplementedException();
        }

        public bool AddMedicalRecord(MedicalRecord mr)
        {
            MedicalRecordService mrs = new MedicalRecordService();
            mrs.AddMedicalRecord(mr);
            return true;
        }



        public List<MedicalRecord> FindAll()
        {
            return medicalRecordService.findAll();
        }


        public bool checkIfPatientisAllergic(Medication medication, MedicalRecord medicalRecord)
        {
            return medicalRecordService.checkIfPatientisAllergic(medication, medicalRecord);
        }

        public Service.MedicalRecordService medicalRecordService = new();

    }
}