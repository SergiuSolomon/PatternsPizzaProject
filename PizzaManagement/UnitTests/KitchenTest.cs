using PizzaManagement;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PizzaManagement.Tests
{
   [TestClass()]
   public class KitchenTest
   {
      [TestMethod()]
      [Description( "Tests the creation of a cheese pizza without toppings")]
      public void MakePizzaTest_CheesePizzaWithoutToppings()
      {
         IPizza pizza = Kitchen.Instance.MakePizza( PizzaType.CheesePizza, PizzaSize.Small, DoughType.Thin, new List<ToppingType>() );
         Assert.IsNotNull( pizza );
         Assert.AreEqual( pizza.Size, PizzaSize.Small );
      }
   }
}

