namespace PizzaManagement
{
   internal class CheesePizzaBuilderDecorator : PizzaBuilderDecorator
   {
      public CheesePizzaBuilderDecorator( PizzaBuilder pizzaBuilder ) : base( pizzaBuilder )
      {
         GetInnerPizza().Description = "Cheese " + GetInnerPizza().Description;
      }

      public override void AddIngredients()
      {
         base.AddIngredients();
         GetInnerPizza().AddIngredient( IngredientType.Mozarella, 100 );
         GetInnerPizza().AddIngredient( IngredientType.Provolone, 100 );
         GetInnerPizza().AddIngredient( IngredientType.BlueCheese, 100 );
         GetInnerPizza().AddIngredient( IngredientType.ParmigianoReggiano, 100 );
      }
   }
}
