using System;
using System.Collections.Generic;

namespace PizzaManagement
{
   internal class PizzaBuilderFactory
   {
      public IPizzaBuilder Create( PizzaType pizzaType, PizzaSize pizzaSize, DoughType doughType, IEnumerable<ToppingType> toppings )
      {
         PizzaBuilder pizzaBuilder = null;
         switch ( pizzaType ) {
            case PizzaType.CheesePizza:
               pizzaBuilder = new CheesePizzaBuilder( pizzaSize );
               break;
            case PizzaType.VeggiePizza:
               pizzaBuilder = new VeggiePizzaBuilder( pizzaSize );
               break;
            default:
               throw new ArgumentException( "Unsupported pizza type!" );
         }
         switch ( doughType ) {
            case DoughType.Thin:
               pizzaBuilder = new ThinPizzaBuilderDecorator( pizzaBuilder );
               break;
            case DoughType.Traditional:
               pizzaBuilder = new TraditionalPizzaBuilderDecorator( pizzaBuilder );
               break;
            default:
               throw new ArgumentException( "Unsupported pizza dough type!" );
         }
         foreach ( ToppingType toppingType in toppings ) {
            switch ( toppingType ) {
               case ToppingType.Corn:
                  pizzaBuilder = new CornPizzaBuilderDecorator( pizzaBuilder );
                  break;
               case ToppingType.Olives:
                  pizzaBuilder = new OlivesPizzaBuilderDecorator( pizzaBuilder );
                  break;
               default:
                  throw new ArgumentException( "Unsupported pizza topping!" );
            }
         }
         return pizzaBuilder;
      }
   }
}
