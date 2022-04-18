// File:    Address.cs
// Author:  Todor
// Created: Saturday, April 9, 2022 18:23:18
// Purpose: Definition of Class Address

using System;

namespace Model
{
   public class Address : Serializable
   {
      public string street;
      public string number;
      public string city;
      public string country;

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