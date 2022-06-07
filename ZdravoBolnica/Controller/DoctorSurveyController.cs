using System.Collections.Generic;
using Model;
using SIMS.Model;
using SIMS.Service;

namespace SIMS.Controller
{
    public class DoctorSurveyController
    {
        private DoctorSurveyService doctorSurveyService = new DoctorSurveyService();
        public List<DoctorSurvey> FindSurveyForDoctor(Doctor doctor)
        {
            return doctorSurveyService.GetSurveyForDoctor(doctor);
        }
    }
}