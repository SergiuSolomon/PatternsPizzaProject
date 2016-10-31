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
   /// </summary>
   /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
   public class ClientViewModel : Sender, INotifyPropertyChanged
   {
      #region Members

      private string _message;

      #endregion

      #region Constructors

      /// <summary>
      ///    Initializes a new instance of the <see cref="ClientViewModel" /> class.
      /// </summary>
      /// <param name="mediator">The mediator.</param>
      public ClientViewModel( Mediator mediator ) : base(mediator)
      {         
         CreateOrder();
         PizzaCommand = new Command( OrderPizza );
      }

      #endregion

      #region Properties

      /// <summary>
      ///    Gets or sets a value indicating whether this instance has corn topping.
      /// </summary>
      /// <value>
      ///    <c>true</c> if this instance has corn topping; otherwise, <c>false</c>.
      /// </value>
      public bool HasCornTopping
      {
         get { return Order.Toppings.Contains( ToppingType.Corn ); }
         set
         {
            if( value ) {
               Order.Toppings.Add( ToppingType.Corn );
            } else if( Order.Toppings.Contains( ToppingType.Corn ) ) {
               Order.Toppings.Remove( ToppingType.Corn );
            }
            RaisePropertyChanged( nameof( HasCornTopping ) );
         }
      }

      /// <summary>
      ///    Gets or sets a value indicating whether this instance has olives topping.
      /// </summary>
      /// <value>
      ///    <c>true</c> if this instance has olives topping; otherwise, <c>false</c>.
      /// </value>
      public bool HasOlivesTopping
      {
         get { return Order.Toppings.Contains( ToppingType.Olives ); }
         set
         {
            if( value ) {
               Order.Toppings.Add( ToppingType.Olives );
            } else if( Order.Toppings.Contains( ToppingType.Olives ) ) {
               Order.Toppings.Remove( ToppingType.Olives );
            }
            RaisePropertyChanged( nameof( HasOlivesTopping ) );
         }
      }
    
      /// <summary>
      ///    Gets or sets the message.
      /// </summary>
      /// <value>
      ///    The message.
      /// </value>
      public string Message
      {
         get { return _message; }
         set
         {
            _message = value;
            RaisePropertyChanged( nameof( Message ) );
         }
      }

      /// <summary>
      ///    Gets or sets the order.
      /// </summary>
      /// <value>
      ///    The order.
      /// </value>
      public Order Order { get; set; }

      /// <summary>
      ///    Gets the pizza command.
      /// </summary>
      /// <value>
      ///    The pizza command.
      /// </value>
      public Command PizzaCommand { get; private set; }

      #endregion

      #region Interface Members

      public event PropertyChangedEventHandler PropertyChanged;

      #endregion

      #region Methods - Public

      public override void Notify( Order order, string message )
      {
         Message = message;
      }

      #endregion

      #region Methods - Protected

      protected virtual void RaisePropertyChanged( string propertyName )
      {
         PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
      }

      #endregion

      #region Methods - Private

      /// <summary>
      ///    Creates the order.
      /// </summary>
      private void CreateOrder()
      {
         Order = new Order {
            PizzaType = PizzaType.CheesePizza,
            DoughType = DoughType.Thin,
            PizzaSize = PizzaSize.Large,
            Toppings = new List<ToppingType>()
         };
      }

      /// <summary>
      ///    Orders the pizza.
      /// </summary>
      /// <param name="obj">The object.</param>
      private void OrderPizza( object obj )
      {
         Mediator.Send( this, Order );
      }

      #endregion
   }
}