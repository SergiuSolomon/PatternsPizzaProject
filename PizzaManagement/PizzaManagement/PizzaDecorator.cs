using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement
{
   abstract class PizzaBuilderDecorator : PizzaBuilder
   {
      protected PizzaBuilder _pizzaBuilder;

      public PizzaBuilderDecorator( PizzaBuilder pizzaBuilder )
      {
         _pizzaBuilder = pizzaBuilder;
      }
   }
}
