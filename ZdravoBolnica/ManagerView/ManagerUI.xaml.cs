using Controller;
using Model;
using SIMS.Controller;
using SIMS.ManagerView;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SIMS.Annotations;
using SIMS.ManagerView.ViewModel;

namespace SIMS
{
       public partial class ManagerUI : INotifyPropertyChanged
    {

        private static ManagerUI instance = new ManagerUI();
        private RoomController rc = new RoomController();
        private EquipmentController ec = new EquipmentController();
        private RoomEquipmentController rec = new RoomEquipmentController();
        private AppointmentController ac = new AppointmentController();
        private TransferEquipmentController transferEquipmentController = new TransferEquipmentController();
        private MedicationController _medicationController = new MedicationController();
        private HospitalSurveyController hsc = new HospitalSurveyController();
        private DoctorController dc = new DoctorController();
        private static Timer timer;
        private Room roomSource;

        private ManagerUI() {
            InitializeComponent();

            this.DataContext = this;
            list = new ObservableCollection<Room>();
            List<Room> rooms = new List<Room>();
            rooms = rc.FindAll();
            foreach (Room r in rooms)
            {
                list.Add(r);
            }

            this.DataContext = this;
            equipList = new ObservableCollection<Equipment>();
            List<Equipment> inventory = new List<Equipment>();
            medicationList = new ObservableCollection<Medication>();
            inventory = ec.FindAll();

            foreach (Equipment e in inventory)
            {
                equipList.Add(e);
            }

            listRoomInventory = new ObservableCollection<Equipment>();
            timer = new Timer(new TimerCallback(transferEquipmentController.MoveInventory),null,1000,60000);
            foreach (Room ro in rooms)
            {
                refreshRoomInventoryTable(ro);
            }
            // DateTime transferDate = new DateTime();
            // Room r = roomsTable.SelectedItem as Room;
            //  transferDate = ac.FindDate(r);

            hospitalSurveyList = new ObservableCollection<HospitalSurvey>();
            refreshMedicationTable();
            CombroFilter.ItemsSource = Conversion.GetEquipmentTypes();
            refreshHospitalSurveyTable();
            doctorsList = new ObservableCollection<Doctor>();
            refreshDoctorTable();


        }
        public static ManagerUI Instance
        {
            get
            {
                return instance;
            }
        }
        public ObservableCollection<Doctor> doctorsList { get; set; }
        public ObservableCollection<Medication> medicationList { get; set; }

        public ObservableCollection<Room> list
        {
            get;
            set;
        }
        public ObservableCollection<HospitalSurvey> hospitalSurveyList { get; set; }
        public static ObservableCollection<Equipment> equipList
        {
            get;
            set;
        }

        public ObservableCollection<Equipment> listRoomInventory
        {
            get;
            set;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewRoom nr = new NewRoom();
            nr.ShowDialog();
        }

        public void add(Room r)

        {
            this.DataContext = this;
           
           
        }

        public void refresh()
        {
            list.Clear();
            List<Room> rooms = new List<Room>();
            rooms = rc.FindAll();
            foreach(Room r in rooms)
            {
                list.Add(r);
            }
        }
        public void refreshDoctorTable()
        {
            doctorsList.Clear();
            List<Doctor> doctors = new List<Doctor>();
            doctors = dc.FindAll();
            foreach(Doctor d in doctors)
            {
                doctorsList.Add(d);
            }
        }
        public void refreshHospitalSurveyTable()
        {
            hospitalSurveyList.Clear();
            foreach (HospitalSurvey hs in hsc.FindAll())
            {
                hospitalSurveyList.Add(hs);
            }
        }

        public void refreshMedicationTable()
        {
            medicationList.Clear();
            List<Medication> medications = new List<Medication>();
            medications = _medicationController.FindAll();
            medications.Sort((Medication x, Medication y) => x.Amount.CompareTo(y.Amount));
            List<Medication> bindgingMedicationList = new List<Medication>();
            foreach (Medication m in medications)
            {

                medicationList.Add(m);
            }
            
        }

        public void refreshEquipmentTable()
        {
            equipList.Clear();
            List<Equipment> inventory = new List<Equipment>();
            inventory = ec.FindAll();
            foreach (Equipment e in inventory)
            {
                equipList.Add(e);
            }
        }

