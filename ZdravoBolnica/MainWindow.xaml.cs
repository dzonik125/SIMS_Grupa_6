﻿
using SIMS.DoctorView;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ManagerUI mui;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow pWin = new PatientWindow();
            this.Close();
            pWin.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Appointments appointments = Appointments.Instance;
            appointments.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ManagerUI mui = ManagerUI.Instance;
            mui.Show();
            this.Close();
        }
    }
}
