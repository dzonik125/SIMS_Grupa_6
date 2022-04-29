// File:    MedicalRecordService.cs
// Author:  Todor
// Created: Saturday, April 9, 2022 17:19:14
// Purpose: Definition of Class MedicalRecordService

using Model;
using Repository;
using System;

namespace Service
{
    public class MedicalRecordService
    {
        public Repository.MedicalRecordRepository medicalRecordRepository;

        internal MedicalRecord FindMedicalRecordById(int id)
        {
            throw new NotImplementedException();
        }

        public bool AddMedicalRecord(MedicalRecord mr)
        {
            MedicalRecordRepository mrr = new MedicalRecordRepository();
            mrr.Create(mr);
            return true;
        }
    }
}