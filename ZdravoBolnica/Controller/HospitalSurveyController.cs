using SIMS.Model;
using System;
using System.Collections.Generic;
using SIMS.Service;

namespace SIMS.Controller
{
    public class HospitalSurveyController
    {
        private HospitalSurveyService hospitalSurveyService = new HospitalSurveyService();
        public List<HospitalSurvey> FindAll()
        {
            return hospitalSurveyService.FindAll();
        }
    }
}