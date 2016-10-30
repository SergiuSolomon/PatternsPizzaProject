//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2016 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PizzaManagement.Models;
using System.Collections.Generic;

namespace PizzaManagement.ViewModels
{
    public class ManufacturerViewModel : Sender, INotifyPropertyChanged
   {
        private string _message;

        public ManufacturerViewModel(Mediator mediator)
        {
            Items = new ObservableCollection<Order>();
            PreparePizzaCommand = new Command(PreparePizza, CanPreparePizza);
        }

        private bool CanPreparePizza(object arg)
        {
            return arg is Order;
        }

        private void PreparePizza(object obj)
        {
            Order order = obj as Order;
            IPizza pizza = Kitchen.Instance.MakePizza(order.PizzaType, order.PizzaSize, DoughType.Thin, new List<ToppingType>() );
            Message = "Pizza ready to send";
        }

        public ObservableCollection<Order> Items { get; set; }

        #region Interface Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify(Order order, string message)
        {
            Items.Add(order.Clone());
            Message = message;
        }

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                RaisePropertyChanged(nameof(Message));
            }
        }

        public Command PreparePizzaCommand { get; private set; }

        #endregion

        #region Methods - Protected

        protected virtual void RaisePropertyChanged( string propertyName )
      {
         PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
      }

      #endregion
   }
}