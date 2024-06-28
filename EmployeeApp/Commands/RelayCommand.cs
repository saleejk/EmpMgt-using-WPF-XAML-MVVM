using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeeApp.Commands
{
    public class RelayCommand:ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action DoWork;
        public RelayCommand(Action work)
        {
            DoWork= work;
        }
        public bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();
            return true;
        }
        public void Execute(object parameter) { 
            DoWork();
        //throw new NotImplementedException();
        }
    }
}
