using Controller;
using Model;
using Service;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS.DoctorView
{
    /// <summary>
    /// Interaction logic for TermHistory.xaml
    /// </summary>
    public partial class TermHistory : Page
    {
        public ObservableCollection<Appointment> appointments { get; set; }

        public AppointmentService appController = new AppointmentService();
        public PatientController patientController = new PatientController();
        public RoomController roomController = new RoomController();
        public TermHistory()
        {
            InitializeComponent();
            this.DataContext = this;
            appointments = new ObservableCollection<Appointment>();
            toList();

        }

        private void toList()
        {
            List<Appointment> apps = new List<Appointment>();
            apps = appController.getPastAppointmentsForDoctor(1);
            List<Patient> patients = patientController.FindAllPatients();
            List<Room> rooms = roomController.FindAll();
            appController.bindPatientsWithAppointments(patients, apps);
            appController.bindRoomsWithAppointments(rooms, apps);
            foreach (Appointment a in apps)
            {
                appointments.Add(a);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PastAppointments appointments = new PastAppointments();
            appointments.ShowDialog();
        }
    }
}
