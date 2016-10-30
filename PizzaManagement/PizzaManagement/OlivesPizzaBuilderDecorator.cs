
namespace PizzaManagement
{
   internal class OlivesPizzaBuilderDecorator : PizzaBuilderDecorator
   {
      public OlivesPizzaBuilderDecorator( PizzaBuilder pizzaBuilder ) : base( pizzaBuilder )
      { }

      public override void AddIngredients()
      {
         base.AddIngredients();
         GetInnerPizza().AddTopping( ToppingType.Olives, 30 );
      }
   }
}
