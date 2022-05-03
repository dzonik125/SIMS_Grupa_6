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
        public ObservableCollection<String> allergies { get; set; }
        public PrescriptionController prc = new PrescriptionController();
        public ExaminationReportController erc = new ExaminationReportController();
        public AppointmentController appointmentController = new AppointmentController();
        public DoctorController doctorController = new DoctorController();
        public MedicationController medicationController = new MedicationController();
        public MedicalRecordController medicalRecordController = new MedicalRecordController();
        public RoomController roomController = new RoomController();

        public Patient patient { get; set; }
        private PatientMedicalRecord()
        {

            
            InitializeComponent();
            this.DataContext = this;
            prescriptions = new ObservableCollection<Prescription>();
            examinationReports = new ObservableCollection<ExaminationReport>();
            allergies = new ObservableCollection<String>();
            setSelectedPatient();
            refreshPrescriptions();
            refreshExaminationReports();
            MedicalRecord medicalRecord = medicalRecordController.FindMedicalRecordById(PatientsView.Instance.selectedPatient.medicalRecord.id);
            List<Allergies> allergiesList = medicalRecord.allergies;
            foreach(Allergies a in allergiesList)
            {
                allergies.Add(a.name);
            }
            List<Medication> medications = medicalRecord.medications;
            foreach(Medication m  in medications)
            {
                allergies.Add(m.name);
            }
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
            List<Room> rooms = roomController.FindAll();
            List<Appointment> appointments = appointmentController.GetAllApointments();
            appointmentController.bindRoomsWithAppointments(rooms, appointments);
            erc.bindReportswithAppointments(exReports, appointments);

            foreach (ExaminationReport e in exReports)
            {
                examinationReports.Add(e);
            }

        }

        private void Detalji_Click(object sender, RoutedEventArgs e)
        {
            Prescription prescription = PrescriptionsTable.SelectedItem as Prescription;
            PrescriptionDetails prescriptionDetails = new PrescriptionDetails(prescription);
            prescriptionDetails.Show();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            PrescriptionView prescription = new PrescriptionView();
            prescription.Show();
        }
    }
}
