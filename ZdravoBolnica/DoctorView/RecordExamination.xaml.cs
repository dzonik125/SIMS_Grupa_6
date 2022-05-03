using Model;
using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SIMS.DoctorView
{
    /// <summary>
    /// Interaction logic for RecordExamination.xaml
    /// </summary>
    public partial class RecordExamination : Window
    {
        public ExaminationReportController examinationReportController = new ExaminationReportController();
        public Appointment appointment = new Appointment();
        public RecordExamination(Appointment a)
        {
            appointment = a;
            InitializeComponent();
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            ExaminationReport examinationReport = new ExaminationReport();
            examinationReport.mainProblems = MainProblems.Text;
            examinationReport.reportDate = DateTime.Now;
            examinationReport.anamnesis = Anamnesis.Text;
            examinationReport.diagnosis = Diagnosis.Text;
            examinationReport.doctor = new Doctor();
            examinationReport.doctor.id = DoctorWindow.Instance.doctorUser.id;
            examinationReport.medicalRecord = new MedicalRecord();
            examinationReport.medicalRecord.id = PatientsView.Instance.selectedPatient.medicalRecord.id;
            examinationReport.treatmentPlan = Therapy.Text;
            examinationReport.appointment = new Appointment();
            examinationReport.appointment.id = appointment.id;
            examinationReportController.Create(examinationReport);
            PatientMedicalRecord.Instance.refreshExaminationReports();
            this.Close();
        }
    }
}
