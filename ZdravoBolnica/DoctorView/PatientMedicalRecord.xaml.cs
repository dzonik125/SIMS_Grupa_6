using Model;
using SIMS.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using SIMS.Model;
using Controller;

namespace SIMS.DoctorView
{
    /// <summary>
    /// Interaction logic for PatientMedicalRecord.xaml
    /// </summary>
    public partial class PatientMedicalRecord : Window
    {

        public static PatientMedicalRecord instance = new PatientMedicalRecord();
        public ObservableCollection<Prescription> prescriptions { get; set; }
        public ObservableCollection<ExaminationReport> examinationReports { get; set; }
        public PrescriptionController prc = new PrescriptionController();
        public ExaminationReportController erc = new ExaminationReportController();
        public DoctorController doctorController = new DoctorController();
        public MedicationController medicationController = new MedicationController();
        public Patient patient { get; set; }
        private PatientMedicalRecord()
        {

            
            InitializeComponent();
            this.DataContext = this;
            prescriptions = new ObservableCollection<Prescription>();
            examinationReports = new ObservableCollection<ExaminationReport>();
            setSelectedPatient();
            refreshPrescriptions();
            refreshExaminationReports();
        }

        public static PatientMedicalRecord Instance
        {
            get
            {
                return instance;
            }
        }

        public void setSelectedPatient()
        {
            PatientsView pw = PatientsView.Instance;
            patient = new Patient();
            patient = pw.selectedPatient;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrescriptionView prescription = new PrescriptionView();
            prescription.Show();
        }

        public void refreshPrescriptions()
        {


            prescriptions.Clear();
            List<Prescription> prescs = new();
            prescs = prc.findPrescriptionsByMRecordId(patient.medicalRecord.id);
            List <Doctor> doctors = doctorController.GetAllDoctors();
            List<Medication> medications = medicationController.FindAll();
            prc.bindPrescriptionsWithDoctors(prescs, doctors);
            prc.bindPrescriptionsWithMedications(prescs, medications);
            foreach (Prescription a in prescs)
            {
                prescriptions.Add(a);
            }
        }

        public void refreshExaminationReports()
        {
            examinationReports.Clear();
            List<ExaminationReport> exReports = new();
            exReports = erc.findReportsByMRecordId(patient.medicalRecord.id);
            List <Doctor> doctors = doctorController.GetAllDoctors();
            erc.bindReporswithDoctors(exReports, doctors);
            foreach(ExaminationReport e in exReports)
            {
                examinationReports.Add(e);
            }

        }
    }
}
