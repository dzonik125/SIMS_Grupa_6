using Controller;
using Model;
using SIMS.Controller;
using SIMS.Core;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;

namespace SIMS.SecretaryView.ViewModel
{
    public class OrderEquipmentViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public static OrderEquipmentViewModel _instance;
        public RoomController roomController = new RoomController();
        public EquipmentController equipmentController = new EquipmentController();
        public OrderEquipmentController orderEquipmentController = new OrderEquipmentController();

        public BindingList<Equipment> eq { get; set; }
        public BindingList<Equipment> order { get; set; }


        public RelayCommand AddToList { get; set; }
        public RelayCommand RemoveFromList { get; set; }

        public RelayCommand OrderCommand { get; set; }

        public static OrderEquipmentViewModel GetInstance()
        {
            return _instance;
        }


        private string ime;
        private string kolicina;

        private Equipment selectedEquipment;
        private Timer timer;
        private OrderEquipment orderEquipment;

        public Equipment SelectedEquipment
        {
            get => selectedEquipment;
            set
            {
                selectedEquipment = value;
                OnPropertyChanged(nameof(SelectedEquipment));
            }
        }



        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                if (value != ime)
                {
                    ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }


        public string Kolicina
        {
            get
            {
                return kolicina;
            }
            set
            {
                if (value != kolicina)
                {
                    kolicina = value;
                    OnPropertyChanged("Kolicina");
                }
            }
        }

        public OrderEquipmentViewModel()
        {

            _instance = this;
            eq = new BindingList<Equipment>();
            order = new BindingList<Equipment>();
            List<Equipment> equip = new List<Equipment>();
            equip = equipmentController.FindAll();
            foreach (Equipment e in equip)
            {
                order.Add(e);
            }

            AddToList = new RelayCommand(param => Execute(), param => CanExecute());
            RemoveFromList = new RelayCommand(param => Remove(), param => CanRemove());
            OrderCommand = new RelayCommand(param => Order(), param => CanOrder());
        }

        private bool CanOrder()
        {
            if (eq.Count == 0)
            {
                return false;
            }
            else
                return true;
        }

        private void Order()
        {
            orderEquipmentController.SendEquipment(eq);
            orderEquipmentController.SaveOrder(orderEquipment);
            timer = new Timer(new TimerCallback(orderEquipmentController.CreateOrder), null, 1000, 60000);
            foreach (Equipment equipment in eq)
            {
                order.Add(equipment);
                SecretaryView.Instance.SetContent(new OrderEquipmentPage());
            }
        }

        private bool CanRemove()
        {
            return true;
        }

        private void Remove()
        {
            eq.Remove(SelectedEquipment);
        }

        private void Execute()
        {
            Equipment equipment = new Equipment
            {
                item = Ime,
                quantity = Int32.Parse(Kolicina),
                type = Conversion.StringToEquipmentType("potrosna")
            };

            orderEquipment = new OrderEquipment
            {
                roomDestiantionId = roomController.GetRoomIdByStorage(Conversion.StringToRoomType("Magacin")),
                transferDate = DateTime.Now.AddMinutes(1),
                quantity = Int32.Parse(Kolicina)
            };


            eq.Add(equipment);
            orderEquipment.equipments = eq.ToList<Equipment>();

        }

        private bool CanExecute()
        {
            return true;
        }
    }
}
