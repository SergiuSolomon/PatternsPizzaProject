
namespace PizzaManagement
{
   class ThinPizzaBuilderDecorator : PizzaBuilderDecorator
   {
      public ThinPizzaBuilderDecorator( PizzaBuilder pizzaBuilder ) : base( pizzaBuilder )
      {}

      public override void AddIngredients()
      {
         _pizzaBuilder.AddIngredients();
         GetInnerPizza().AddIngredient( IngredientType.Flour, 50 );
      }

      public override void BuildDough()
      {
         GetInnerPizza().DoughType = DoughType.Thin;
      }
   }
}
