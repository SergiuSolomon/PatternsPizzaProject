using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace PizzaManagement.Tests
{
   [TestClass()]
   public class SmallPizzaBuilderTest
   {
      [TestMethod()]
      [Description( "Check the created pizza is ok" )]
      public void GetPizzaTest()
      {
         var pizzaBuilder = new SmallPizzaBuilder();
         var pizza = pizzaBuilder.GetPizza();
         Assert.IsNotNull( pizza );
         Assert.AreEqual( pizza.Size, PizzaSize.Small );
         Assert.IsFalse( pizza.Ingredients.Any() );
         Assert.IsFalse( pizza.Toppings.Any() );
      }
   }
}
