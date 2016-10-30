using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTests")]

namespace PizzaManagement
{
   public sealed class Kitchen
   {
      private static volatile Kitchen _instance;
      private static object _syncRoot = new Object();

      PizzaBuilderFactory _pizzaBuilderFactory;

      private Kitchen()
      {
         _pizzaBuilderFactory = new PizzaBuilderFactory();
      }

      public static Kitchen Instance
      {
         get {
            if ( _instance == null ) {
               lock ( _syncRoot ) {
                  if ( _instance == null ) {
                     _instance = new Kitchen();
                  } 
               }
            }

            return _instance;
         }
      }

      public IPizza MakePizza( PizzaType type, PizzaSize size, DoughType doughType, IEnumerable<ToppingType> toppings )
      {
         PizzaBuilderFactory factory = new PizzaBuilderFactory();
         IPizzaBuilder pizzaBuilder = factory.Create( type, size, doughType, toppings );

         pizzaBuilder.BuildDough();
         pizzaBuilder.AddIngredients();
         pizzaBuilder.Cook();

         IPizza pizza = pizzaBuilder.GetPizza();
         return pizza;
      }
   }
}
