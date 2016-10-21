//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2016 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System.ComponentModel;


namespace PizzaManagement.ViewModels
{
   /// <summary>
   /// 
   /// </summary>
   /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
   public class ClientViewModel : INotifyPropertyChanged
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