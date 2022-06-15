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
using SIMS.DoctorView;
using SIMS.HCI;
using SIMS.PatientView;

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
        private RoomController rc = new RoomController();
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

        private PatientWindow()
        {

            InitializeComponent();
            this.DataContext = this;
            list = new ObservableCollection<Appointment>();
            List<Appointment> apps = ac.GetFutureAppointmentsForPatient(1);
            foreach (Appointment a in apps)
            {
                Doctor d = dc.GetDoctorById(a.doctor.id);
                a.doctor = d;
                Room r = rc.FindRoomById(a.room.id);
                a.room = r;
                list.Add(a);
            }
            refresh();
            //appointments.Add(new Model.Appointment { duration = "30" , new Model.Doctor{ name = "dadwa" } });
            patientMadeAppointmentsTable.SelectedCellsChanged += Program_MyEvent;

        }

        private void Program_MyEvent(object sender, EventArgs e)
        {
            Appointment selectedAppointment = patientMadeAppointmentsTable.SelectedItem as Appointment;
            if (selectedAppointment == null)
            {
                return;
            }

            if ((selectedAppointment.startTime - DateTime.Now) <= TimeSpan.FromHours(24))
            {
                edit.IsEnabled = false;
                delete.IsEnabled = false;
            }
            else
            {
                edit.IsEnabled = true;
                delete.IsEnabled = true;
            }

            if (selectedAppointment.TimesEdited == 2)
            {
                edit.IsEnabled = false;
                delete.IsEnabled = false;
            }
            else
            {
                edit.IsEnabled = true;
                delete.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MakeAppointmentPatient map = new MakeAppointmentPatient();
            map.ShowDialog();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Appointment selectedAppointment = patientMadeAppointmentsTable.SelectedItem as Appointment;
            if (selectedAppointment== null)
            {
                MessageBox.Show("Izabrati termin");
                return;
            }

            EditPatientAppointment epa = new EditPatientAppointment(selectedAppointment);
            epa.ShowDialog();

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }      
        
         
        public void refresh()
        {
            list.Clear();
            List<Appointment> allAppointments = ac.GetAllAppointments();
            ac.BindDoctorsWithAppointments(allAppointments);
            ac.BindRoomsWithAppointments(allAppointments);
            foreach (Appointment a in allAppointments)
            {
                list.Add(a);
                
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Appointment selectedAppointment = patientMadeAppointmentsTable.SelectedItem as Appointment;
            if (selectedAppointment == null)
            {
                MessageBox.Show("Izabrati termin:");
                return;
            }

            DeletePatientAppointment dpa = new DeletePatientAppointment(selectedAppointment);
            dpa.ShowDialog();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Notifications notifications = new Notifications();
            notifications.Show();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HCI.HCI_Main hm = new HCI_Main();
            hm.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SurveyWindow s = new SurveyWindow();
            s.ShowDialog();
        }
    }
}