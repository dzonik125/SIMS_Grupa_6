using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace SIMS
{
    /// <summary>
    /// Interaction logic for SecretaryUI.xaml
    /// </summary>
    public partial class SecretaryUI : Window
    {
        private static SecretaryUI instance = new SecretaryUI();
        private PatientController pc = new PatientController();
        public static SecretaryUI Instance
        {
            get
            {
                return instance;
            }
        }

        public ObservableCollection<Patient> list
        {
            get;
            set;
        }
        private SecretaryUI()
        {
            InitializeComponent();
            this.DataContext = this;

            list = new ObservableCollection<Patient>();
            List<Patient> patients = new List<Patient>();

            patients = pc.FindAllPatients();
            foreach (Patient p in patients)
            {
                list.Add(p);
            }

        }

        public void refresh()
        {
            list.Clear();
            List<Patient> patients = new List<Patient>();
            patients = pc.FindAllPatients();
            foreach (Patient p in patients)
            {
                list.Add(p);
            }
        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            NewPatient np = new NewPatient();
            np.ShowDialog();

        }

        private void EditPatient_Click(object sender, RoutedEventArgs e)
        {
            Patient selectedPatient = patientTable.SelectedItem as Patient;
            if (selectedPatient == null)
            {
                MessageBox.Show("Izabrati pacijenta za brisanje:");
                return;
            }
            EditPatient ep = new EditPatient(selectedPatient);
            ep.ShowDialog();
        }

        private void DeletePatient_Click(object sender, RoutedEventArgs e)
        {
            Patient selectedPatient = patientTable.SelectedItem as Patient;
            if (selectedPatient == null)
            {
                MessageBox.Show("Izabrati pacijenta za brisanje.");

            }
            else
            {

                pc.DeletePatientById(selectedPatient.id);
                SecretaryUI sui = SecretaryUI.Instance;
                sui.refresh();
            }
        }

        private void NewGuestPatient_Click(object sender, RoutedEventArgs e)
        {
            NewGuestPatient ngp = new NewGuestPatient();
            ngp.ShowDialog();
        }
    }
}
