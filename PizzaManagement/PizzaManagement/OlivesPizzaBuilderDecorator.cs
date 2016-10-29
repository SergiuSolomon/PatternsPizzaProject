
namespace PizzaManagement
{
   internal class OlivesPizzaBuilderDecorator : PizzaBuilderDecorator
   {
      public OlivesPizzaBuilderDecorator( PizzaBuilder pizzaBuilder ) : base( pizzaBuilder )
      { }

      public override void AddIngredients()
      {
         _pizzaBuilder.AddIngredients();
         // TODO - can this be improved?
         GetInnerPizza().AddTopping( ToppingType.Corn, 25 );
      }
   }
}
