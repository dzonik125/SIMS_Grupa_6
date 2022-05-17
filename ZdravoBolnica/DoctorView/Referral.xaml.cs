﻿using Controller;
using Model;
using Service;
using SIMS.Model;
using SIMS.Util;
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
    /// Interaction logic for Referral.xaml
    /// </summary>
    public partial class Referral : Window
    {
        public Patient selectedPatient = new Patient();
        public AppointmentController apc = new AppointmentController();
        public AppointmentService aps = new AppointmentService();
        public DoctorController dc = new DoctorController();
        public Referral(Patient p)
        {  
            InitializeComponent();
            selectedPatient = p;
            SpecializationBox.ItemsSource = Conversion.GetSpecializationType();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            


            Appointment a = new Appointment();
            Appointment temp = (Time.SelectedItem as Appointment);
            a.startTime = temp.startTime;
            a.Room = temp.Room;
            a.Doctor = dc.findBySpecialization(Conversion.StringToSpecialization(SpecializationBox.Text))[0];
            a.duration = int.Parse(Duration.Text);
            a.patient = selectedPatient;
            if ((bool)Surgery.IsChecked)
                a.Type = AppointmentType.surgery;
            else
                a.Type = AppointmentType.examination;
            apc.SaveAppointment(a);
            Appointments.Instance.Refresh();
            this.Close();

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
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
            if ((bool)Surgery.IsChecked)
                dateRange.type = RoomType.surgery;
            else
                dateRange.type = RoomType.examination;
            dateRange.specializationType = Conversion.StringToSpecialization(SpecializationBox.Text);
            List<Appointment> appo = aps.findFreeTermsForReferral(dateRange, selectedPatient);
            Time.ItemsSource = appo;
        }
    }
}
