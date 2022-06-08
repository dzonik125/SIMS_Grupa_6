using Controller;
using Model;
using Service;
using SIMS.Model;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.DoctorView
{
    /// <summary>
    /// Interaction logic for AddAppointment.xaml
    /// </summary>
    public partial class AddAppointment : Window
    {

        public List<Patient> patients;
        public List<Room> rooms;
        public PatientController pc = new PatientController();
        public RoomController rc = new RoomController();
        public List<Appointment> potenitalAppointments = new List<Appointment>();
        public AppointmentController ac = new AppointmentController();
        public AppointmentService aps = new AppointmentService();
        public AppointmentType appointmentType;
        public AddAppointment(AppointmentType type)
        {
            appointmentType = type;
            RoomType roomType = type == AppointmentType.examination ? RoomType.examination : RoomType.surgery;
            InitializeComponent();
            patients = pc.FindAllPatients();
            rooms = rc.getRoomsByType(roomType);
            PatientBox.ItemsSource = patients;
            RoomBox.ItemsSource = rooms;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            Appointments appointments = Appointments.Instance;
          
            Appointment appointment = new Appointment();
            appointment = getSelectedAppointment();
            appointment.duration = int.Parse(Duration.Text);
            appointment.Type = appointmentType;
            appointment.patient = new Patient();
            appointment.patient = getSelectedPatient();
            ac.SaveAppointment(appointment);
            this.Close();
            appointments.Refresh();
            

        }

        public Patient getSelectedPatient()
        {
            Patient p = patients[PatientBox.SelectedIndex];
            return p;
        }

        public Room getSelectedRoom()
        {
            Room r = rooms[RoomBox.SelectedIndex];
            return r;
        }

        public Appointment getSelectedAppointment()
        {
            Appointment a = potenitalAppointments[Time.SelectedIndex];
            return a;
        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EndTime_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateRange dateRange = new();
            dateRange.startTime = (DateTime)StartTime.SelectedDate;
            dateRange.startTime = dateRange.startTime.AddHours(8);
            dateRange.endTime = (DateTime)EndTime.SelectedDate;
            dateRange.duration = double.Parse(Duration.Text);
            dateRange.type = RoomType.examination;
            dateRange.specializationType = Specialization.general;

            potenitalAppointments = aps.findFreeTermsForReferral(dateRange, getSelectedPatient());
            Time.ItemsSource = potenitalAppointments;

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
