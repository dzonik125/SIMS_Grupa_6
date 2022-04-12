// File:    User.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:12:42
// Purpose: Definition of Class User

using System;

namespace Model
{
   public class User
   {
      public string name { get; set; }
        public string surname { get; set; }
        public string jmbg { get; set; }
        public string id { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string birthdate { get; set; }
        public string adressID { get; set; }

        public Adress address { get; set; }


        public String FullName { get => (name + " " + surname); }

    }
}