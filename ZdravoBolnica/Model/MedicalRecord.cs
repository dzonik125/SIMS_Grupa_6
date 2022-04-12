// File:    MedicalRecord.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:19:06
// Purpose: Definition of Class MedicalRecord

using System;

namespace Model
{
   public class MedicalRecord : Serializable
   {
      public int cardNum;
      public string bloodType;
      public int id;

        public void FromCSV(string[] values)
        {
            throw new NotImplementedException();
        }

        public string[] ToCSV()
        {
            throw new NotImplementedException();
        }
    }
}