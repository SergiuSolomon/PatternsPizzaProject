using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement
{
   abstract class PizzaBuilder : IPizzaBuilder
   {
      protected Pizza _pizza;

      public PizzaBuilder()
      {}

      public abstract void AddIngredients();

      public void AddToppings()
      {
         throw new NotImplementedException();
      }

      public void BuildDough( DoughType doughType ) // Can be a separate decorator?
      {
         _pizza.DoughType = doughType;
      }

      public void Cook()
      {
         throw new NotImplementedException();
      }

      public IPizza GetPizza()
      {
         throw new NotImplementedException();
      }
   }
}
