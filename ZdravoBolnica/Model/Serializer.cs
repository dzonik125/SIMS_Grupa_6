// File:    Serializer.cs
// Author:  dZoNi
// Created: Thursday, April 7, 2022 16:18:24
// Purpose: Definition of Class Serializer

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Model
{
    class Serializer<T> where T : Serializable, new()
    {
        private static char DELIMITER = '|';
        public void toCSV(string fileName, List<T> objects)
        {
            using StreamWriter streamWriter = new StreamWriter(fileName);
            foreach (Serializable obj in objects)
            {
                string line = string.Join(DELIMITER, obj.ToCSV());
                streamWriter.WriteLine(line);
            }
        }

        public List<T> fromCSV(string fileName)
        {
            List<T> objects = new List<T>();
            foreach (string line in File.ReadLines(fileName))
            {
                string[] csvValues = line.Split(DELIMITER);
                T obj = new T();
                obj.FromCSV(csvValues);
                objects.Add(obj);
            }
            return objects;
        }
    }
}