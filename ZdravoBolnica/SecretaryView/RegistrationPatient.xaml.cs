using Model;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace SIMS.SecretaryView
{
    /// <summary>
    /// Interaction logic for RegistrationPatient.xaml
    /// </summary>
    public partial class RegistrationPatient : Page
    {


        public RegistrationPatient()
        {
            InitializeComponent();
        }
        private static RegistrationPatient _instance;
        private ObservableCollection<Patient> _appointments;





        /*  private PatientController pc = new PatientController();
        private static RegistrationPatient instance = new RegistrationPatient();

        public static RegistrationPatient Instance
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

        public RegistrationPatient()
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







        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            SecretaryView.Instance.SetContent(new NewPatientPage());
        }

        private void NewGuestPatient_Click(object sender, RoutedEventArgs e)
        {
            SecretaryView.Instance.SetContent(new NewGuestPatientPage(1));
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
    }*/


    }
}