//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2016 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PizzaManagement.Models;

namespace PizzaManagement.ViewModels
{
   /// <summary>
   /// 
   /// </summary>
   /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
   public class ClientViewModel : Sender, INotifyPropertyChanged
    {
        private string _message;

        public ClientViewModel( Mediator mediator )
        {
            Mediator = mediator;
            CreateOrder();
            PizzaCommand = new Command( OrderPizza );
        }

        private void OrderPizza(object obj)
        {
            Mediator.Send(this, Order);
        }

        private void CreateOrder()
        {
            Order = new Order { PizzaType = PizzaType.CheesePizza, DoughType = DoughType.Thin, PizzaSize = PizzaSize.Large, Toppings = new List<ToppingType>() };
           
        }

        public Order Order { get; set; }

        public Command PizzaCommand { get; private set; }

        public string Message { get
            {
                return _message;
            } set {
                _message = value;
                RaisePropertyChanged(nameof(Message));
            }
        }

        public Mediator Mediator
        {
            get; 
        }



        #region Interface Members

        public event PropertyChangedEventHandler PropertyChanged;

      #endregion

      #region Methods - Protected

      protected virtual void RaisePropertyChanged( string propertyName )
      {
         PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
      }

        

        public void Notify(Order order, string message)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}