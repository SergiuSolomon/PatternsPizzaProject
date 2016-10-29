using System;

namespace PizzaManagement
{
   internal abstract class PizzaBuilder : IPizzaBuilder
   {
      protected Pizza _pizza;

      protected PizzaBuilder()
      {}

      public abstract void AddIngredients();

      public virtual void BuildDough()
      {
         _pizza.DoughType = DoughType.Traditional; //?
      }

      public virtual void Cook()
      {
      }

      public virtual IPizza GetPizza()
      {
         return _pizza;
      }
   }
}
