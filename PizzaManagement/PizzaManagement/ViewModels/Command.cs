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
        /// <summary>
        /// CanExecute function's delegate
        /// </summary>
        private readonly Func<object, bool> _canExecute;



        public Command(Action<object> action,Func<object, bool> canExecute = null)
        {
            _action = action;
            _canExecute = canExecute;
        }


        public bool CanExecute(object parameter)
        {
            return _canExecute ==null ? true: _canExecute(parameter);
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
