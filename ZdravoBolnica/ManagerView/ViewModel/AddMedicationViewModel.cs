using System;
using SIMS.Core;

namespace SIMS.ManagerView.ViewModel
{
    public class AddMedicationViewModel
    {
        public event EventHandler OnRequestClose;
        public RelayCommand FinishCommand { get; set; }
    }
}