using Controller;
using Model;
using SIMS.Core;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SIMS.SecretaryView.ViewModel
{
    public class AddAppointmentViewModel : ViewModelBase
    {
        public event EventHandler OnRequestClose;

        public PatientController pc = new PatientController();
        public RoomController rc = new RoomController();
        public DoctorController dc = new DoctorController();
        public AppointmentController ac = new AppointmentController();
        private Patient patient;
        private RoomType roomType;
        private Doctor doctor;
        private Room room;
        private string duration;
        private string time;
        private string dateAndTime;

        public AppointmentType appointmentType;
        private List<ComboBoxGeneric<Patient>> patientComboBox = new List<ComboBoxGeneric<Patient>>();
        private List<ComboBoxGeneric<Room>> roomComboBox = new List<ComboBoxGeneric<Room>>();
        private List<ComboBoxGeneric<Doctor>> doctorComboBox = new List<ComboBoxGeneric<Doctor>>();


        private DateTime _startDate = DateTime.Now;




        public RelayCommand ScheduleCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }

        public AddAppointmentViewModel(AppointmentType type)
        {
            appointmentType = type;
            roomType = type == AppointmentType.examination ? RoomType.examination : RoomType.surgery;
            FillComboData();
            ScheduleCommand = new RelayCommand(param => Execute(), param => CanExecute());
            CancelCommand = new RelayCommand(param => CloseWindow());
        }

        private void CloseWindow()
        {
            SecretaryView.Instance.SetContent(new CreateAppointmentPage());
        }

        public bool CanExecute()
        {
            /* if (StartDate != null && EndDate != null && PatientData != null && RoomData != null)
             {
                 if (DateTime.Parse(StartDate) < DateTime.Parse(EndDate))
                     return true;
             }*/

            return true;

        }

        public void Execute()
        {

            Appointment appointment = new Appointment
            {
                Type = AppointmentType.examination,
                Room = RoomData,
                patient = PatientData,
                Doctor = DoctorData,
                startTime = StartTime(),
                duration = Int32.Parse(Duration)
            };

            CreateAppointmentPage appointments = CreateAppointmentPage.Instance;
            if (ValidationAppointment(appointment))
            {
                ac.SaveAppointment(appointment);
                appointments.Refresh();
                SecretaryView.Instance.SetContent(new CreateAppointmentPage());
            }
        }

        private bool ValidationAppointment(Appointment appointment)
        {
            AppointmentController appointmentController = new AppointmentController();
            List<Appointment> appointments = appointmentController.GetAllAppointments();
            foreach (Appointment a in appointments)
            {
                if (a.GetEndTime() > appointment.startTime && a.startTime < appointment.GetEndTime() && !a.id.Equals(appointment.id))
                {
                    if (a.Doctor.id.Equals(appointment.Doctor.id))
                    {
                        MessageBox.Show("Doktor je zauzet u ovom terminu!");
                        return false;
                    }
                    else if (a.Room.id.Equals(appointment.Room.id))
                    {
                        MessageBox.Show("Soba je zauzeta u ovom terminu!");
                        return false;
                    }
                }
            }
            return true;
        }


        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        public List<ComboBoxGeneric<Patient>> PatientComboBox
        {

            get => patientComboBox;
            set
            {
                patientComboBox = value;
                OnPropertyChanged(nameof(PatientComboBox));
            }
        }
        public List<ComboBoxGeneric<Room>> RoomComboBox
        {

            get => roomComboBox;
            set
            {
                roomComboBox = value;
                OnPropertyChanged(nameof(RoomComboBox));
            }
        }

        public List<ComboBoxGeneric<Doctor>> DoctorComboBox
        {

            get => doctorComboBox;
            set
            {
                doctorComboBox = value;
                OnPropertyChanged(nameof(DoctorComboBox));
            }
        }


        public Patient PatientData
        {
            get => patient;
            set
            {
                patient = value;
                OnPropertyChanged(nameof(PatientData));
            }
        }
        public DateTime StartTime()
        {
            dateAndTime = StartDate.ToString("dd.MM.yyyy.") + " " + Time;
            DateTime timeStamp = DateTime.Parse(dateAndTime);
            return timeStamp;
        }
        public Room RoomData
        {
            get => room;
            set
            {
                room = value;
                OnPropertyChanged(nameof(RoomData));
            }
        }

        public Doctor DoctorData
        {
            get => doctor;
            set
            {
                doctor = value;
                OnPropertyChanged(nameof(DoctorData));
            }
        }

        public string Duration
        {
            get => duration;
            set
            {
                duration = value;
                OnPropertyChanged(nameof(Duration));
            }
        }

        public string Time
        {
            get => time;
            set
            {
                time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

        private void FillComboData()
        {

            foreach (var p in pc.FindAllPatients())
            {
                patientComboBox.Add(new ComboBoxGeneric<Patient>() { DisplayText = p.name + " " + p.surname, Entity = p });
            }

            foreach (var r in rc.getRoomsByType(roomType))
            {
                roomComboBox.Add(new ComboBoxGeneric<Room>() { DisplayText = r.roomNum.ToString(), Entity = r });
            }

            foreach (var d in dc.GetAllDoctors())
            {
                doctorComboBox.Add(new ComboBoxGeneric<Doctor>() { DisplayText = d.name + " " + d.surname, Entity = d });
            }

        }
    }
}
