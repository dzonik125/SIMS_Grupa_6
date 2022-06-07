using System.Collections.Generic;
using Model;
using SIMS.Model;
using SIMS.Repository;

namespace SIMS.Service
{
    public class DoctorSurveyService
    {
        private DoctroSurveyRepository doctorSurveyRepository = new DoctroSurveyRepository();

        public List<DoctorSurvey> GetSurveyForDoctor(Doctor doctor)
        {
            List<DoctorSurvey> doctorSurveys = new List<DoctorSurvey>();
            foreach (DoctorSurvey doctorSurvey in FindSurveysForDoctor(doctor))
            {
                GetAvarageGrade(doctorSurvey);
                GetNumberOfGrades(doctorSurvey);
                doctorSurveys.Add(doctorSurvey);
            }

            return doctorSurveys;

        }

        private List<DoctorSurvey> FindSurveysForDoctor(Doctor doctor)
        {
            List<DoctorSurvey> doctorSurveysList = new List<DoctorSurvey>();
            foreach (DoctorSurvey doctorSurvey in doctorSurveyRepository.FindAll())
            {
                if (doctorSurvey.doctor.id == doctor.id)
                {
                    doctorSurveysList.Add(doctorSurvey);
                }
            }

            return doctorSurveysList;
        }
          private void GetNumberOfGrades(DoctorSurvey doctorSurvey)
        {
            SetNumberOfGradesToZero(doctorSurvey);
            foreach (int grade in doctorSurvey.answers)
            {
                CountAllGrades(doctorSurvey, grade);
            }
        }

        private void SetNumberOfGradesToZero(DoctorSurvey doctorSurvey)
        {
            doctorSurvey.NumberOfOnes = 0;
            doctorSurvey.NumberOfTwos = 0;
            doctorSurvey.NumberOfThrees = 0;
            doctorSurvey.NumberOfFours = 0;
            doctorSurvey.NumberOfFives = 0;
        }

        private static void CountAllGrades(DoctorSurvey doctorSurvey, int grade)
        {
            CountOnes(doctorSurvey, grade);
            CountTwos(doctorSurvey, grade);
            CountThrees(doctorSurvey, grade);
            CountFours(doctorSurvey, grade);
            CountFives(doctorSurvey, grade);
        }

        private static void CountFives(DoctorSurvey doctorSurvey, int grade)
        {
            if (grade == 5)
            {
                doctorSurvey.NumberOfFives++;
            }
        }

        private static void CountFours(DoctorSurvey doctorSurvey, int grade)
        {
            if (grade == 4)
            {
                doctorSurvey.NumberOfFours++;
            }
        }

        private static void CountThrees(DoctorSurvey doctorSurvey, int grade)
        {
            if (grade == 3)
            {
                doctorSurvey.NumberOfThrees++;
            }
        }

        private static void CountTwos(DoctorSurvey doctorSurvey, int grade)
        {
            if (grade == 2)
            {
                doctorSurvey.NumberOfTwos++;
            }
        }

        private static void CountOnes(DoctorSurvey doctorSurvey, int grade)
        {
            if (grade == 1)
            {
                doctorSurvey.NumberOfOnes++;
            }
        }

        private void GetAvarageGrade(DoctorSurvey doctorSurvey)
        {
            int sum = 0;
            int counter = 0;
            foreach (int grade in doctorSurvey.answers)
            {
                sum += grade;
                counter++;
            }
            doctorSurvey.AvarageGrade = sum / counter;
        }
    }
}