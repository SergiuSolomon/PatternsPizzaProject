using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PizzaManagement.Models;

namespace PizzaManagement.ViewModels
{
    public class Command : ICommand
    {
        /// <summary>
        /// Executed action's delegate with parameters
        /// </summary>
        private readonly Action<object> _action;


        public Command(Action<object> action)
        {
            _action = action;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Order order = parameter as Order;
            System.Diagnostics.Debug.Assert(order != null);
            _action(parameter);
        }

        /// <summary>
        ///    CanExecuteChanged event handler
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

    }
}
