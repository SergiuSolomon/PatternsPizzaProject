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
    public class ManufacturerViewModel : Sender
    {
        #region Members

        private string _message;

        #endregion

        #region Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="ManufacturerViewModel" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public ManufacturerViewModel(Mediator mediator) : base(mediator)
        {
            Items = new ObservableCollection<Order>();
            PreparePizzaCommand = new Command(PreparePizza, CanPreparePizza);
            SendPizzaCommand = new Command(SendPizza, CanSendPizza);
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
                RaisePropertyChanged(nameof(Message));
            }
        }

        /// <summary>
        ///    Gets the prepare pizza command.
        /// </summary>
        /// <value>
        ///    The prepare pizza command.
        /// </value>
        public Command PreparePizzaCommand { get; private set; }

        /// <summary>
        /// Gets or sets the send pizza command.
        /// </summary>
        /// <value>
        /// The send pizza command.
        /// </value>
        public Command SendPizzaCommand { get; set; }
        #endregion

        #region Methods - Public

        public override void Notify(Order order, string message)
        {
            Items.Add(order.Clone());
            Message = message;
        }

        #endregion Methods - Public

        #region Methods - Private

        /// <summary>
        ///    Determines whether this instance [can prepare pizza] the specified argument.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <returns>
        ///    <c>true</c> if this instance [can prepare pizza] the specified argument; otherwise, <c>false</c>.
        /// </returns>
        private bool CanPreparePizza(object arg)
        {
            Order order = arg as Order;
            return (null != order && order.Status == Status.OrderReceived);
        }

        /// <summary>
        /// Determines whether this instance [can send pizza] the specified argument.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>
        ///   <c>true</c> if this instance [can send pizza] the specified argument; otherwise, <c>false</c>.
        /// </returns>
        private bool CanSendPizza(object args)
        {
            Order order = args as Order;
            return (null != order && order.Status == Status.OrderProcessed);
        }

        /// <summary>
        /// Sends the pizza.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private void SendPizza(object args)
        {
            Order order = args as Order;
            Mediator.Send(this, order);

            order.Status = Status.OrderSent;
        }

        /// <summary>
        ///    Prepares the pizza.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void PreparePizza(object obj)
        {
            Order order = (Order)obj;
            IPizza pizza = Kitchen.Instance.MakePizza(order.PizzaType, order.PizzaSize, order.DoughType, order.Toppings);
            Message = $"Pizza ready to send {Environment.NewLine}{pizza}";

            order.Status = Status.OrderProcessed;
        }

        #endregion
    }
}