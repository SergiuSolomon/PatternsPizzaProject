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
   public class ManufacturerViewModel : INotifyPropertyChanged
   {

        public ManufacturerViewModel()
        {
            Items = new ObservableCollection<Order>();
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