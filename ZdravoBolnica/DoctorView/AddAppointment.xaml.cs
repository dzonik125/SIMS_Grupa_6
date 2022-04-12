﻿using Controller;
using Model;
using SIMS.Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddAppointment.xaml
    /// </summary>
    public partial class AddAppointment : Window
    {

        public List<Patient> patients;
        public List<Room> rooms;
        public AccountController pc = new AccountController();
        public RoomController rc = new RoomController();
        public AppointmentController ac = new AppointmentController();
        public AppointmentType appointmentType;
        public AddAppointment(AppointmentType type)
        {
            appointmentType = type;
            RoomType roomType = type == AppointmentType.examination? RoomType.examination: RoomType.surgery;
            InitializeComponent();
            patients = pc.FindAllAccounts();
            rooms = rc.getRoomsByType(roomType);
            PatientBox.ItemsSource = patients;
            RoomBox.ItemsSource = rooms;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Appointment a = new Appointment();
            a.patientID = getSelectedPatient().id;
            a.roomID = getSelectedRoom().id;
            a.Type = appointmentType;
            a.id = DateTime.Now.ToString("yyMMddHHmmssff");
            String dateAndTime = DatePicker.Text + " " + Time.Text;
            DateTime timeStamp = DateTime.Parse(dateAndTime);
            a.startTime = timeStamp;
            a.duration = int.Parse(Duration.Text);
            Appointments appointments = Appointments.Instance;
            a.doctorID = appointments.doctorUser.id;
            if (ac.IntersectionWithAppointments(a.patientID, a.doctorID, a.roomID, a.startTime, a.duration)) {
                MessageBox.Show("ne.");
                return;
            }
            else {
                ac.SaveAppointment(a);
                this.Close();
                appointments.Refresh();
            }

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
    }
}
