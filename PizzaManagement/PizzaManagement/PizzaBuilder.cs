using System;
using System.Runtime.CompilerServices;

namespace PizzaManagement
{
   internal abstract class PizzaBuilder : IPizzaBuilder
   {
      protected Pizza _pizza;

      protected PizzaBuilder()
      {}

      public virtual void AddIngredients()
      {}

      public virtual void BuildDough()
      {}

      public virtual void Cook()
      {}

      public virtual IPizza GetPizza()
      {
         return _pizza;
      }
   }
}
