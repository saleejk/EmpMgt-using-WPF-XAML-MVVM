using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO.Packaging;
using System.Runtime.CompilerServices;
namespace EmployeeApp.Model
{
    public class Employee : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(nameof(Id)); }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(nameof(Title)); }
        }

        private string department;
        public string Department
        {
            get { return department; }
            set { department = value; OnPropertyChanged(nameof(Department)); }
        }



        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Title { get; set; }
        //public string Department {  get; set; }
    }
}
