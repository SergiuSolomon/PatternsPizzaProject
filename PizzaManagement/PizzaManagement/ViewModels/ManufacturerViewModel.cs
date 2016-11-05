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
   public class ManufacturerViewModel : Sender, INotifyPropertyChanged
   {
      #region Members

      private string _message;

      #endregion

      #region Constructors

      /// <summary>
      ///    Initializes a new instance of the <see cref="ManufacturerViewModel" /> class.
      /// </summary>
      /// <param name="mediator">The mediator.</param>
      public ManufacturerViewModel( Mediator mediator ): base(mediator)
      {
         Items = new ObservableCollection<Order>();
         PreparePizzaCommand = new Command( PreparePizza, CanPreparePizza );
      }

      #endregion

      #region Properties

      public ObservableCollection<Order> Items { get; set; }

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
      ///    Gets the prepare pizza command.
      /// </summary>
      /// <value>
      ///    The prepare pizza command.
      /// </value>
      public Command PreparePizzaCommand { get; private set; }

      #endregion

      #region Interface Members

      public event PropertyChangedEventHandler PropertyChanged;

      #endregion

      #region Methods - Public

      public override void Notify( Order order, string message )
      {
         Items.Add( order.Clone() );
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
      ///    Determines whether this instance [can prepare pizza] the specified argument.
      /// </summary>
      /// <param name="arg">The argument.</param>
      /// <returns>
      ///    <c>true</c> if this instance [can prepare pizza] the specified argument; otherwise, <c>false</c>.
      /// </returns>
      private bool CanPreparePizza( object arg )
      {
         return arg is Order;
      }

      /// <summary>
      ///    Prepares the pizza.
      /// </summary>
      /// <param name="obj">The object.</param>
      private void PreparePizza( object obj )
      {
         Order order = (Order)obj;
         IPizza pizza = Kitchen.Instance.MakePizza( order.PizzaType, order.PizzaSize, order.DoughType, order.Toppings );
         order.Status = Status.OrderProcessed;
         Message = $"Pizza ready to send {Environment.NewLine}{pizza}";
      }

      #endregion
   }
}