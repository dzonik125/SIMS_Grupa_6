using System;
using System.Collections.Generic;
using Model;
using SIMS.Controller;
using SIMS.Core;
using SIMS.Model;

namespace SIMS.ManagerView.ViewModel
{
    public class EditEquipmentViewModel : ViewModelBase
    {
        private EquipmentController ec = new EquipmentController();
        public event EventHandler OnRequestClose;
        public RelayCommand FinishCommand { get; set; }
        public RelayCommand DiscardCommand { get; set; }
        private string item;
        private Equipment selectedEquipment;

        public string Item
        {
            get => item;
            set
            {
                item = value;
                OnPropertyChanged(nameof(Item));
            }
        }
        private string quantity;

        public string Quantity
        {
            get => quantity;
            set
            {
                quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
        public List<string> EquipmentTypes { get; set; }

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
        public EditEquipmentViewModel(Equipment selectedEquipment)
        {
            EquipmentTypes = Conversion.GetEquipmentTypes();
            SelectedType = Conversion.EquipmentTypeToString(selectedEquipment.type);
            Item = selectedEquipment.item;
            Quantity = selectedEquipment.quantity.ToString();
            this.selectedEquipment = selectedEquipment;
            FinishCommand = new RelayCommand(param => Execute(), param => CanExecute());
            DiscardCommand = new RelayCommand(param => Discard());
        }

        private void Discard()
        {
            OnRequestClose?.Invoke(this, EventArgs.Empty);
        }

        private bool CanExecute()
        {
            if (String.IsNullOrEmpty(SelectedType) || String.IsNullOrEmpty(Item) || String.IsNullOrEmpty(Quantity))
            {
                return false;
            }

            return true;
        }

        private void Execute()
        {
            selectedEquipment.item = Item;
            selectedEquipment.quantity = Int32.Parse(Quantity);
            selectedEquipment.type = Conversion.StringToEquipmentType(SelectedType);
            ec.UpdateEquipment(selectedEquipment);
            ManagerUI mui = ManagerUI.Instance;
            mui.refreshEquipmentTable();
            OnRequestClose?.Invoke(this, EventArgs.Empty);
        }
        
    }
}