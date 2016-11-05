//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2016 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System.Collections.Generic;

using PizzaManagement.Models;
using PizzaManagement.Notification;

namespace PizzaManagement.ViewModels
{
    /// <summary>
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class ClientViewModel : Sender
    {
        #region Members

        private string _message;

        private string _emailMessage;

        private string _smsMessage;

        #endregion

        #region Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="ClientViewModel" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public ClientViewModel(Mediator mediator) : base(mediator)
        {
            CreateOrder();
            PizzaCommand = new Command(OrderPizza);
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
            get { return Order.Toppings.Contains(ToppingType.Corn); }
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

        /// <summary>
        ///    Gets or sets a value indicating whether this instance has olives topping.
        /// </summary>
        /// <value>
        ///    <c>true</c> if this instance has olives topping; otherwise, <c>false</c>.
        /// </value>
        public bool HasOlivesTopping
        {
            get { return Order.Toppings.Contains(ToppingType.Olives); }
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
        /// Gets or sets the email message.
        /// </summary>
        /// <value>
        /// The email message.
        /// </value>
        public string EmailMessage
        {
            get { return _emailMessage; }
            set
            {
                _emailMessage = value;
                RaisePropertyChanged(nameof(EmailMessage));
            }
        }

        public string SmsMessage
        {
            get { return _smsMessage; }
            set
            {
                _smsMessage = value;
                RaisePropertyChanged(nameof(SmsMessage));
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

        #region Methods - Public

        /// <summary>
        /// Notifies the specified order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="message">The message.</param>
        public override void Notify(Order order, string message)
        {
            Message = message;

            NotifyByBridge(message);
        }

        /// <summary>
        /// Notifies the by bridge.
        /// </summary>
        /// <param name="message">The message.</param>
        private void NotifyByBridge(string message)
        {
            BridgeNotifier bridgeNotifier = new BridgeNotifier(this);
            bridgeNotifier.SendMessage(message);
            bridgeNotifier.SetService(new SmsMessenger(this));
            bridgeNotifier.SendMessage(message);
        }

        #endregion

        #region Methods - Private

        /// <summary>
        ///    Creates the order.
        /// </summary>
        private void CreateOrder()
        {
            Order = new Order
            {
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
        private void OrderPizza(object obj)
        {
            Mediator.Send(this, Order);
        }

        #endregion
    }
}