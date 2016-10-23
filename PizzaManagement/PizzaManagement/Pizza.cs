using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement
{
   public abstract class Pizza : IPizza
   {
      public uint FinalPrice { get; set; }
      public uint ProductionPrice { get; set; }
      public uint Weight { get; set; }
      public PizzaSize Size { get; set; }
      public DoughType DoughType { get; set; }
      public IEnumerable<IngredientType> Ingredients { get; set; }
      public IEnumerable<ToppingType> Toppings { get; set; }
   }
}
