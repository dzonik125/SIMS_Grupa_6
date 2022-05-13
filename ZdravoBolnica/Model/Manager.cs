// File:    Manager.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:12:57
// Purpose: Definition of Class Manager

namespace Model
{
    public class Manager : Account, Serializable
    {
        public System.Collections.Generic.List<Room> room;


        public string[] ToCSV()
        {
            string[] csvValues =
            {
                id.ToString(),
                name,
                surname,
                password,
                username,
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            id = int.Parse(values[0]);
            name = values[1];
            surname = values[2];
            password = values[3];
            username = values[4];
        }
    }
}