using Model;
using Service;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.SecretaryView.ViewModel
{
    /// <summary>
    /// Interaction logic for ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        public BindingList<Appointment> list { get; set; }
        public BindingList<Appointment> list1 { get; set; }

        public DateTime fromDate;
        public DateTime toDate;

        public AppointmentService appointmentService = new AppointmentService();
        public RoomService roomService = new RoomService();

        public ReportPage()
        {

            InitializeComponent();
            list = new BindingList<Appointment>();
            foreach (Appointment appointment in appointmentService.GetAllApointments())
            {
                list.Add(appointment);
            }
            InitDataGrid();


        }


        private void InitDataGrid()
        {
            BindingList<Appointment> examinationAppointments = new BindingList<Appointment>();
            list1 = new BindingList<Appointment>();
            FindDate();


            foreach (Appointment appointment in appointmentService.GetAllApointments())
            {
                if (appointment.startTime.CompareTo(fromDate) > 0 && appointment.startTime.CompareTo(toDate) < 0)
                {
                    examinationAppointments.Add(appointment);
                }
            }

            var reportExaminationsSorted = new BindingList<Appointment>(examinationAppointments.OrderBy(x => x.startTime).ToList());
            foreach (Room room in roomService.FindAll())
            {
                foreach (Appointment exApp in reportExaminationsSorted)
                {
                    if (room.roomNum == exApp.Room.roomNum)
                    {
                        list1.Add(exApp);
                    }
                }
            }
            patientTable.ItemsSource = list1;

        }

        private void FindDate()
        {
            fromDate = DateTime.Today;
            toDate = DateTime.Today.AddDays(20);
        }










        private void CreateReport_Click(object sender, RoutedEventArgs e)
        {
            ReportSecretaryService rss = new ReportSecretaryService();
            rss.GenerateReport();
        }
    }
}
