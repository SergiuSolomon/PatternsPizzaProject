namespace PizzaManagement
{
   class CalorieVisitor : ISubstanceVisitor
   {
      public decimal TotalCalories { get; private set; }

      public void VisitIngredient( Ingredient ingredient )
      {
         decimal caloriesPerWeightUnit = 0m;
         switch ( ingredient.Type ) {
            case IngredientType.Flour:
               caloriesPerWeightUnit = 100m;
               break;
            case IngredientType.Mozarella:
               caloriesPerWeightUnit = 400m;
               break;
            case IngredientType.Salami:
               caloriesPerWeightUnit = 800m;
               break;
            case IngredientType.Provolone:
               caloriesPerWeightUnit = 300m;
               break;
            case IngredientType.BlueCheese:
               caloriesPerWeightUnit = 300m;
               break;
            case IngredientType.ParmigianoReggiano:
               caloriesPerWeightUnit = 200m;
               break;
            case IngredientType.VeganCheese:
               caloriesPerWeightUnit = 100m;
               break;
            case IngredientType.VeganPesto:
               caloriesPerWeightUnit = 200m;
               break;
            case IngredientType.Peppers:
               caloriesPerWeightUnit = 100m;
               break;
         }
         TotalCalories += caloriesPerWeightUnit * ingredient.Weight;
      }

      public void VisitTopping( Topping topping )
      {
         decimal caloriesPerWeightUnit = 0m;
         switch ( topping.Type ) {
            case ToppingType.Corn:
               caloriesPerWeightUnit = 100m;
               break;
            case ToppingType.Olives:
               caloriesPerWeightUnit = 100m;
               break;
         }
         TotalCalories += caloriesPerWeightUnit * topping.Weight;
      }
   }
}