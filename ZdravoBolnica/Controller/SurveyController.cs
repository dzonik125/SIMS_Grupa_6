using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Model;
using SIMS.Service;

namespace SIMS.Controller
{
    class SurveyController
    {
        private SurveyService ss = new SurveyService();
        public List<Survey> FindAll()
        {
            return ss.FindAll();
        }

        public void CreateSurveysForPatient(int id)
        {
            ss.CreateSurveysForPatient(id);
        }

        public Survey FindById(int id)
        {
            return ss.FindById(id);
        }

        public void DeleteAll()
        {
            ss.DeleteAll();
        }

        public void DeleteById(int id)
        {
            ss.DeleteById(id);
        }

        public void Create(Survey s)
        {
            ss.Create(s);
        }

        public void Update(Survey s)
        {
            ss.Update(s);
        }
    }
}
