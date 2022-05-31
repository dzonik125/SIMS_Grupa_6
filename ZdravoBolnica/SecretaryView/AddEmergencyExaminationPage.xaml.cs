using Controller;
using Model;
using SIMS.Model;
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
        // public List<Specialization> specializations;
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

        public AddEmergencyExaminationPage(AppointmentType type)
        {
            appointmentType = type;
            RoomType roomType = type == AppointmentType.examination ? RoomType.examination : RoomType.surgery;
            InitializeComponent();
            patients = pc.FindAllPatients();

            Specialization.ItemsSource = Conversion.GetSpecializationType();
            Specialization.SelectedIndex = 0;

            // specialization = (Specialization)Specialization.SelectedItem;
            //  appointments = ac.getAppointmentBySpecialization((Specialization)Specialization.SelectedIndex);

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
            else
                ac.SaveBusyAppointment(first, patient, Conversion.StringToSpecialization(spec));
        }

        private void Close_Click(object sender, System.Windows.RoutedEventArgs e)
        {

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

            app = ac.GetFirstFreeAppointmentInOneHour(Conversion.StringToSpecialization(spec), (Patient)PatientBox.SelectedItem);
            if (app != null)
            {
                TimeBox.Items.Add(app.startTime);
                app.patient = (Patient)PatientBox.SelectedItem;
                app.duration = 30;
            }
            else
            {
                first = ac.GetFirstAppointmentForDoctor(ac.GetAppointmentsForDoctors(dc.FindBySpecialization(Conversion.StringToSpecialization(spec))));
                patient = (Patient)PatientBox.SelectedItem;
                TimeBox.Items.Add(first.startTime);
            }
            
            //  System.Diagnostics.Trace.WriteLine(help);
            // int id = -1;

            //List<DateTime> datess = new List<DateTime>();


            /*foreach (Doctor doc in dc.GetAllDoctors())
            {

                // List<Appointment> apps = ac.getFutureAppointmentsForDoctor(doc.id);


                if (Conversion.SpecializationToString(doc.Specialization).Equals(help))
                {
                    id = doc.id;
                    foreach (DateTime dt in ac.getTenNextFreeAppointmentsForDoctorToday(doc.id))
                    {

                        //   Boolean b = ac.IsExist(doc.appointments[0].id);
                        datess.Add(dt);
                        //TimeBox.Items.Add(dt.ToString() + "," + doc.name + " " + doc.surname);
                    }

                }
            }*/

        }
    }
}
