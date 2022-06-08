using Controller;
using Model;
using SIMS.Filers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SIMS.DoctorView
{
    /// <summary>
    /// Interaction logic for PatientsView.xaml
    /// </summary>
    public partial class PatientsView : Page
    {

        public static PatientsView instance = new PatientsView();
        public Patient selectedPatient = new Patient();

        public ObservableCollection<Patient> patients { get; set; }
        public PatientController pc = new PatientController();
        public AppointmentController appointmentController = new AppointmentController();

        private PatientsView()
        {
            InitializeComponent();
            this.DataContext = this;
            patients = new ObservableCollection<Patient>();
            Refresh();
        }

        public static PatientsView Instance
        {
            get
            {
                return instance;
            }
        }

        public void Refresh()
        {
            List<Patient> patientList = new();
            patientList = pc.FindAllPatients();
            foreach(Patient p in patientList)
            {
                patients.Add(p);
            }
        }

        private void Record_Click(object sender, RoutedEventArgs e)
        {

            selectedPatient = PatientsDataGrid.SelectedItem as Patient;
            if (selectedPatient == null)
            {
                MessageBox.Show("Izabrati pacijenta.");
                return;
            }
            PatientMedicalRecord pmr = PatientMedicalRecord.Instance;
            pmr.Show();
        }

        private void Examination_Click(object sender, RoutedEventArgs e)
        {
            selectedPatient = PatientsDataGrid.SelectedItem as Patient;
            if (selectedPatient == null)
            {
                MessageBox.Show("Izabrati pacijenta.");
                return;
            }else
            {
                Appointment a = appointmentController.findPatientAppointment(selectedPatient);
                if(a == null)
                {
                    MessageBox.Show("Izabrani pacijent nema ni jedan zakazan termin u ovom periodu!");
                }
                else
                {
                    RecordExamination re = new RecordExamination(a);
                    re.ShowDialog();
                }
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RecordSurgery rs = new RecordSurgery();
            rs.ShowDialog();
        }

        private void Referral_Click(object sender, RoutedEventArgs e)
        {
            selectedPatient = PatientsDataGrid.SelectedItem as Patient;
            Referral referral = new Referral(selectedPatient);
            referral.ShowDialog();
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "";
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            String searchText = SearchBox.Text;

            if (searchText == "")
                SearchBox.Text = "Pretrazi...";

        }

        private void SearchBox_KeyUp(object sender, KeyEventArgs e)
        {
            PatientsFilter filter = new PatientsFilter();
            filter.SetKeywordsFromInput(SearchBox.Text);
            PatientsDataGrid.ItemsSource = filter.ApplyFilters(patients);
        }
    }
}
