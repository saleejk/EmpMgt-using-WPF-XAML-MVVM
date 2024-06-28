using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using EmployeeApp.ViewModel;
using EmployeeApp.Commands;
using EmployeeApp.Model;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
namespace EmployeeApp.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        EmployeeService employeeService;
        public EmployeeViewModel()
        {
            employeeService = new EmployeeService();
            LoadData();
            CurrentEmployee=new Employee();
            saveCommand=new RelayCommand(Save);
            deleteCommand=new RelayCommand(Delete);
            updateCommand=new RelayCommand(Update);

        }
        #region DisplayOperation
        public ObservableCollection<Employee> employeesList { get; set; }

        public ObservableCollection<Employee> EmployeesList
        {
            get { return employeesList; }
            set { employeesList = value; OnPropertyChanged("employeesList"); }

        }
        private void LoadData()
        {
            EmployeesList =new ObservableCollection<Employee>(employeeService.GetAll());
        }
        #endregion

        private Employee currentEmployee;
      
        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value;OnPropertyChanged("CurrentEmployee"); }
        }
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value;OnPropertyChanged("Message"); }
        }

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }
        public void Save()
        {
            try
            {
                //employeeService.AddEmployee(CurrentEmployee);
                //LoadData();
                var IsSaved = employeeService.AddEmployee(CurrentEmployee);
                LoadData();
                if (IsSaved)
                {
                    Message = "Employee Saved";
                }
                else
                {
                    Message = "Save operation failed";
                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }

        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
        }
        public void Update()
        {
            try
            {
                var IsUpdated=employeeService.UpdateEmployee(CurrentEmployee);
                if (IsUpdated)
                {
                    Message = "Employee Updated";
                    LoadData();
                }
                else
                {
                    Message = "Update Operation Failed";
                }
            }
            catch (Exception ex)
            {
                Message=ex.Message; 
            }
        }


        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
        }
        public void Delete()
        {
            try
            {
                var IsDelete = employeeService.DeleteEmployee(CurrentEmployee.Id);
                if (IsDelete)
                {
                    Message = "Employee deleted";
                    LoadData();
                }
                else
                {
                    Message = "Delete operation failed";
                }
            }
            catch(Exception ex)
            {
                Message=ex.Message;
            }
        }
    }
}
