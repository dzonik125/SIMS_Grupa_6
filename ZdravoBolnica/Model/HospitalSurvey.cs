using System.Collections.Generic;
using Model;

namespace SIMS.Model
{
    public class HospitalSurvey : Serializable
    {
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
                Question.ToString(),
                answer.ToString(),
            };

            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Question = values[0];
            List<int> grades = new List<int>();
            if (values[1] != "")
            {
                string[] parts = values[1].Split(',');
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