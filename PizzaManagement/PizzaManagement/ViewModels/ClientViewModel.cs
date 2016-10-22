//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2016 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PizzaManagement.Models;

namespace PizzaManagement.ViewModels
{
   /// <summary>
   /// 
   /// </summary>
   /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
   public class ClientViewModel : INotifyPropertyChanged
   {
       public ClientViewModel()
        {
            CreateListOfOrders();
        }

        private void CreateListOfOrders()
        {
            Items = new ObservableCollection<Order>();
            Items.Add(new Order { PizzaType = PizzaType.CheesePizza });
        }

        public ObservableCollection<Order> Items { get; set; }

        #region Interface Members

        public event PropertyChangedEventHandler PropertyChanged;

      #endregion

      #region Methods - Protected

      protected virtual void RaisePropertyChanged( string propertyName )
      {
         PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
      }

      #endregion
   }
}