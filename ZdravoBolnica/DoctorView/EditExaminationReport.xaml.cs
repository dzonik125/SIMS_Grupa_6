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
    /// Interaction logic for EditExaminationReport.xaml
    /// </summary>
    public partial class EditExaminationReport : Window
    {
        ExaminationReport examinationReport = new();
        ExaminationReportController examinationReportController = new ExaminationReportController();
        public EditExaminationReport(ExaminationReport e)
        {
            InitializeComponent();
            examinationReport = e;
            MainProblems.Text = e.mainProblems;
            Diagnosis.Text = e.diagnosis;
            Anamnesis.Text = e.diagnosis;
            Therapy.Text = e.treatmentPlan;
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            examinationReport.diagnosis = Diagnosis.Text;
            examinationReport.anamnesis = Anamnesis.Text;
            examinationReport.mainProblems = MainProblems.Text;
            examinationReport.treatmentPlan = Therapy.Text;
            examinationReportController.Update(examinationReport);
            PatientMedicalRecord.Instance.refreshExaminationReports();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
