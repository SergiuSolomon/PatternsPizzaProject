using System;
using System.Collections.Generic;

namespace PizzaManagement
{
   internal class PizzaBuilderFactory
   {
      public IPizzaBuilder Create( PizzaType pizzaType, PizzaSize pizzaSize, DoughType doughType, IEnumerable<ToppingType> toppings )
      {
         PizzaBuilder pizzaBuilder = null;
         switch ( pizzaSize ) {
            case PizzaSize.Small:
               pizzaBuilder = new SmallPizzaBuilder();
               break;
            case PizzaSize.Medium:
               pizzaBuilder = new MediumPizzaBuilder();
               break;
            case PizzaSize.Large:
               pizzaBuilder = new LargePizzaBuilder();
               break;
            default:
               throw new ArgumentException( "Unsupported pizza size!" );
         }
         switch ( pizzaType ) {
            case PizzaType.CheesePizza:
               pizzaBuilder = new CheesePizzaBuilderDecorator( pizzaBuilder );
               break;
            case PizzaType.VeggiePizza:
               pizzaBuilder = new VeggiePizzaBuilderDecorator( pizzaBuilder );
               break;
            case PizzaType.PepperoniPizza:
               pizzaBuilder = new PeperonniPizzaBuilderDecorator( pizzaBuilder );
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
