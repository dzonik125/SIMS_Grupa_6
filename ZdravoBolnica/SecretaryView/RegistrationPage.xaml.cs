using Model;
using SIMS.SecretaryView.ViewModel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.SecretaryView
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private PatientController pc = new PatientController();
        private static RegistrationPage instance = new RegistrationPage();

        public static RegistrationPage Instance
        {
            get
            {
                return instance;
            }
        }

        /* public ObservableCollection<Patient> list
         {
             get;
             set;
         }*/

        public RegistrationPage()
        {
            InitializeComponent();
            this.DataContext = new RegistrationPageViewModel();

            /*  list = new ObservableCollection<Patient>();
              List<Patient> patients = new List<Patient>();

              patients = pc.FindAllPatients();
              foreach (Patient p in patients)
              {
                  list.Add(p);
              }*/
        }

        public void refresh()
        {
            //  list.Clear();
            List<Patient> patients = new List<Patient>();
            patients = pc.FindAllPatients();
            foreach (Patient p in patients)
            {
                //   list.Add(p);
            }
        }


        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            SecretaryView.Instance.SetContent(new NewPatientPage());
        }

        private void NewGuestPatient_Click(object sender, RoutedEventArgs e)
        {
            SecretaryView.Instance.SetContent(new NewGuestPatientPage(1));
        }

        private void EditPatient_Click(object sender, RoutedEventArgs e)
        {
            Patient selectedPatient = patientTable.SelectedItem as Patient;
            if (selectedPatient == null)
            {
                MessageBox.Show("Izabrati pacijenta za izmenu:");
                return;
            }
            SecretaryView.Instance.SetContent(new EditPatientPage(selectedPatient));
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
                refresh();
            }
        }

        private void DataGridCell_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Patient selectedPatient = patientTable.SelectedItem as Patient;
            SecretaryView.Instance.SetContent(new EditPatientPage(selectedPatient));


        }
    }
}
