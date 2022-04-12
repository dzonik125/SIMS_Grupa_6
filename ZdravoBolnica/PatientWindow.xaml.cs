﻿using Controller;
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
            List<Appointment> apps = ac.getFutureAppointmentsForPatient("1");
            foreach (Appointment a in apps)
            {
                Doctor d = dc.GetDoctorByID(a.doctorID);
                a.Doctor = d;
                Room r = rc.FindRoomById(a.roomID);
                a.Room = r;
                list.Add(a);
            }
            refresh();
            //appointments.Add(new Model.Appointment { duration = "30" , new Model.Doctor{ name = "dadwa" } });

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MakeAppointmentPatient map = new MakeAppointmentPatient();
            map.ShowDialog();

        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Appointment selectedAppointment = patientMadeAppointmentsTable.SelectedItem as Appointment;
            if (selectedAppointment== null)
            {
                MessageBox.Show("Izabrati termin:");
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
            List<Appointment> allAppointments = ac.GetAllApointments();
            List<Doctor> doctors = dc.GetAllDoctors();
            List<Room> rooms = rc.FindAll();
            ac.bindDoctorsWithAppointments(doctors, allAppointments);
            ac.bindRoomsWithAppointments(rooms, allAppointments);
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
    }
}
