using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement
{
   class PizzaBuilderFactory // aka Kitchen
   {
        private static PizzaBuilderFactory  _instance = new PizzaBuilderFactory();
        private PizzaBuilderFactory()
        {

        }

        public static PizzaBuilderFactory Instance
        {
            get
            {
                return _instance;
            }
        }

        public IPizzaBuilder Create( PizzaType pizzaType, PizzaSize pizzaSize )
      {
         PizzaBuilder pizzaBuilder = null;
         switch ( pizzaType ) {
            case PizzaType.CheesePizza:
               pizzaBuilder = new CheesePizzaBuilder();
               break;
            case PizzaType.VeggiePizza:
               pizzaBuilder = new VeggiePizzaBuilder();
               break;
            default:
               throw new ArgumentException( "Unsupported pizza type!" );
         }
         switch ( pizzaSize ) {
            case PizzaSize.Small:
                  return new SmallPizzaBuilderDecorator( pizzaBuilder );
            case PizzaSize.Medium:
               return new MediumPizzaBuilderDecorator( pizzaBuilder );
            case PizzaSize.Large:
               return new LargePizzaBuilderDecorator( pizzaBuilder );
            default:
               throw new ArgumentException( "Unsupported pizza size!" );
         }
      }

      // Example main
      public static void MainExample()
      {
         DoughType doughType = DoughType.Thin;
         IEnumerable<ToppingType> toppings = new List<ToppingType> { ToppingType.Corn, ToppingType.Olives };


         PizzaBuilderFactory factory = new PizzaBuilderFactory();
         IPizzaBuilder pizzaBuilder = factory.Create(PizzaType.CheesePizza, PizzaSize.Large);

         pizzaBuilder.BuildDough(doughType);
         pizzaBuilder.AddIngredients();
         pizzaBuilder.AddToppings();
         pizzaBuilder.Cook();

         IPizza pizza = pizzaBuilder.GetPizza();
      }
   }
}
