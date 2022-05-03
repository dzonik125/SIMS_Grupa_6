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
using Controller;
using Model;
using SIMS.Model;

namespace SIMS.PatientView
{
    /// <summary>
    /// Interaction logic for PatientRecommend.xaml
    /// </summary>
    public partial class PatientRecommend : Window
    {
        private DoctorController dc = new DoctorController();
        private AppointmentController ac = new AppointmentController();
        private RoomController rc = new RoomController();
        private DateTime? start;
        private DateTime? finish;

        public PatientRecommend()
        {
            InitializeComponent();
            cb1.Visibility = Visibility.Collapsed;
            cb2.Visibility = Visibility.Collapsed;
            l1.Visibility = Visibility.Collapsed;
            l2.Visibility = Visibility.Collapsed;
            l3.Visibility = Visibility.Collapsed;
            l4.Visibility = Visibility.Collapsed;
            dp1.Visibility = Visibility.Collapsed;
            dp2.Visibility = Visibility.Collapsed;
            b1.Visibility = Visibility.Collapsed;
            l5.Visibility = Visibility.Collapsed;
            tb1.Visibility = Visibility.Collapsed;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

            cb1.Items.Clear();

            cb1.Visibility = Visibility.Visible;
            cb2.Visibility = Visibility.Visible;
            l1.Visibility = Visibility.Visible;
            l2.Visibility = Visibility.Visible;
            b1.Visibility = Visibility.Visible;

            foreach (Doctor doc in dc.GetAllDoctors())
            {
                cb1.Items.Add(doc.FullName);
            }

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

            cb1.Visibility = Visibility.Collapsed;
            cb2.Visibility = Visibility.Collapsed;
            l1.Visibility = Visibility.Collapsed;
            l2.Visibility = Visibility.Collapsed;
            b1.Visibility = Visibility.Collapsed;

        }

        private void Cb1_OnDropDownClosed(object? sender, EventArgs e)
        {
            cb2.Items.Clear();
            String help = cb1.Text;
            int id = 0;
            
            foreach (Doctor doc in dc.GetAllDoctors())
            {
                if (doc.FullName.Equals(help))
                {
                    id = doc.id;
                    break;
                }
            }

            List<DateTime> dates = ac.getTenNextFreeAppointmentsForDoctor(id);
            

            foreach (DateTime dt in dates)
            {
                cb2.Items.Add(dt.ToString());
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (check1.IsChecked.Value && !check2.IsChecked.Value)
            {
                Appointment app = new Appointment();
                app.startTime = DateTime.Parse(cb2.Text);
                List<Doctor> docs = dc.GetAllDoctors();
                int index = 0;
                foreach (Doctor d in docs)
                {
                    if (cb1.Text.Equals(d.FullName))
                    {
                        index = d.id;
                    }
                }
                app.Doctor = new Doctor();
                app.Doctor.id = index;
                app.Room = new Room();
                app.Room.id = rc.findFreeRoom(app.startTime).id;
                app.duration = 30;
                app.Type = AppointmentType.examination;
                app.patient = new Patient();
                ac.SaveAppointment(app);
                PatientWindow pw = PatientWindow.Instance;
                pw.refresh();
                this.Close();
            }

            if (check2.IsChecked.Value && !check1.IsChecked.Value)
            {
                Appointment app = new Appointment();
                app.startTime = DateTime.Parse(tb1.Text);
                List<Doctor> docs = dc.GetAllDoctors();
                String toUse = ac.getFirstFreeAppointment(start, finish);
                int index = Int32.Parse(toUse.Split("=")[1]);
                app.Doctor = new Doctor();
                app.Doctor.id = index;
                app.Room = new Room();
                app.Room.id = rc.findFreeRoom(app.startTime).id;
                app.duration = 30;
                app.Type = AppointmentType.examination;
                app.patient = new Patient();
                ac.SaveAppointment(app);
                PatientWindow pw = PatientWindow.Instance;
                pw.refresh();
                this.Close();
            }


        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            l3.Visibility = Visibility.Visible;
            l4.Visibility = Visibility.Visible;
            dp1.Visibility = Visibility.Visible;
            dp2.Visibility = Visibility.Visible;
            b1.Visibility = Visibility.Visible;
            l5.Visibility = Visibility.Visible;
            tb1.Visibility = Visibility.Visible;

        }

        private void ToggleButton_OnUnchecked(object sender, RoutedEventArgs e)
        {
            l3.Visibility = Visibility.Collapsed;
            l4.Visibility = Visibility.Collapsed;
            dp1.Visibility = Visibility.Collapsed;
            dp2.Visibility = Visibility.Collapsed;
            b1.Visibility = Visibility.Collapsed;
            tb1.Visibility = Visibility.Collapsed;
            l5.Visibility = Visibility.Collapsed;
        }

        private void Dp2_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
        {
            finish = dp2.SelectedDate;
            if (dp1.SelectedDate != null)
            {
                tb1.Text = ac.getFirstFreeAppointment(start, finish).Split("=")[0];
            }
        }

        private void Dp1_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (dp1.SelectedDate < DateTime.Today || dp2.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Ne mozete odabrati datum manji od danasnjeg!");
                dp1.SelectedDate = null;
                dp2.SelectedDate = null;
                return;
            }

            if (dp2.SelectedDate < dp1.SelectedDate)
            {
                MessageBox.Show("Ne moze krajnji datum biti manji od pocetnog!");
                dp1.SelectedDate = null;
                dp2.SelectedDate = null;
                return;
            }

            start = dp1.SelectedDate;
            if (dp2.SelectedDate != null)
            {
                tb1.Text = ac.getFirstFreeAppointment(start, finish).Split("=")[0];
            }
        }
    }
}