// File:    MedicalRecordController.cs
// Author:  Todor
// Created: Saturday, April 9, 2022 17:21:02
// Purpose: Definition of Class MedicalRecordController

using Model;
using Service;
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
            //medicalRecordService.UpdateAdress(mr);
            //return true;
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Service.MedicalRecordService medicalRecordService;

    }
}