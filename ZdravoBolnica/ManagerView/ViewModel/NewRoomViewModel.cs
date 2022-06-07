using Controller;
using Model;
using SIMS.Core;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.ManagerView.ViewModel
{
    public class NewRoomViewModel : ViewModelBase
    {
        public event EventHandler OnRequestClose;
        private RoomController rc = new RoomController();
        private string roomNum;
        public RelayCommand FinishCommand { get; set; }

        public string RoomNum
        {
            get => roomNum;
            set
            {
                roomNum = value;
                OnPropertyChanged(nameof(RoomNum));
            }
        }

        private string floor;

        public string Floor
        {
            get => floor;
            set
            {
                floor = value;
                OnPropertyChanged(nameof(Floor));

            }
        }

        public List<string> RoomTypes { get; set; }

        private string selectedType;

        public string SelectedType
        {
            get => selectedType;
            set
            {
                selectedType = value;
                OnPropertyChanged(nameof(SelectedType));
            }
        }

        public NewRoomViewModel()
        {
            RoomTypes = Conversion.GetRoomTypes();
            FinishCommand = new RelayCommand(param => Execute(), param => CanExecute());
        }

        private bool CanExecute()
        {
            if (String.IsNullOrEmpty(selectedType))
            {
                return false;
            }

            return true;
        }

        private void Execute()
        {
            Room room = new Room
            {
                roomNum = Int32.Parse(RoomNum),
                floor = Int32.Parse(Floor),
                roomType = Conversion.StringToRoomType(SelectedType),
                empty = true
            };
            rc.AddRoom(room);
            ManagerUI mui = ManagerUI.Instance;
            mui.refresh();
            OnRequestClose?.Invoke(this, EventArgs.Empty);

        }

    }


}