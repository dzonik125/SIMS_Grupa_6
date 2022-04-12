// File:    Doctor.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:12:43
// Purpose: Definition of Class Doctor

using SIMS.Model;
using System;

namespace Model
{
   public class Doctor : Account, Serializable
   {
      public Double grade;
      
      public System.Collections.Generic.List<Appointment> appointments { get; set; }
      
      /// <summary>
      /// Property for collection of Appointment
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      
   

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                id.ToString(),
                name,
                surname,
                Conversion.SpecializationToString(specialization),
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            id = values[0];
            name = values[1];
            surname = values[2];
            specialization = Conversion.StringToSpecialization(values[3]);
        }

        public Specialization specialization;
      
      /// <summary>
      /// Property for Specialization
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Specialization Specialization
      {
         get
         {
            return specialization;
         }
     
      }
   
   }
}