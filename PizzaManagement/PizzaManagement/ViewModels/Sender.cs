//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2016 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using PizzaManagement.Models;


namespace PizzaManagement.ViewModels
{
   public abstract class Sender
   {
      #region Constructors

      /// <summary>
      ///    Initializes a new instance of the <see cref="Sender" /> class.
      /// </summary>
      /// <param name="mediator">The mediator.</param>
      protected Sender( Mediator mediator )
      {
         Mediator = mediator;
      }

      #endregion

      #region Properties

      /// <summary>
      ///    Gets the mediator.
      /// </summary>
      /// <value>
      ///    The mediator.
      /// </value>
      protected Mediator Mediator { get; }

      #endregion

      #region Methods - Protected

      /// <summary>
      ///    Notifies the specified order.
      /// </summary>
      /// <param name="order">The order.</param>
      /// <param name="message">The message.</param>
      public abstract void Notify( Order order, string message );

      #endregion
   }
}