using System.Collections.Generic;

namespace PizzaManagement
{
   public interface IPizza
   {
      decimal ProductionPrice { get; }
      decimal FinalPrice { get; }
      decimal Weight { get; }
      PizzaSize Size { get; }
      DoughType DoughType { get; }
      IEnumerable<ToppingType> Toppings { get; }
      IEnumerable<IngredientType> Ingredients { get; }
      string Description { get; }
   }
}
