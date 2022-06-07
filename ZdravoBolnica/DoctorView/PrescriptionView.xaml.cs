using Controller;
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
    /// Interaction logic for Perscription.xaml
    /// </summary>
    public partial class PrescriptionView : Window
    {
        public MedicationController medicationController = new MedicationController();
        public List<Medication> medications = new List<Medication>();
        public PrescriptionController prc = new PrescriptionController();
        public MedicalRecordController medicalRecordController = new MedicalRecordController();
        public PrescriptionView()
        {
            InitializeComponent();
            initMedications();
        }

        public void initMedications()
        {
            medications = medicationController.FindAll();
            DrugComboBox.ItemsSource = medications;
        }

       

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            Prescription prescription = new Prescription();
            prescription.medication = new Medication();
            prescription.medication.id = getSelectedMedication().id;
            prescription.doctor = new Doctor();
            prescription.doctor.id = DoctorWindow.Instance.doctorUser.id;
            prescription.medicalRecord = new MedicalRecord();
            prescription.medicalRecord.id = PatientMedicalRecord.Instance.patient.medicalRecord.id;
            prescription.comment = Comment.Text;
            prescription.endTime = DateTime.Parse(EndTime.Text);
            prescription.startTime = DateTime.Parse(StartTime.Text);
            prescription.timesPerDay = int.Parse(Frequency.Text);
            prescription.prescriptionDate = DateTime.Now;
            MedicalRecord mr = medicalRecordController.FindMedicalRecordById(prescription.medicalRecord.id);
            
            bool allergic = medicalRecordController.checkIfPatientisAllergic(getSelectedMedication(), mr);
            if(allergic)
            {
                MessageBox.Show("Pacijent je alergican na " + getSelectedMedication().name + "!");
                return;
            }
            else
            {
                prc.Create(prescription);
                PatientMedicalRecord.Instance.refreshPrescriptions();
                this.Close();
                MessageBox.Show("Recept je uspesno kreiran");
                
            }



            

        }

        public Medication getSelectedMedication()
        {
            Medication med = medications[DrugComboBox.SelectedIndex];
            return med;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void DrugComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
