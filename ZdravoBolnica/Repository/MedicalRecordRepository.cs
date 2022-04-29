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
            throw new NotImplementedException();
        }

        public MedicalRecord FindById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(MedicalRecord entity)
        {
            throw new NotImplementedException();
        }
    }
}