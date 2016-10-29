
namespace PizzaManagement
{
   class TraditionalPizzaBuilderDecorator : PizzaBuilderDecorator
   {
      public TraditionalPizzaBuilderDecorator( PizzaBuilder pizzaBuilder ) : base( pizzaBuilder )
      {}

      public override void AddIngredients()
      {
         _pizzaBuilder.AddIngredients();
         GetInnerPizza().AddIngredient( IngredientType.Flour, 150 );
      }

      public override void BuildDough()
      {
         GetInnerPizza().DoughType = DoughType.Traditional;
      }
   }
}
