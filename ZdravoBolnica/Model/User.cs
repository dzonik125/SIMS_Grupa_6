// File:    User.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:12:42
// Purpose: Definition of Class User

using System;

namespace Model
{
   public class User
   {
      public string name;
      public string surname;
      public string jmbg;
      public string id;
      public string phone;
      public string email;
      
      public Address address;


      public String FullName { get => (name + " " + surname); }

    }
}