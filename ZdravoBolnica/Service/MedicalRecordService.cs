// File:    MedicalRecordService.cs
// Author:  Todor
// Created: Saturday, April 9, 2022 17:19:14
// Purpose: Definition of Class MedicalRecordService

using Model;
using Repository;
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

        public bool AddMedicalRecord(MedicalRecord mr)
        {
            MedicalRecordRepository mrr = new MedicalRecordRepository();
            mrr.Create(mr);
            return true;
        }

        public List<MedicalRecord> findAll()
        {
            return medicalRecordRepository.FindAll();
        }

        public bool UpdateMedicalRecord(MedicalRecord mr)
        {
            medicalRecordRepository.Update(mr);
            return true;
        }
    }
}