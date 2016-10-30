
namespace PizzaManagement
{
   internal class VeggiePizzaBuilderDecorator : PizzaBuilderDecorator
   {
      public VeggiePizzaBuilderDecorator( PizzaBuilder pizzaBuilder ) : base( pizzaBuilder )
      {
         GetInnerPizza().Description = "Veggie " + GetInnerPizza().Description;
      }

      public override void AddIngredients()
      {
         base.AddIngredients();
         GetInnerPizza().AddIngredient( IngredientType.VeganCheese, 200 );
         GetInnerPizza().AddIngredient( IngredientType.VeganPesto, 200 );
         GetInnerPizza().AddIngredient( IngredientType.Peppers, 200 );
      }
   }
}

