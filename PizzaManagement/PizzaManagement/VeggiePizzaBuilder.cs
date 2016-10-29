
namespace PizzaManagement
{
   class VeggiePizzaBuilder : PizzaBuilder
   {
      public VeggiePizzaBuilder( PizzaSize pizzaSize )
      {
         _pizza = new VeggiePizza( pizzaSize );
      }

      public override void AddIngredients()
      {
         _pizza.AddIngredient( IngredientType.VeganCheese, 200 );
         _pizza.AddIngredient( IngredientType.VeganPesto, 200 );
         _pizza.AddIngredient( IngredientType.Peppers, 200 );
      }
   }
}
