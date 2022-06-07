using Controller;
using Model;
using SIMS.Model;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Windows.Controls;


namespace SIMS.SecretaryView
{
    /// <summary>
    /// Interaction logic for AddEmergencyExaminationPage.xaml
    /// </summary>
    public partial class AddEmergencyExaminationPage : Page
    {
        public List<Patient> patients;
        public List<string> specs;
        public PatientController pc = new PatientController();
        public List<Doctor> doctors;
        public DoctorController dc = new DoctorController();
        public Specialization specialization;
        public AppointmentType appointmentType;
        public List<Appointment> appointments;
        public AppointmentController ac = new AppointmentController();
        private Appointment app;
        private Appointment first;
        private Patient patient;
        private String spec;
        private Scheduler dr = new Scheduler();
        private Appointment busyAppointment = new Appointment();
        public AddEmergencyExaminationPage(AppointmentType type)
        {
            appointmentType = type;
            RoomType roomType = type == AppointmentType.examination ? RoomType.examination : RoomType.surgery;
            InitializeComponent();
            patients = pc.FindAllPatients();

            Specialization.ItemsSource = Conversion.GetSpecializationType();
            Specialization.SelectedIndex = 0;

            PatientBox.ItemsSource = patients;

            TimeBox.ItemsSource = appointments;


        }

        private void Schedule_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            String spec = Specialization.Text;
            if (app != null)
            {
                ac.SaveAppointment(app);
            }
            /*else
                ac.SaveBusyAppointment(first, Conversion.StringToSpecialization(spec));*/
        }

        private void Close_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SecretaryView.Instance.SetContent(new CreateAppointmentPage());
        }

        private void AddGuest_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SecretaryView.Instance.SetContent(new NewGuestPatientPage(0));
        }

        private void Specialization_DropDownClosed(object sender, System.EventArgs e)
        {
            TimeBox.Items.Clear();
            String spec = Specialization.Text;

            app = new Appointment();
            dr.startTime = DateTime.Now.AddHours(0);
            dr.endTime = DateTime.Now.AddHours(1);
            dr.specializationType = Conversion.StringToSpecialization(spec);
            dr.roomType = RoomType.examination;
            dr.duration = 30;
            //app = ac.GetFirstFreeAppointmentInOneHour(dr, (Patient)PatientBox.SelectedItem);
            if (app.room != null)
            {
                TimeBox.Items.Add(app.startTime);
                app.patient = (Patient)PatientBox.SelectedItem;
                app.duration = 30;
            }
            else
            {
                first = ac.GetFirstAppointmentForDoctor(ac.GetAppointmentsForDoctors(dc.FindBySpecialization(Conversion.StringToSpecialization(spec))));
                first.patient = (Patient)PatientBox.SelectedItem;
                TimeBox.Items.Add(first.startTime);
            }
        }
    }
}
