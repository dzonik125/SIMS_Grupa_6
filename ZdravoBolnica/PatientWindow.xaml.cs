using Controller;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SIMS
{
    /// <summary>
    /// Interaction logic for PatientWindow.xaml
    /// </summary>
    public partial class PatientWindow : Window
    {

        private static PatientWindow instance = new PatientWindow();
        private AppointmentController ac = new AppointmentController();
        private DoctorController dc = new DoctorController();
        public static PatientWindow Instance
        {
            get
            {
                return instance;
            }
        }

        public ObservableCollection<Appointment> list
        {
            get;
            set;
        }

        public DoctorRepository dr = new DoctorRepository();

        public PatientWindow()
        {

            InitializeComponent();
            this.DataContext = this;
            list = new ObservableCollection<Appointment>();
            List<Appointment> apps = ac.GetAllApointments();
            foreach (Appointment a in apps)
            {
                Doctor d = dc.GetDoctorByID(a.doctorID);
                a.Doctor = d;
                list.Add(a);
            }
            //appointments.Add(new Model.Appointment { duration = "30" , new Model.Doctor{ name = "dadwa" } });

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MakeAppointmentPatient map = new MakeAppointmentPatient();
            map.ShowDialog();

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void refresh()
        {
            List<Appointment> allAppointments = ac.GetAllApointments();
            list.Clear();

        }

    }
}
