using Controller;
using Model;
using SIMS.Model;
using System;
using System.Windows;

namespace SIMS.ManagerView
{
    /// <summary>
    /// Interaction logic for RoomRenovationWindow.xaml
    /// </summary>
    public partial class RoomRenovationWindow : Window
    {
        private Room room = new Room();
        private Appointment appointment = new Appointment();
        private RoomController rc = new RoomController();
        private AppointmentController ac = new AppointmentController();

        public RoomRenovationWindow()
        {
            InitializeComponent();
        }

        private void RenovationOk_Click(object sender, RoutedEventArgs e)
        {
            room.roomNum = int.Parse(RoomNum.Text);
            room.floor = int.Parse(Floor.Text);
            room.id = rc.FindRoomId(room.floor, room.roomNum);
            appointment.room = room;
            Doctor doctor = new Doctor();
            doctor.id = 0;
            Patient patient = new Patient();
            patient.id = 0;
            appointment.startTime = DateTime.Parse(StartTime.Text);
            DateTime endDate = DateTime.Parse(EndTime.Text);
            appointment.doctor = doctor;
            appointment.patient = patient;
            appointment.timesEdited = 0;
            appointment.duration = ((endDate - appointment.startTime).Days) * 24 * 60;
            appointment.type = AppointmentType.renovation;
            appointment.timesEdited = 0;
            if (rc.IsRoomOccupied(room, appointment.startTime, appointment.duration))
            {
                MessageBox.Show("Soba koju zelite da renovirate nije slobodna u ovo vreme");
                return;
            }
            ac.SaveAppointment(appointment);
            this.Close();

        }

        private void RenovationDiscard_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
