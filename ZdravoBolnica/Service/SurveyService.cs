using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Service;
using SIMS.Model;
using SIMS.Repository;

namespace SIMS.Service
{
    class SurveyService
    {
        private SurveyRepository sr = new SurveyRepository();
        private AppointmentService aser = new AppointmentService();
        private DateTime n = new DateTime(1000, 1, 1);

        public List<Survey> FindAll()
        {
            return sr.FindAll();
        }

        public void CreateSurveysForPatient(int id)
        {
            List<Appointment> apps = aser.GetAllAppointmentsForPatient(id);
            List<Survey> survs = sr.FindAll();
            CheckWhichSurveysShouldBeMade(apps, survs);
        }

        public void CheckWhichSurveysShouldBeMade(List<Appointment> apps, List<Survey> survs)
        {
            bool dontAdd = false;
            foreach (Appointment a in apps)
            {
                if (a.startTime.AddMinutes(30) < DateTime.Now)
                {
                    if (survs.Count == 0)
                    {
                        Survey s = new Survey();
                        s.sentToUser = DateTime.Now;
                        s.completed = new DateTime(2000, 12, 1);
                        Create(s);
                    }

                    foreach (Survey s in survs)
                    {
                        if (s.sentToUser == a.startTime.AddMinutes(30))
                        {
                            dontAdd = true;
                            break;
                        }
                    }

                    if (!dontAdd)
                    {
                        Survey s = new Survey();
                        s.sentToUser = a.startTime.AddMinutes(30);
                        s.completed = n;
                        Create(s);
                    }
                }
            }
        }

        public Survey FindById(int id)
        {
            return sr.FindById(id);
        }

        public void DeleteAll()
        {
            sr.DeleteAll();
        }

        public void DeleteById(int id)
        {
            sr.DeleteById(id);
        }

        public void Create(Survey s)
        {
            sr.Create(s);
        }

        public void Update(Survey s)
        {
            sr.Update(s);
        }

    }
}
