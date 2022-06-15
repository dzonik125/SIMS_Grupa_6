using Model;
using Service;
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
            examinationReportRepository.Update(entity);
        }

        public List<ExaminationReport> findReportsByMRecordId(int id)
        {
            return examinationReportRepository.findReportsByMRecordId(id);
        }

        public void bindReporswithDoctors(List<ExaminationReport> reports)
        {
            DoctorService doctorService = new DoctorService();
            foreach (ExaminationReport examinationReport in reports)
            {
                examinationReport.doctor = doctorService.GetDoctorById(examinationReport.doctor.id);
            }
        }


        public void bindReportswithAppointments(List<ExaminationReport> reports)
        {
            AppointmentService appointmentService = new AppointmentService();
            foreach (ExaminationReport examinationReport in reports)
            {
                examinationReport.appointment = appointmentService.GetAppointmentById(examinationReport.doctor.id);
            }

        }

  
    }
}
