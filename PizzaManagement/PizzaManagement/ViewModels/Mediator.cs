//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2016 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using PizzaManagement.Models;


namespace PizzaManagement.ViewModels
{
   public abstract class Mediator
   {
      #region Methods - Public

      /// <summary>
      ///    Sends the specified sender.
      /// </summary>
      /// <param name="sender">The sender.</param>
      /// <param name="order">The order.</param>
      public abstract void Send( Sender sender, Order order );

      #endregion
   }
}