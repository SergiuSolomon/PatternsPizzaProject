using System.Collections.Generic;

namespace PizzaManagement
{
   public interface IPizza
   {
      uint ProductionPrice { get; }
      uint FinalPrice { get; }
      uint Weight { get; }
      PizzaSize Size { get; }
      DoughType DoughType { get; }
      IEnumerable<ToppingType> Toppings { get; }
      IEnumerable<IngredientType> Ingredients { get; }
      string Description { get; }
   }
}
