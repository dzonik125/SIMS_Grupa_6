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
        public void Create(MedicalRecord entity)
        {
            throw new NotImplementedException();
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