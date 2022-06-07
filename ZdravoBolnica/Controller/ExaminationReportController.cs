using Model;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller
{
    public class ExaminationReportController
    {
        public ExaminationReportService examinationReportService = new ExaminationReportService();

        public void Create(ExaminationReport entity)
        {
            examinationReportService.Create(entity);
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
            return examinationReportService.FindAll();
        }

        public ExaminationReport FindById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(ExaminationReport entity)
        {
            examinationReportService.Update(entity);
        }
        public List<ExaminationReport> findReportsByMRecordId(int id)
        {
            return examinationReportService.findReportsByMRecordId(id);
        }

        public void bindReporswithDoctors(List<ExaminationReport> reports, List<Doctor> doctors)
        {
            examinationReportService.bindReporswithDoctors(reports, doctors);
        }
        public void bindReportswithAppointments(List<ExaminationReport> reports, List<Appointment> appointments)
        {
            examinationReportService.bindReportswithAppointments(reports, appointments);
        }
    }
}
