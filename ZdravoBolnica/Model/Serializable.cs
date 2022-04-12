// File:    Serializable.cs
// Author:  dZoNi
// Created: Thursday, April 7, 2022 16:14:37
// Purpose: Definition of Interface Serializable

using System;

namespace Model
{
   public interface Serializable
   {
      string[] ToCSV();
      
      void FromCSV(string[] values);
   
   }
}