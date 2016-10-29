namespace PizzaManagement
{
   internal class CheesePizzaBuilder : PizzaBuilder
   {
      public CheesePizzaBuilder( PizzaSize pizzaSize )
      {
         _pizza = new CheesePizza( pizzaSize );
      }

      public override void AddIngredients()
      {
         _pizza.AddIngredient( IngredientType.Mozarella, 100 );
         _pizza.AddIngredient( IngredientType.Provolone, 100 );
         _pizza.AddIngredient( IngredientType.BlueCheese, 100 );
         _pizza.AddIngredient( IngredientType.ParmigianoReggiano, 100 );
      }
   }
}
