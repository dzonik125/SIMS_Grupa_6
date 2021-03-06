// File:    Address.cs
// Author:  Todor
// Created: Saturday, April 9, 2022 18:23:18
// Purpose: Definition of Class Address

using System;

namespace Model
{
   public class Adress : Serializable
   {
        public string street { get; set; }
        public string number { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string id { get; set; }

        public Adress(string id)
        {
            this.id = id;
        }

        public Adress()
        {
        }

        public void FromCSV(string[] values)
        {
            street = values[0];
            number = values[1];
            city = values[2];
            country = values[3];
            id = values[4];
        }

        public string[] ToCSV()
        {


            string[] csvValues =
           {
                street.ToString(),
                number.ToString(),
                city.ToString(),
                country.ToString(),
                id.ToString(),
            };
            return csvValues;
        }
    }
}