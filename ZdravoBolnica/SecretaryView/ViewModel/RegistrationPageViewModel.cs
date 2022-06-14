using Model;
using SIMS.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SIMS.SecretaryView.ViewModel
{
    public class RegistrationPageViewModel : ViewModelBase
    {
        public static RegistrationPageViewModel _instance;
        public ObservableCollection<Patient> list { get; set; }

        public RelayCommand NewPatientCommand { get; set; }
        public RelayCommand NewGuestPatientCommand { get; set; }
        public RelayCommand RemovePatientCommand { get; }

        public Patient selectedPatient;

        public PatientController pc = new PatientController();


        public Patient SelectedPatient
        {
            get => selectedPatient;
            set
            {
                selectedPatient = value;
                OnPropertyChanged(nameof(SelectedPatient));
            }
        }

        public static RegistrationPageViewModel GetInstance()
        {
            return _instance;
        }

        public RegistrationPageViewModel()
        {
            _instance = this;
            list = new ObservableCollection<Patient>();
            List<Patient> patients = new List<Patient>();


            patients = pc.FindAllPatients();
            foreach (Patient p in patients)
            {
                list.Add(p);
            }
            NewPatientCommand = new RelayCommand(param => Execute(), param => CanExecute());
            NewGuestPatientCommand = new RelayCommand(param => ExecuteGuest(), param => CanExecuteGuest());
            RemovePatientCommand = new RelayCommand(param => Remove(), param => CanRemove());
        }

        private bool CanRemove()
        {
            return true;
        }

        private void Remove()
        {
            pc.DeletePatientById(SelectedPatient.id);
            list.Remove(SelectedPatient);
        }

        private bool CanExecute()
        {

            return true;
        }

        private void Execute()
        {
            var vm = new NewPatientViewModel();
            var createPatient = new NewPatientPage()
            {
                DataContext = vm
            };
            SecretaryView.Instance.SetContent(createPatient);

        }

        private bool CanExecuteGuest()
        {

            return true;
        }

        private void ExecuteGuest()
        {
            var vm = new NewPatientViewModel();
            var createPatient = new NewGuestPatientPage(1)
            {
                DataContext = vm
            };
            SecretaryView.Instance.SetContent(createPatient);

        }

    }
}