        public void refreshRoomInventoryTable(Room r)
        {
            listRoomInventory.Clear();
            List<Equipment> roomInventory = new List<Equipment>();
            roomInventory = rec.GetRoomEquipment(ec.FindAll(),r.id);
            foreach (Equipment e in roomInventory)
            {
                listRoomInventory.Add(e);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Room selectedRoom = roomsTable.SelectedItem as Room;
            if (selectedRoom == null)
            {
                MessageBox.Show("Izabrati prostoriju.");
                return;
            }
            if (Conversion.RoomTypeToString(selectedRoom.roomType).Equals("Magacin"))
            {
                MessageBox.Show("Magacin se ne moze izbrisati.");
                return;

            }


            rc.DeleteRoomById(selectedRoom.id);
            ManagerUI mui = ManagerUI.Instance;
            mui.refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Room selectedRoom = roomsTable.SelectedItem as Room;
            if (selectedRoom == null)
            {
                MessageBox.Show("Izabrati prostoriju.");
                return;
            }

            var vm = new EditRoomViewModel(selectedRoom);
            EditRoom er = new EditRoom()
            {
                DataContext = vm
            };
            vm.OnRequestClose += (s, e) => er.Close();
            er.ShowDialog();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ManagerUI mui = ManagerUI.Instance;
            MainWindow mw = new MainWindow();
            mw.Show();
            mui.Hide();

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddEquipment_Click(object sender, RoutedEventArgs e)
        {
            var vm = new AddEquipmentViewModel();
            AddEquipment addEquipment = new AddEquipment()
            {
                DataContext = vm
            };
            vm.OnRequestClose += (s, e) => addEquipment.Close();
            addEquipment.ShowDialog();
        }

        private void EditEquipment_Click(object sender, RoutedEventArgs e)
        {
            Equipment selectedEquipment = equipmenttTable.SelectedItem as Equipment;
            if (selectedEquipment == null)
            {
                MessageBox.Show("Izaberite opremu");
                return;
            }
            var vm = new EditEquipmentViewModel(selectedEquipment);
            EditEquipment editEquipment = new EditEquipment()
            {
                DataContext = vm
            };
            vm.OnRequestClose += (s, e) => editEquipment.Close();
            editEquipment.ShowDialog();
        }

        private void DeleteEquipment_Click(object sender, RoutedEventArgs e)
        {
            Equipment selectedEquipment = equipmenttTable.SelectedItem as Equipment;
            if (selectedEquipment == null)
            {
                MessageBox.Show("Izaberite opremu");
                return;
            }
            ec.DeleteEquipmentById(selectedEquipment.id);
            ManagerUI mui = ManagerUI.Instance;
            mui.refreshEquipmentTable();
            List<Room> rooms = new List<Room>();
            rooms = rc.FindAll();
            foreach (Room rm in rooms)
            { 
                mui.refreshRoomInventoryTable(rm);
            }
           
            return;


        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void RoomInventory_Click(object sender, RoutedEventArgs e)
        {
            Room selectedRoom = roomsTable.SelectedItem as Room;
            if (selectedRoom == null)
            {
                MessageBox.Show("Izaberite opremu");
                return;
            }

            List<Equipment> equipmentlist = new List<Equipment>();
            equipmentlist = ec.FindAll();
            rec.setRoomEquipment(selectedRoom.id, equipmentlist);


        }

        private void ShowRoomInventory_Click(object sender, RoutedEventArgs e)
        {
            Room selectedRoom = roomsTable.SelectedItem as Room;
            Floor.Text = selectedRoom.floor.ToString();
            RoomNum.Text = selectedRoom.roomNum.ToString();
            Purpose.Text = Conversion.RoomTypeToString(selectedRoom.roomType);
            roomSource = selectedRoom;
            
            if (selectedRoom == null)
            {
                MessageBox.Show("Izaberite prostoriju");
                return;
            }
            refreshRoomInventoryTable(selectedRoom);

        }

        private void TransferEquipment_Click(object sender, RoutedEventArgs e)
        {
            Equipment selectedEquipment = roomsEquipmentTable.SelectedItem as Equipment;
            if (selectedEquipment == null)
            {
                MessageBox.Show("Morate izbrati opremu");
                return;

            }
            TransferEquipment transferEquipment = new TransferEquipment(roomSource,selectedEquipment);
            transferEquipment.ShowDialog();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Renovation_Click(object sender, RoutedEventArgs e)
        {
            Renovation renovation = new Renovation();
            renovation.ShowDialog();

        }

        private void TabControl_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddMedication_Click(object sender, RoutedEventArgs e)
        {
            AddMedication addMedication = new AddMedication();
            addMedication.ShowDialog();
        }

        private void EditMedication_Click(object sender, RoutedEventArgs e)
        {
            Medication selectedMedication = medicationTable.SelectedItem as Medication;
            EditMedication editMed = new EditMedication(selectedMedication);
            editMed.ShowDialog();
        }

        private void DeleteMEdication_Click(object sender, RoutedEventArgs e)
        {
            Medication selectedMedication = medicationTable.SelectedItem as Medication;
            _medicationController.DeleteById(selectedMedication.id);
            refreshMedicationTable();
        }

        private void ShowMedicationInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            // filterModeLisst.Clear();
            //            
            medicationList = new ObservableCollection<Medication>();
            medicationList.Clear();

            if (searchBox.Text.Equals(""))
            {
                foreach(Medication m in _medicationController.FindAll())
                {
                    medicationList.Add(m);
                }
               // filterModeLisst.AddRange(_animals);
            }
            else
            {
                foreach (Medication m in _medicationController.FindAll())
                {
                    //medicationList.Clear();
                    if (m.name.Contains(searchBox.Text) || m.Amount.ToString().Contains(searchBox.Text) || m.id.ToString().Contains(searchBox.Text) || Conversion.MedicationStatusTypeToString( m.status).Contains(searchBox.Text))
                    {
                        
                        medicationList.Add(m);
                    }
                }
            }

            medicationTable.ItemsSource = medicationList;
        }

        private void SearchBoxEquipmentTextChanged(object sender, TextChangedEventArgs e)
        {
            equipList = new ObservableCollection<Equipment>();
            equipList.Clear();

            if (searchEquipmentBox.Text.Equals(""))
            {
                foreach (Equipment eq in ec.FindAll())
                {
                    equipList.Add(eq);
                }
                // filterModeLisst.AddRange(_animals);
            }
            else
            {
                foreach (Equipment eq in ec.FindAll())
                {
                    //medicationList.Clear();
                    if (eq.item.Contains(searchEquipmentBox.Text) || eq.id.ToString().Contains(searchEquipmentBox.Text) || eq.quantity.ToString().Contains(searchEquipmentBox.Text) || Conversion.EquipmentTypeToString(eq.type).Contains(searchEquipmentBox.Text))
                    {

                        equipList.Add(eq);
                    }
                }
            }

            equipmenttTable.ItemsSource = equipList;

        }

        private void CombroFilter_DropDownClosed(object sender, EventArgs e)
        {
            equipList = new ObservableCollection<Equipment>();
            if (CombroFilter.Text.Equals("potrosna"))
            {
              
                foreach(Equipment eq in ec.GetiEquipmentByType(EquipmentType.potrosna))
                {
                    equipList.Add(eq);
                }
            }
            else if(CombroFilter.Text.Equals("nepotrosna"))
            {
                foreach (Equipment eq in ec.GetiEquipmentByType(EquipmentType.nepotrosna))
                {
                    equipList.Add(eq);
                }
            }
            else
            {
               foreach(Equipment eq in ec.FindAll())
                {
                    equipList.Add(eq);
                }
            }
            equipmenttTable.ItemsSource = equipList;
        }

        private void CombroFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ShowDoctorSurvey_Click(object sender, RoutedEventArgs e)
        {
            Doctor selectedDoctor = DoctorTable.SelectedItem as Doctor;
            if (selectedDoctor == null)
            {
                MessageBox.Show("Morate izbrati doktora");
                return;
            }

            DoctorSurveyDialog doctorSurvey = new DoctorSurveyDialog(selectedDoctor);
            doctorSurvey.ShowDialog();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
