//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2016 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows.Input;

using PizzaManagement.Models;


namespace PizzaManagement.ViewModels
{
   public class Command : ICommand
   {
      #region Members

      /// <summary>
      ///    Executed action's delegate with parameters
      /// </summary>
      private readonly Action<object> _action;

      /// <summary>
      ///    CanExecute function's delegate
      /// </summary>
      private readonly Func<object, bool> _canExecute;

      #endregion

      #region Constructors

      /// <summary>
      ///    Initializes a new instance of the <see cref="Command" /> class.
      /// </summary>
      /// <param name="action">The action.</param>
      /// <param name="canExecute">The can execute.</param>
      public Command( Action<object> action, Func<object, bool> canExecute = null )
      {
         _action = action;
         _canExecute = canExecute;
      }

      #endregion

      #region Interface Members

      public bool CanExecute( object parameter )
      {
         return _canExecute?.Invoke( parameter ) ?? true;
      }


      /// <summary>
      ///    CanExecuteChanged event handler
      /// </summary>
      public event EventHandler CanExecuteChanged
      {
         add { CommandManager.RequerySuggested += value; }
         remove { CommandManager.RequerySuggested -= value; }
      }

      /// <summary>
      ///    Executes the specified parameter.
      /// </summary>
      /// <param name="parameter">The parameter.</param>
      public void Execute( object parameter )
      {
         Order order = parameter as Order;
         Debug.Assert( order != null );
         _action( parameter );
      }

      #endregion
   }
}