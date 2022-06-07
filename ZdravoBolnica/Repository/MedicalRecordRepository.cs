// File:    MedicalRecordRepository.cs
// Author:  Todor
// Created: Saturday, April 9, 2022 17:09:42
// Purpose: Definition of Class MedicalRecordRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class MedicalRecordRepository : IRepository<MedicalRecord, int>
    {
        private Serializer<MedicalRecord> medicalRecordSerializer = new();
        private String filename = @".\..\..\..\Data\medicalrecords.txt";
        public PatientRepository pr = new PatientRepository();
        public void Create(MedicalRecord entity)
        {
            List<MedicalRecord> medicalRecords = new List<MedicalRecord>();
            medicalRecords = medicalRecordSerializer.fromCSV(filename);
            if (medicalRecords.Count > 0)
            {
                entity.id = medicalRecords[medicalRecords.Count - 1].id;
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
            MedicalRecord returnMRecord = new();
            foreach (MedicalRecord mr in FindAll())
            {
                if (key == mr.id)
                {
                    returnMRecord = mr;
                    break;
                }
                else
                {
                    returnMRecord = null;
                }
            }

            return returnMRecord;
        }

        public void Update(MedicalRecord entity)
        {
            List<MedicalRecord> medicalRecords = FindAll();
            foreach (MedicalRecord mr in FindAll())
            {
                if (mr.id == entity.id)
                {
                    int index = medicalRecords.IndexOf(mr);
                    if (index != -1)
                    {
                        medicalRecords[index] = entity;
                        break;
                    }
                }
            }
            medicalRecordSerializer.toCSV(filename, medicalRecords);
        }
    }
}