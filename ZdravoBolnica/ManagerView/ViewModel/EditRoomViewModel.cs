using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Input;
using Controller;
using Model;
using SIMS.Core;
using SIMS.Model;
namespace SIMS.ManagerView.ViewModel
{
    public class EditRoomViewModel : ViewModelBase
    {
        public event EventHandler OnRequestClose;
        private RoomController rc = new RoomController();
        private string roomNum;
        public RelayCommand FinishCommand { get; set; }
        private Room selectedRoom;

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
                OnPropertyChanged(nameof(floor));
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
                OnPropertyChanged(nameof(selectedType));
            }
        }

        public EditRoomViewModel(Room selectedRoom)
        {
            RoomTypes = Conversion.GetRoomTypes();
            SelectedType = Conversion.RoomTypeToString(selectedRoom.roomType);
            Floor = selectedRoom.floor.ToString();
            RoomNum = selectedRoom.roomNum.ToString();
            this.selectedRoom = selectedRoom;
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
            
            //rc.UpdateRoom(room);
            selectedRoom.floor = Int32.Parse(Floor);
            selectedRoom.roomNum = Int32.Parse(RoomNum);
            selectedRoom.roomType = Conversion.StringToRoomType(selectedType);
            rc.UpdateRoom(selectedRoom);
            ManagerUI mui = ManagerUI.Instance;
            mui.refresh();
            OnRequestClose?.Invoke(this, EventArgs.Empty);
            
        }

    }

    
}