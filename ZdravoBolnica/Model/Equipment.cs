// File:    Equipment.cs
// Author:  dZoNi
// Created: Thursday, April 7, 2022 17:04:32
// Purpose: Definition of Class Equipment

using SIMS.Model;
using System;

namespace Model
{
   public class Equipment : Serializable
   {
       

      
        public int id { get; set; }
      public string item { get; set; }
      public int quantity { get; set; }
      public EquipmentType type { get; set; }
      public Room room { get; set; }

       /* public Equipment(int v1, string v2, int v3, EquipmentType potrosna)
        {
            this.id = v1;
            this.item = v2;
            this.quantity = v3;
            this.type = potrosna;
        }
*/


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