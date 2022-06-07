// File:    Account.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:12:52
// Purpose: Definition of Class Account

namespace Model
{
    public class Account : User
    {
        public string username;
        public string password;
        public AccountType accountType;

    }
}