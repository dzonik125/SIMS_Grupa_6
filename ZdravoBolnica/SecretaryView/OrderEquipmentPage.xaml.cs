using Controller;
using Model;
using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Controls;

namespace SIMS.SecretaryView
{
    /// <summary>
    /// Interaction logic for OrderEquipmentPage.xaml
    /// </summary>
    public partial class OrderEquipmentPage : Page
    {
        public OrderEquipment orderE;
        public Equipment equip;
        public Room room;

        public BindingList<Equipment> eq = new BindingList<Equipment>();
        public BindingList<Equipment> order = new BindingList<Equipment>();

        public List<Equipment> list;

        public List<Equipment> equipment = new List<Equipment>();
        public EquipmentController ec = new EquipmentController();
        public TransferEquipmentController tec = new TransferEquipmentController();
        private RoomController rc = new RoomController();
        public List<Equipment> equ;
        private static Timer timer;
        private OrderEquipmentController oec = new OrderEquipmentController();

        public OrderEquipmentPage()
        {
            List<Equipment> equ = ec.FindAll();
            InitializeComponent();
            foreach (Equipment e in equ)
            {
                order.Add(e);
            }
            equipmentTable.ItemsSource = eq;
            magacinTable.ItemsSource = order;
        }

        private void Add_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            equip = new Equipment();
            orderE = new OrderEquipment();


            equip.item = Name.Text;
            equip.quantity = Int32.Parse(Quantity.Text);
            equip.type = Model.EquipmentType.potrosna;

            orderE.roomDestiantionId = rc.GetRoomIdByStorage(Conversion.StringToRoomType("Magacin"));
            orderE.transferDate = DateTime.Now.AddMinutes(1);
            orderE.quantity = Int32.Parse(Quantity.Text);


            eq.Add(equip);


            orderE.equipments = eq.ToList<Equipment>();



        }

        private void Remove_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            eq.Remove((Equipment)equipmentTable.SelectedItem);
        }

        private void Order_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            oec.SendEquipment(eq);
            oec.SaveOrder(orderE);
            timer = new Timer(new TimerCallback(oec.CreateOrder), null, 1000, 60000);
            foreach (Equipment equipment in eq)
            {
                order.Add(equipment);
                SecretaryView.Instance.SetContent(new OrderEquipmentPage());
            }
            //eq.Clear();
        }
    }
}
