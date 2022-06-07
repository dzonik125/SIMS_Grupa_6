// File:    MedicalRecordRepository.cs
// Author:  Todor
// Created: Saturday, April 9, 2022 17:09:42
// Purpose: Definition of Class MedicalRecordRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class MedicalRecordRepository : Repository<MedicalRecord, int>
    {
        private Serializer<MedicalRecord> medicalRecordSerializer = new();
        private String filename = @".\..\..\..\Data\medicalrecords.txt";
        public PatientRepository pr = new PatientRepository();
        public void Create(MedicalRecord entity)
        {
            List<MedicalRecord> medicalRecords = new List<MedicalRecord>();

            medicalRecords = medicalRecordSerializer.fromCSV(filename);
            int num = medicalRecords.Count;

            if (num > 0)
            {
                entity.id = medicalRecords[num - 1].id;
                entity.id++;
            }
            else
            {
                entity.id = 1;
            }
            medicalRecords.Add(entity);
            medicalRecordSerializer.toCSV(filename, medicalRecords);
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<MedicalRecord> FindAll()
        {
            return medicalRecordSerializer.fromCSV(filename);
        }

        public MedicalRecord FindById(int key)
        {
            List<MedicalRecord> medicalRecords = FindAll();
            foreach (MedicalRecord mr in medicalRecords)
            {
                if (key == mr.id)
                {
                    return mr;
                }
            }

            return null;
        }

        public void Update(MedicalRecord entity)
        {
            List<MedicalRecord> medicalRecords = FindAll();
            foreach (MedicalRecord mr in medicalRecords)
            {
                if (mr.id == entity.id)
                {
                    mr.cardNum = entity.cardNum;
                    mr.bloodType = entity.bloodType;
                    mr.ingredients = entity.ingredients;
                    mr.medications = entity.medications;
                }
            }
            medicalRecordSerializer.toCSV(filename, medicalRecords);
        }
    }
}