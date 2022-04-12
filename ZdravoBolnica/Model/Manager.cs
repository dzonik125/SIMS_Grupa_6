// File:    Manager.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:12:57
// Purpose: Definition of Class Manager

using System;

namespace Model
{
   public class Manager : Account, Serializable
   {
      public System.Collections.Generic.List<Room> room;
      
      
        public string[] ToCSV()
        {
            throw new NotImplementedException();
        }

        public void FromCSV(string[] values)
        {
            throw new NotImplementedException();
        }
    }
}