using Controller;
using Model;
using SIMS.Controller;
using SIMS.Model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SIMS
{
    /// <summary>
    /// Interaction logic for TransferEquipment.xaml
    /// </summary>
    public partial class TransferEquipment : Window
    {
        private Room roomDestination = new Room();
        private Room roomSource = new Room();
        private RoomEquipmentController rec = new RoomEquipmentController();
        private AppointmentController ac = new AppointmentController();
        private RoomController rc = new RoomController();
        private Equipment equipment = new Equipment();
        private TransferEquipmentController tec = new TransferEquipmentController();
        private int quantity;
        public TransferEquipment(Room roomS, Equipment selectedEquipment)
        {
            InitializeComponent();
            equipment = selectedEquipment;
            roomSource = roomS;



        }

        private void TransferEqupment_Click(object sender, RoutedEventArgs e)
        {


        }


        private void TransferEquipmentToAnotherRoom_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointemntRoomSource = new Appointment();
            Appointment appointmentRoomDestination = new Appointment();


            roomDestination.floor = int.Parse(Floor.Text);
            roomDestination.roomNum = int.Parse(RoomNum.Text);
            roomDestination.id = rc.FindRoomId(int.Parse(Floor.Text), int.Parse(RoomNum.Text));
            roomDestination = rc.FindRoomById(roomDestination.id);

            quantity = int.Parse(Quantity.Text);
            String dateAndTime = DatePicker.Text + " " + Time.Text;
            DateTime transferDate = DateTime.Parse(dateAndTime);
            int duration = int.Parse(Duration.Text);
            if (rc.IsRoomOccupied(roomDestination, transferDate, duration))
            {
                MessageBox.Show("Soba u koju premestate opremu nije slobodna u ovo vreme");
                return;
            }

            if (rc.IsRoomOccupied(roomSource, transferDate, duration))
            {
                MessageBox.Show("Soba iz koje premestate opremu nije slobodna u ovo vreme");
                return;
            }
            /*  if (orc.IsRoomOccupied(roomDestination, transferDate, duration))
              {
                  MessageBox.Show("Soba u koju premestate opremu nije slobodna u ovo vreme");
                  return;
              }*/
            appointemntRoomSource.room = roomSource;
            appointemntRoomSource.startTime = transferDate;
            appointemntRoomSource.duration = duration;
            appointmentRoomDestination.room = roomDestination;
            appointmentRoomDestination.startTime = transferDate;
            appointmentRoomDestination.duration = duration;
            Doctor doctor = new Doctor();
            Patient patient = new Patient();
            doctor.id = 0;
            patient.id = 0;
            appointemntRoomSource.doctor = doctor;
            appointemntRoomSource.patient = patient;
            appointmentRoomDestination.doctor = doctor;
            appointmentRoomDestination.patient = patient;
            appointemntRoomSource.type = AppointmentType.transfer;
            appointmentRoomDestination.type = AppointmentType.transfer;
            appointmentRoomDestination.timesEdited = 0;
            appointemntRoomSource.timesEdited = 0;
            if (!Conversion.EquipmentTypeToString(equipment.type).Equals("potrosna"))
            {
                if (!Conversion.RoomTypeToString(roomSource.roomType).Equals("Magacin"))
                {
                    ac.SaveAppointment(appointemntRoomSource);
                }

                ac.SaveAppointment(appointmentRoomDestination);


                if (DateTime.Compare(DateTime.Now, transferDate) == 0)
                {

                    rec.TransferEquipment(roomSource, roomDestination, equipment, quantity);
                }
                else
                {
                    tec.SaveTransfer(roomSource, roomDestination, transferDate, quantity, equipment);

                }
            }
            else
            {
                rec.TransferEquipment(roomSource, roomDestination, equipment, quantity);
            }




            ManagerUI mui = ManagerUI.Instance;

            mui.refreshRoomInventoryTable(roomDestination);
            mui.refreshRoomInventoryTable(roomSource);

            this.Close();
        }
    }
}
