﻿using Controller;
using Model;
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
using SIMS.Model;

namespace SIMS
{
    /// <summary>
    /// Interaction logic for MakeAppointmentPatient.xaml
    /// </summary>
    public partial class MakeAppointmentPatient : Window
    {
        private List<Doctor> doctors;
        private DoctorController dc = new DoctorController();
        private RoomController rc = new RoomController();
        private AppointmentController ac = new AppointmentController();

        public MakeAppointmentPatient()
        {
            InitializeComponent();
            doctors = dc.GetAllDoctors();
            initComboBox();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Appointment app = new Appointment();
            app.Doctor = new Doctor();
            app.Doctor.id = GetSelectedDoctor().id;
            app.startTime = DateTime.Parse(DatePicker.Text + " " + TextBox.Text);
            app.Room = new Room();
            app.Room.id = rc.findFreeRoom(app.startTime).id;
            app.id = DateTime.Now.ToString("yyMMddHHmmssff");
            app.duration = 30;
            app.Type = AppointmentType.examination;
            app.patient = new Patient();
            app.patient = new PatientController().FindAllPatients()[0];
            ac.SaveAppointment(app);
            PatientWindow pw = PatientWindow.Instance;
            pw.refresh();
            this.Close();


        }

        public void initComboBox()
        {
            ComboBox.ItemsSource = doctors;
        }

        private Doctor GetSelectedDoctor()
        {

            Doctor dto = doctors[ComboBox.SelectedIndex];
            System.Diagnostics.Trace.WriteLine(dto.FullName);
            return dto;
        }
    }
}
