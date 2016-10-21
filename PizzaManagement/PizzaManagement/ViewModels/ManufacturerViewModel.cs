//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2016 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System.ComponentModel;


namespace PizzaManagement.ViewModels
{
   public class ManufacturerViewModel : INotifyPropertyChanged
   {
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