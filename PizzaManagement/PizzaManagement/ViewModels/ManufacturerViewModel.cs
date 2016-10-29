//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2016 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System.Collections.ObjectModel;
using System.ComponentModel;
using PizzaManagement.Models;

namespace PizzaManagement.ViewModels
{
    public class ManufacturerViewModel : Sender, INotifyPropertyChanged
   {
        private string _message;

        public ManufacturerViewModel(Mediator mediator)
        {
            Items = new ObservableCollection<Order>();
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

        #endregion

        #region Methods - Protected

        protected virtual void RaisePropertyChanged( string propertyName )
      {
         PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
      }

      #endregion
   }
}