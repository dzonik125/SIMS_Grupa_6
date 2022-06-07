using System;
using System.Collections.Generic;
using Model;

namespace SIMS.Model
{
    public class DoctorSurvey:Serializable
    {
        public Doctor doctor { get; set; }
        public string Question { get; set; }
        public List<int> answers = new List<int>();
        public double AvarageGrade { get; set; }
        public int NumberOfOnes { get; set; }
        public int NumberOfTwos { get; set; }
        public int NumberOfThrees { get; set; }
        public int NumberOfFours { get; set; }
        public int NumberOfFives { get; set; }
        public string answer = "";
        public string[] ToCSV()
        {
            foreach (int a in answers)
            {
                answer = answer + a + ",";
            }
            if (answer != "")
            {
                answer = answer.Remove(answer.Length - 1, 1);
            }
            string[] csvValues =
            {
                doctor.id.ToString(),
                Question.ToString(),
                answer.ToString(),
            };

            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            doctor = new Doctor();
            doctor.id =Int32.Parse(values[0]);
            Question = values[1];
            List<int> grades = new List<int>();
            if (values[2] != "")
            {
                string[] parts = values[2].Split(',');
                foreach (string s in parts)
                {
                    grades.Add(int.Parse(s));
                }
                foreach (int i in grades)
                {
                    answers.Add(i);
                }
            }
        }
    }
}