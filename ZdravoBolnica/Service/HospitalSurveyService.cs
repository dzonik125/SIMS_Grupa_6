using System.Collections.Generic;
using Model;
using SIMS.Model;
using SIMS.Repository;

namespace SIMS.Service
{
    public class HospitalSurveyService
    {
        private HospitalSurveyRepository hospitalSurveyRepository = new HospitalSurveyRepository();
        public List<HospitalSurvey> FindAll()
        {
            List<HospitalSurvey> hospitalSurveysList = new List<HospitalSurvey>();
            foreach (HospitalSurvey hospitalSurvey in hospitalSurveyRepository.FindAll())
            {
                GetAvarageGrade(hospitalSurvey);
                GetNumberOfGrades(hospitalSurvey);
                hospitalSurveysList.Add(hospitalSurvey);
            }
            return hospitalSurveysList;
        }

        private void GetNumberOfGrades(HospitalSurvey hospitalSurvey)
        {
            SetNumberOfGradesToZero(hospitalSurvey);
            foreach (int grade in hospitalSurvey.answers)
            {
                CountAllGrades(hospitalSurvey, grade);
            }
        }

        private void SetNumberOfGradesToZero(HospitalSurvey hospitalSurvey)
        {
            hospitalSurvey.NumberOfOnes = 0;
            hospitalSurvey.NumberOfTwos = 0;
            hospitalSurvey.NumberOfThrees = 0;
            hospitalSurvey.NumberOfFours = 0;
            hospitalSurvey.NumberOfFives = 0;
        }

        private static void CountAllGrades(HospitalSurvey hospitalSurvey, int grade)
        {
            CountOnes(hospitalSurvey, grade);
            CountTwos(hospitalSurvey, grade);
            CountThrees(hospitalSurvey, grade);
            CountFours(hospitalSurvey, grade);
            CountFives(hospitalSurvey, grade);
        }

        private static void CountFives(HospitalSurvey hospitalSurvey, int grade)
        {
            if (grade == 5)
            {
                hospitalSurvey.NumberOfFives++;
            }
        }

        private static void CountFours(HospitalSurvey hospitalSurvey, int grade)
        {
            if (grade == 4)
            {
                hospitalSurvey.NumberOfFours++;
            }
        }

        private static void CountThrees(HospitalSurvey hospitalSurvey, int grade)
        {
            if (grade == 3)
            {
                hospitalSurvey.NumberOfThrees++;
            }
        }

        private static void CountTwos(HospitalSurvey hospitalSurvey, int grade)
        {
            if (grade == 2)
            {
                hospitalSurvey.NumberOfTwos++;
            }
        }

        private static void CountOnes(HospitalSurvey hospitalSurvey, int grade)
        {
            if (grade == 1)
            {
                hospitalSurvey.NumberOfOnes++;
            }
        }

        private void GetAvarageGrade(HospitalSurvey hospitalSurvey)
        {
            int sum = 0;
            int counter = 0;
            foreach (int grade in hospitalSurvey.answers)
            {
                sum += grade;
                counter++;
            }
            hospitalSurvey.AvarageGrade = sum / counter;
        }
    }
}