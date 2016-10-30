
namespace PizzaManagement
{
   class CornPizzaBuilderDecorator : PizzaBuilderDecorator
   {
      public CornPizzaBuilderDecorator( PizzaBuilder pizzaBuilder ) : base( pizzaBuilder )
      {}

      public override void AddIngredients()
      {
         base.AddIngredients();
         GetInnerPizza().AddTopping( ToppingType.Corn, 25 );
      }
   }
}
