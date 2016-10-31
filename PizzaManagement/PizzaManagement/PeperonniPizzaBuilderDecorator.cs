namespace PizzaManagement
{
   internal class PeperonniPizzaBuilderDecorator : PizzaBuilderDecorator
   {
      public PeperonniPizzaBuilderDecorator( PizzaBuilder pizzaBuilder ) : base( pizzaBuilder )
      {
         GetInnerPizza().Description = "Peperonni " + GetInnerPizza().Description;
      }

      public override void AddIngredients()
      {
         base.AddIngredients();
         GetInnerPizza().AddIngredient( IngredientType.Mozarella, 100 );
         GetInnerPizza().AddIngredient( IngredientType.Peppers, 150 );
         GetInnerPizza().AddIngredient( IngredientType.Salami, 100 );
      }
   }
}
