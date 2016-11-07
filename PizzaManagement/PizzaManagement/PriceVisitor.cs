namespace PizzaManagement
{
   class PriceVisitor : ISubstanceVisitor
   {
      public decimal TotalPrice { get; private set; }

      public void VisitIngredient( Ingredient ingredient )
      {
         decimal price = 0m;
         switch ( ingredient.Type ) {
            case IngredientType.Flour:
               price = 20m;
               break;
            case IngredientType.Mozarella:
               price = 30m;
               break;
            case IngredientType.Salami:
               price = 50m;
               break;
            case IngredientType.Provolone:
               price = 80m;
               break;
            case IngredientType.BlueCheese:
               price = 60m;
               break;
            case IngredientType.ParmigianoReggiano:
               price = 80m;
               break;
            case IngredientType.VeganCheese:
               price = 50m;
               break;
            case IngredientType.VeganPesto:
               price = 50m;
               break;
            case IngredientType.Peppers:
               price = 40m;
               break;
         }
         TotalPrice += price * ingredient.Weight;
      }
   
      public void VisitTopping( Topping topping )
      {
         decimal price = 0m;
         switch ( topping.Type ) {
            case ToppingType.Corn:
            price = 20m;
            break;
            case ToppingType.Olives:
            price = 30m;
            break;
         }
         TotalPrice += price * topping.Weight;
      }
   }
}