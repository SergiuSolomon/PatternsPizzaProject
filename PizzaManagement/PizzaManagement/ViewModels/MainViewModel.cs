//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2016 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System.Diagnostics;

using PizzaManagement.Models;


namespace PizzaManagement.ViewModels
{
   public class MainViewModel : Mediator
   {
      #region Constructors

      /// <summary>
      ///    Initializes a new instance of the <see cref="MainViewModel" /> class.
      /// </summary>
      public MainViewModel()
      {
         Client = new ClientViewModel( this );
         Manufacturer = new ManufacturerViewModel( this );
      }

      #endregion

      #region Properties

      /// <summary>
      ///    Gets the client.
      /// </summary>
      /// <value>
      ///    The client.
      /// </value>
      public ClientViewModel Client { get; }

      /// <summary>
      ///    Gets the manufacturer.
      /// </summary>
      /// <value>
      ///    The manufacturer.
      /// </value>
      public ManufacturerViewModel Manufacturer { get; }

      #endregion

      #region Methods - Public

      /// <summary>
      ///    Sends the specified sender.
      /// </summary>
      /// <param name="sender">The sender.</param>
      /// <param name="order">The order.</param>
      public override void Send( Sender sender, Order order )
      {
         if( sender == Client ) {
            Manufacturer.Notify( order, "You have a new order" );
         } else if( sender == Manufacturer ) {
            Client.Notify( order, "Pizza sent" );
         } else {
            Debug.Fail( "Unknown sender" );
         }
      }

      #endregion
   }
}