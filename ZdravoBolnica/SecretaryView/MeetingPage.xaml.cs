using Controller;
using Model;
using SIMS.Controller;
using SIMS.Model;
using SIMS.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.SecretaryView
{
    /// <summary>
    /// Interaction logic for MeetingPage.xaml
    /// </summary>
    public partial class MeetingPage : Page
    {
        public DoctorController doctorContoller = new DoctorController();
        public SecretaryRepository secretaryRepository = new SecretaryRepository();
        public ManagerRepository managerRepository = new ManagerRepository();
        public RoomController roomController = new RoomController();
        public MeetingController meetingController = new MeetingController();

        public List<Doctor> listDoctors = new List<Doctor>();
        public List<Secretary> listSecretaries = new List<Secretary>();
        public List<Manager> listManager = new List<Manager>();
        public List<Room> listRooms = new List<Room>();
        public List<Meeting> listMeetings = new List<Meeting>();

        public BindingList<Doctor> doctors = new BindingList<Doctor>();
        public BindingList<Secretary> secretaries = new BindingList<Secretary>();
        public BindingList<Manager> managers = new BindingList<Manager>();
        public BindingList<Meeting> meetings = new BindingList<Meeting>();

        public Meeting meeting;
        public MeetingPage()
        {
            List<Meeting> meetingss = meetingController.GetAllMeetings();
            InitializeComponent();
            foreach (Meeting meeting in meetingss)
            {
                meetings.Add(meeting);
            }
            doctors_table.ItemsSource = doctors;
            secretary_table.ItemsSource = secretaries;
            managers_table.ItemsSource = managers;
            meeting_table.ItemsSource = meetings;

            listDoctors = doctorContoller.GetAllDoctors();
            listSecretaries = secretaryRepository.FindAll();
            listManager = managerRepository.FindAll();
            listRooms = roomController.getRoomsByType(Conversion.StringToRoomType("Sala za sastanke"));
            listMeetings = meetingController.GetAllMeetings();

            doctorCombo.ItemsSource = listDoctors;
            managerCombo.ItemsSource = listManager;
            secretaryCombo.ItemsSource = listSecretaries;
            roomCombo.ItemsSource = listRooms;

        }

        private void addDoctor_Click(object sender, RoutedEventArgs e)
        {
            doctors.Add((Doctor)doctorCombo.SelectedItem);
        }

        private void removeDoctor_Click(object sender, RoutedEventArgs e)
        {
            doctors.Remove((Doctor)doctors_table.SelectedItem);
        }

        private void addManager_Click(object sender, RoutedEventArgs e)
        {
            managers.Add((Manager)managerCombo.SelectedItem);
        }

        private void removeManager_Click(object sender, RoutedEventArgs e)
        {
            managers.Remove((Manager)managers_table.SelectedItem);
        }

        private void addSecretary_Click(object sender, RoutedEventArgs e)
        {
            secretaries.Add((Secretary)secretaryCombo.SelectedItem);
        }

        private void removeSecretary_Click(object sender, RoutedEventArgs e)
        {
            secretaries.Remove((Secretary)secretary_table.SelectedItem);
        }

        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            meeting = new Meeting();

            meeting.topic = Topic.Text;
            if (Topic.Text.Equals("") || Time.Text.Equals("") || roomCombo.Text.Equals("") || DatePicker.Text.Equals(""))
            {
                MessageBox.Show("Popunite sva polja!");
            }
            else
            {
                String dateAndTime = DatePicker.Text + " " + Time.Text;
                DateTime timeStamp = DateTime.Parse(dateAndTime);
                meeting.startTime = timeStamp;
                meeting.duration = 60;
                meeting.room = new Room();
                meeting.room.id = getSelectedRoom().id;

                meetings.Add(meeting);

                meeting.doctors = doctors.ToList<Doctor>();
                meeting.managers = managers.ToList<Manager>();
                meeting.secretaries = secretaries.ToList<Secretary>();


                meetingController.AddMeeting(meeting);
                SecretaryView.Instance.SetContent(new MeetingPage());
            }
        }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Meeting selectedMeeting = meeting_table.SelectedItem as Meeting;
            if (selectedMeeting == null)
            {
                MessageBox.Show("Izabrati sastanak.");
                return;
            }
            meetingController.DeleteMeetingById(selectedMeeting.id);
            meetings.Remove((Meeting)meeting_table.SelectedItem);
        }
        public Room getSelectedRoom()
        {
            Room r = listRooms[roomCombo.SelectedIndex];
            return r;
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            doctors.Clear();
            Meeting selectedMeeting = meeting_table.SelectedItem as Meeting;

            foreach (Doctor doctor in selectedMeeting.doctors)
            {
                doctors.Add(doctor);
            }

            foreach (Manager manager in selectedMeeting.managers)
            {
                managers.Add(manager);
            }
            foreach (Secretary secretary in selectedMeeting.secretaries)
            {
                secretaries.Add(secretary);
            }

            Topic.Text = selectedMeeting.topic;
            InitRoom();
            DatePicker.SelectedDate = selectedMeeting.startTime;
            Time.Text = selectedMeeting.MeetingTime.ToString();



        }
        private void InitRoom()
        {
            Meeting selectedMeeting = meeting_table.SelectedItem as Meeting;
            int index = 0;
            listRooms = roomController.FindAll();
            roomCombo.ItemsSource = listRooms;
            foreach (Room r in listRooms)
            {
                if (r.id.Equals(selectedMeeting.room.id))
                {
                    break;
                }
                index++;
            }
            roomCombo.SelectedIndex = index;
        }

        private void DataGridCell_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            doctors.Clear();
            managers.Clear();
            secretaries.Clear();
            Meeting selectedMeeting = meeting_table.SelectedItem as Meeting;

            foreach (Doctor doctor in selectedMeeting.doctors)
            {
                doctors.Add(doctor);
            }

            foreach (Manager manager in selectedMeeting.managers)
            {
                managers.Add(manager);
            }
            foreach (Secretary secretary in selectedMeeting.secretaries)
            {
                secretaries.Add(secretary);
            }

            Topic.Text = selectedMeeting.topic;
            InitRoom();
            DatePicker.SelectedDate = selectedMeeting.startTime;
            Time.Text = selectedMeeting.MeetingTime.ToString();
        }
    }
}
