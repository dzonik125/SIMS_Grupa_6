// File:    Secretary.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:12:55
// Purpose: Definition of Class Secretary

namespace Model
{
    public class Secretary : Account, Serializable
    {
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