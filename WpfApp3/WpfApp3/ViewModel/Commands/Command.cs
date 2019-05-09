using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace WpfApp3.ViewModel.Commands
{
    public class Command : ICommand
    {

        public Action _execute;
        Action<Window> _execute2;
        Predicate<object> canexecute;
        public Command(Action execute,Predicate<object> canExecute)
        {
            _execute = execute;
            this.canexecute = canExecute;
        }
        public event EventHandler CanExecuteChanged;
        
        public Command(Action execute)
        {
            _execute = execute;
            canexecute = null;
        }

        public bool CanExecute(object parameter)
        {

            return true;
        }
        
        public void Execute(object parameter)
        {
            _execute.Invoke();
            
        }
        
    }
}

