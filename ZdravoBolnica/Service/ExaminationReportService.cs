using Model;
using SIMS.Model;
using SIMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service
{
    public class ExaminationReportService
    {
        public ExaminationReportRepository examinationReportRepository = new ExaminationReportRepository();
        public void Create(ExaminationReport entity)
        {
            examinationReportRepository.Create(entity);
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ExaminationReport> FindAll()
        {
            return examinationReportRepository.FindAll();
        }

        public ExaminationReport FindById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(ExaminationReport entity)
        {
            throw new NotImplementedException();
        }

        public List<ExaminationReport> findReportsByMRecordId(int id)
        {
            return examinationReportRepository.findReportsByMRecordId(id);
        }

        public void bindReporswithDoctors(List<ExaminationReport> reports, List<Doctor> doctors)
        {
            foreach (Doctor d in doctors)
            {
                foreach (ExaminationReport e in reports)
                {
                    if (e.doctor.id == d.id)
                    {
                        e.doctor = d;
                    }
                }
            }
        }

        public void bindReportswithAppointments(List<ExaminationReport> reports, List<Appointment> appointments)
        {
            foreach (Appointment a in appointments)
            {
                foreach (ExaminationReport e in reports)
                {
                    if (e.appointment.id == a.id)
                    {
                        e.appointment = a;
                    }
                }
            }

        }
    }
}
