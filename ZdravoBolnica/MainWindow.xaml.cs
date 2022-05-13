
using Controller;
using Model;
using SIMS.DoctorView;
using System.Collections.Generic;
using System.Windows;

namespace SIMS
{

    public partial class MainWindow : Window
    {

        public ManagerUI mui;
        public SecretaryUI sui;
        public DoctorController dc = new DoctorController();
        public PatientController pc = new PatientController();
        // public SecretaryView sv;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow pWin = PatientWindow.Instance;
            pWin.Show();
            this.Hide();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DoctorWindow dw = DoctorWindow.Instance;
            dw.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ManagerUI mui = ManagerUI.Instance;
            mui.Show();
            this.Hide();
        }
        private void Secretary_Click(object sender, RoutedEventArgs e)
        {
            SIMS.SecretaryView.SecretaryView sv = SIMS.SecretaryView.SecretaryView.Instance;
            sv.Show();
            this.Hide();

        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            List<Doctor> doctors = dc.GetAllDoctors();
            List<Patient> patients = pc.FindAllPatients();
            foreach (Doctor d in doctors)
            {
                if (username.Text.Equals(d.username) && password.Password.Equals(d.password))
                {
                    DoctorWindow dw = DoctorWindow.Instance;
                    dw.Show();
                    this.Close();
                    return;
                }
            }
            foreach (Patient p in patients)
            {
                if (username.Text.Equals(p.username) && password.Password.Equals(p.password))
                {
                    PatientWindow pWin = PatientWindow.Instance;
                    pWin.Show();
                    this.Close();
                    return;
                }
            }

            if (username.Text.Equals("m") && password.Password.Equals("m"))
            {
                ManagerUI mui = ManagerUI.Instance;
                mui.Show();
                this.Hide();
                return;
            }

            if (username.Text.Equals("s") && password.Password.Equals("s"))
            {
                SIMS.SecretaryView.SecretaryView sv = SIMS.SecretaryView.SecretaryView.Instance;
                sv.Show();
                this.Hide();
                return;
            }
            else
            {
                MessageBox.Show("Netačno korisničko ime ili šifra");

            }


        }
    }
}
