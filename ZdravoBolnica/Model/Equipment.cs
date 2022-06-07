// File:    Equipment.cs
// Author:  dZoNi
// Created: Thursday, April 7, 2022 17:04:32
// Purpose: Definition of Class Equipment

using SIMS.Model;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Equipment : Serializable
    {

        public int id { get; set; }
        public string item { get; set; }
        public int quantity { get; set; }
        public EquipmentType type { get; set; }
        public List<int> roomNum { get; set; }


        public void FromCSV(string[] values)
        {
            id = int.Parse(values[0]);
            item = values[1];
            quantity = int.Parse(values[2]);
            type = Conversion.StringToEquipmentType(values[3]);
           
        }

        public string[] ToCSV()
        {
            string[] csvValues =
           {
                id.ToString(),
                item.ToString(),
                quantity.ToString(),
                Conversion.EquipmentTypeToString(type),
             
               
            };
            return csvValues;
        }
    }
}