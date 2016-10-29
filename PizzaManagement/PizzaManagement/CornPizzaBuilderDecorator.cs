
namespace PizzaManagement
{
   internal class CornPizzaBuilderDecorator : PizzaBuilderDecorator
   {
      public CornPizzaBuilderDecorator( PizzaBuilder pizzaBuilder ) : base( pizzaBuilder )
      { }

      public override void AddIngredients()
      {
         _pizzaBuilder.AddIngredients();
         GetInnerPizza().AddTopping( ToppingType.Corn, 25 );
      }
   }
}
