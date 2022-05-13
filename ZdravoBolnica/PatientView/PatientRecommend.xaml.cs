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
using System.Windows.Media.Animation;
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
            cb3.Visibility = Visibility.Collapsed;
            l5.Visibility = Visibility.Collapsed;
            cb3.Visibility = Visibility.Collapsed;
            cb4.Visibility = Visibility.Collapsed;
            l6.Visibility = Visibility.Collapsed;
            l7.Visibility = Visibility.Collapsed;
            l8.Visibility = Visibility.Collapsed;
            l9.Visibility = Visibility.Collapsed;
            dp4.Visibility = Visibility.Collapsed;
            dp5.Visibility = Visibility.Collapsed;
            cb5.Visibility = Visibility.Collapsed;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (check2.IsChecked.Value)
            {
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
                cb3.Visibility = Visibility.Collapsed;
                l5.Visibility = Visibility.Collapsed;
                cb3.Visibility = Visibility.Collapsed;
                cb4.Visibility = Visibility.Collapsed;
                l6.Visibility = Visibility.Collapsed;
                l7.Visibility = Visibility.Collapsed;
                l8.Visibility = Visibility.Collapsed;
                l9.Visibility = Visibility.Collapsed;
                dp4.Visibility = Visibility.Collapsed;
                dp5.Visibility = Visibility.Collapsed;
                cb5.Visibility = Visibility.Collapsed;

                cb4.Visibility = Visibility.Visible;
                l6.Visibility = Visibility.Visible;
                l7.Visibility = Visibility.Visible;
                l8.Visibility = Visibility.Visible;
                l9.Visibility = Visibility.Visible;
                dp4.Visibility = Visibility.Visible;
                dp5.Visibility = Visibility.Visible;
                cb5.Visibility = Visibility.Visible;
                b1.Visibility = Visibility.Visible;

                List<Doctor> docs = dc.GetAllDoctors();
                foreach (Doctor d in docs)
                {
                    cb4.Items.Add(d.FullName);
                }



                return;
            }

            cb1.Items.Clear();
            cb2.Items.Clear();

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
            cb4.Visibility = Visibility.Collapsed;
            l6.Visibility = Visibility.Collapsed;
            l7.Visibility = Visibility.Collapsed;
            l8.Visibility = Visibility.Collapsed;
            l9.Visibility = Visibility.Collapsed;
            dp4.Visibility = Visibility.Collapsed;
            dp5.Visibility = Visibility.Collapsed;
            cb5.Visibility = Visibility.Collapsed;
            cb2.Items.Clear();
            cb5.Items.Clear();

            if (check2.IsChecked.Value)
            {
                l3.Visibility = Visibility.Visible;
                l4.Visibility = Visibility.Visible;
                dp1.Visibility = Visibility.Visible;
                dp2.Visibility = Visibility.Visible;
                b1.Visibility = Visibility.Visible;
                l5.Visibility = Visibility.Visible;
                //tb1.Visibility = Visibility.Visible;
                cb3.Visibility = Visibility.Visible;
            }

        }

        private void Cb1_OnDropDownClosed(object? sender, EventArgs e)
        {
            cb2.Items.Clear();
            String help = cb1.Text;
            System.Diagnostics.Trace.WriteLine(help);
            int id = -1;
            
            foreach (Doctor doc in dc.GetAllDoctors())
            {
                if (doc.FullName.Equals(help))
                {
                    id = doc.id;
                    break;
                }
            }

            if (id == -1)
            {
                return;
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
                app.patient = new PatientController().FindAllPatients()[0];
                ac.SaveAppointment(app);
                PatientWindow pw = PatientWindow.Instance;
                pw.refresh();
                this.Close();
            }

            if (check2.IsChecked.Value && !check1.IsChecked.Value)
            {
                Appointment app = new Appointment();
                app.startTime = DateTime.Parse(cb3.Text.Split(" ")[0] + " " + cb3.Text.Split(" ")[1] + " " + cb3.Text.Split(" ")[2]);
                List<Doctor> docs = dc.GetAllDoctors();
                int index = 0;
                foreach (Doctor d in docs)
                {
                    if (d.FullName.Equals(cb3.Text.Split(" ")[3] + " " + cb3.Text.Split(" ")[4]))
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

            if (check1.IsChecked.Value && check2.IsChecked.Value)
            {

            }


        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            if (check1.IsChecked.Value)
            {
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
                cb3.Visibility = Visibility.Collapsed;
                l5.Visibility = Visibility.Collapsed;
                cb3.Visibility = Visibility.Collapsed;
                cb4.Visibility = Visibility.Collapsed;
                l6.Visibility = Visibility.Collapsed;
                l7.Visibility = Visibility.Collapsed;
                l8.Visibility = Visibility.Collapsed;
                l9.Visibility = Visibility.Collapsed;
                dp4.Visibility = Visibility.Collapsed;
                dp5.Visibility = Visibility.Collapsed;
                cb5.Visibility = Visibility.Collapsed;

                cb4.Visibility = Visibility.Visible;
                l6.Visibility = Visibility.Visible;
                l7.Visibility = Visibility.Visible;
                l8.Visibility = Visibility.Visible;
                l9.Visibility = Visibility.Visible;
                dp4.Visibility = Visibility.Visible;
                dp5.Visibility = Visibility.Visible;
                cb5.Visibility = Visibility.Visible;
                b1.Visibility = Visibility.Visible;
                List<Doctor> docs = dc.GetAllDoctors();
                foreach (Doctor d in docs)
                {
                    cb4.Items.Add(d.FullName);
                }
                return;
            }

            l3.Visibility = Visibility.Visible;
            l4.Visibility = Visibility.Visible;
            dp1.Visibility = Visibility.Visible;
            dp2.Visibility = Visibility.Visible;
            b1.Visibility = Visibility.Visible;
            l5.Visibility = Visibility.Visible;
            //tb1.Visibility = Visibility.Visible;
            cb3.Visibility = Visibility.Visible;

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
            cb3.Visibility = Visibility.Collapsed;
            cb4.Visibility = Visibility.Collapsed;
            l6.Visibility = Visibility.Collapsed;
            l7.Visibility = Visibility.Collapsed;
            l8.Visibility = Visibility.Collapsed;
            l9.Visibility = Visibility.Collapsed;
            dp4.Visibility = Visibility.Collapsed;
            dp5.Visibility = Visibility.Collapsed;
            cb5.Visibility = Visibility.Collapsed;

            if (check1.IsChecked.Value)
            {
                cb1.Items.Clear();
                cb2.Items.Clear();
                cb5.Items.Clear();

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
        }

        private void Dp2_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
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

            cb3.Items.Clear();
            finish = dp2.SelectedDate;
            if (dp1.SelectedDate != null)
            {

                List<String> toTry = ac.getFirstFiveFreeApointmentsForDate(start, finish);
                for (int i = 0; i < toTry.Count; i++)
                {
                    cb3.Items.Add(toTry.ElementAt(i).Split(' ')[0] + " " + toTry.ElementAt(i).Split(' ')[1] + " " +
                                  toTry.ElementAt(i).Split(' ')[2] + " " +
                                  dc.GetDoctorByID(Int32.Parse(toTry.ElementAt(i).Split(' ')[3])).FullName);
                }

                //tb1.Text = ac.getFirstFreeAppointment(start, finish).Split("=")[0];
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

            cb3.Items.Clear();
            start = dp1.SelectedDate;
            if (dp2.SelectedDate != null)
            {
                List<String> toTry = ac.getFirstFiveFreeApointmentsForDate(start, finish);
                for (int i = 0; i < toTry.Count; i++)
                {
                    cb3.Items.Add(toTry.ElementAt(i).Split(' ')[0] + " " + toTry.ElementAt(i).Split(' ')[1] + " " +
                                  toTry.ElementAt(i).Split(' ')[2] + " " +
                                  dc.GetDoctorByID(Int32.Parse(toTry.ElementAt(i).Split(' ')[3])).FullName);
                }
                //tb1.Text = ac.getFirstFreeAppointment(start, finish).Split("=")[0];
            }
        }

        private void Dp4_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
        {

            if (dp4.SelectedDate > dp5.SelectedDate)
            {
                MessageBox.Show("Krajnji datum ne moze biti manji od pocetnog!");
                return;
            }

            if (dp4.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Ne mozete odabrati datum manji od danasnjeg!");
                return;
            }

            start = dp4.SelectedDate;
            cb5.Items.Clear();
            if (dp5.SelectedDate != null)
            {
                List<Doctor> docs = dc.GetAllDoctors();
                int id = -1;
                foreach (Doctor d in docs)
                {
                    if (d.FullName.Equals(cb4.Text))
                    {
                        id = d.id;
                    }
                }

                ac.getTenNextAppointmentsForDoctorForDate(start, finish, id);
                for (int i = 0; i < ac.getTenNextAppointmentsForDoctorForDate(start, finish, id).Count; i++)
                {
                    cb5.Items.Add(ac.getTenNextAppointmentsForDoctorForDate(start, finish, id).ElementAt(i));
                }
            }

        }

        private void Dp5_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (dp5.SelectedDate < dp4.SelectedDate)
            {
                MessageBox.Show("Krajnji datum ne moze biti manji od pocetnog!");
                return;
            }

            if (dp5.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Ne mozete odabrati datum manji od danasnjeg!");
                return;
            }

            finish = dp5.SelectedDate;
            cb5.Items.Clear();
            if (dp4.SelectedDate != null)
            {
                List<Doctor> docs = dc.GetAllDoctors();
                int id = -1;
                foreach (Doctor d in docs)
                {
                    if (d.FullName.Equals(cb4.Text))
                    {
                        id = d.id;
                    }
                }

                ac.getTenNextAppointmentsForDoctorForDate(start, finish, id);
                for (int i = 0; i < ac.getTenNextAppointmentsForDoctorForDate(start, finish, id).Count; i++)
                {
                    cb5.Items.Add(ac.getTenNextAppointmentsForDoctorForDate(start, finish, id).ElementAt(i));
                }
            }
        }

        private void Cb4_OnSelectionChanged(object? sender, EventArgs eventArgs)
        {
            cb5.Items.Clear();
            if (dp5.SelectedDate != null)
            {
                List<Doctor> docs = dc.GetAllDoctors();
                int id = -1;
                foreach (Doctor d in docs)
                {
                    if (d.FullName.Equals(cb4.Text))
                    {
                        id = d.id;
                    }
                }

                ac.getTenNextAppointmentsForDoctorForDate(start, finish, id);
                for (int i = 0; i < ac.getTenNextAppointmentsForDoctorForDate(start, finish, id).Count; i++)
                {
                    cb5.Items.Add(ac.getTenNextAppointmentsForDoctorForDate(start, finish, id).ElementAt(i));
                }
            }
        }
    }
}