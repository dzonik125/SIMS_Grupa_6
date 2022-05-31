using Controller;
using Model;

using SIMS.Model;
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

namespace SIMS.DoctorView
{
    /// <summary>
    /// Interaction logic for Appointments.xaml
    /// </summary>
    public partial class Appointments : Page
    {
        public static Appointments instance = new Appointments();
        public  Doctor doctorUser { get; set; }

        private AppointmentController appController = new AppointmentController();
        private AccountController patientController = new AccountController();
        private DoctorController doctorController = new DoctorController();
        private RoomController roomController = new RoomController();
        private ObservableCollection<Appointment> apps;

        public ObservableCollection<Appointment> Apps { get; set; }

        public static Appointments Instance
        {
            get
            {
                return instance;
            }
        }


        private Appointments()
        {
            InitializeComponent();
            this.DataContext = this;
            Apps = new ObservableCollection<Appointment>();
            DoctorWindow dw = DoctorWindow.instance;
            doctorUser = new Doctor();
            doctorUser = dw.doctorUser;
            
            Refresh();
        }


        public void Refresh()
        {
            Apps.Clear();
            List<Appointment> appointments = new();
            appointments = appController.GetFutureAppointmentsForDoctor(doctorUser.id);
            List<Patient> patients = patientController.FindAllAccounts();
            List<Room> rooms = roomController.FindAll();
            appController.BindPatientsWithAppointments(patients, appointments);
            appController.BindRoomsWithAppointments(rooms, appointments);

            foreach (Appointment a in appointments)
            {
                if (a.Room == null || a.patient==null)
                    continue;
                Apps.Add(a);
            }
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            AppointmentType type = AppointmentType.examination;
            AddAppointment ap = new AddAppointment(type);
            ap.ShowDialog();
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            Appointment selectedAppointment = dataGridAppointments.SelectedItem as Appointment;
            if (selectedAppointment == null)
            {
                MessageBox.Show("Izabrati termin.");
                return;
            }

            EditAppointment ep = new EditAppointment(selectedAppointment);
            ep.ShowDialog();
        }

        private void Izbrisi_Click(object sender, RoutedEventArgs e)
        {
            Appointment selectedAppointment = dataGridAppointments.SelectedItem as Appointment;
            if (selectedAppointment == null)
            {
                MessageBox.Show("Izabrati termin.");
                return;
            }
            appController.DeleteAppointmentById(selectedAppointment.id);
            Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppointmentType type = AppointmentType.surgery;
            AddAppointment ap = new AddAppointment(type);
            ap.ShowDialog();

        }
    }
}
