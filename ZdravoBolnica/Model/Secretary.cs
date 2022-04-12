// File:    Secretary.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:12:55
// Purpose: Definition of Class Secretary

using System;

namespace Model
{
    public class Secretary : Account, Serializable
    {
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