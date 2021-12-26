using GalaSoft.MvvmLight;
using System.Windows.Input;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using System;
using GalaSoft.MvvmLight.Messaging;

namespace MVVM_Light_Demo.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public string Baslik_str { get; set; }

        private ObservableCollection<Employee_Model> employees;
        private Employee_Model selected_employee;

        public ICommand LoadEmployeesCommand { get; private set; }
        public ICommand SaveEmployeesCommand { get; private set; }

        public MainViewModel()
        {
            if (true == IsInDesignMode)
            {
                Baslik_str = "Design Mode";
            }
            else
            {
                Baslik_str = "Not Design Mode";
            }

            LoadEmployeesCommand = new RelayCommand(LoadEmployeesMethod);
            SaveEmployeesCommand = new RelayCommand(SaveEmployeesMethod);
        }

        public ObservableCollection<Employee_Model> EmployeeList
        {
            get
            {
                return employees;
            }
        }

        public Employee_Model SelectedEmployee
        {
            get
            {
                return selected_employee;
            }
            set
            {
                selected_employee = value;
                RaisePropertyChanged("SelectedEmployee");
            }
        }

        private void LoadEmployeesMethod()
        {
            employees = Employee_Model.GetSampleEmployees();
            this.RaisePropertyChanged(() => this.EmployeeList);
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Employees Loaded."));
        }

        private void SaveEmployeesMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Employees Saved."));
        }
    }
}