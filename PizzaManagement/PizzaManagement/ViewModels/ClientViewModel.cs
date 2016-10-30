//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2016 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System.Collections.Generic;
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

        public bool HasCornTopping
        {
            get
            {
                return Order.Toppings.Contains(ToppingType.Corn);
            }
            set
            {
                if (value)
                {
                    Order.Toppings.Add(ToppingType.Corn);
                }
                else if (Order.Toppings.Contains(ToppingType.Corn))
                {
                    Order.Toppings.Remove(ToppingType.Corn);
                }
                RaisePropertyChanged(nameof(HasCornTopping));
            }
        }

        public bool HasOlivesTopping
        {
            get
            {
                return Order.Toppings.Contains(ToppingType.Olives);
            }
            set
            {
                if (value)
                {
                    Order.Toppings.Add(ToppingType.Olives);
                }
                else if (Order.Toppings.Contains(ToppingType.Olives))
                {
                    Order.Toppings.Remove(ToppingType.Olives);
                }
                RaisePropertyChanged(nameof(HasOlivesTopping));
            }
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
            Message = message;
        }

        #endregion
    }
}