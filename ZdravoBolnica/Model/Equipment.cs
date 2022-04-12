// File:    Equipment.cs
// Author:  dZoNi
// Created: Thursday, April 7, 2022 17:04:32
// Purpose: Definition of Class Equipment

using System;

namespace Model
{
   public class Equipment : Serializable
   {
      public int id;
      public string item;
      public int quantity;

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