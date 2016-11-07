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
      {
         PriceVisitor priceVisitor = new PriceVisitor();
         _pizza.Accept( priceVisitor );
         _pizza.Price = priceVisitor.TotalPrice;

         CalorieVisitor calorieVisitor = new CalorieVisitor();
         _pizza.Accept( calorieVisitor );
         _pizza.Calories = calorieVisitor.TotalCalories;
      }

      public virtual IPizza GetPizza()
      {
         return _pizza;
      }
   }
}
