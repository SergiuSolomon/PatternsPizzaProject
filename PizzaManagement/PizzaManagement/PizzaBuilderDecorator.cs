
namespace PizzaManagement
{
   abstract class PizzaBuilderDecorator : PizzaBuilder
   {
      protected PizzaBuilder _pizzaBuilder;

      public PizzaBuilderDecorator( PizzaBuilder pizzaBuilder )
      {
         _pizzaBuilder = pizzaBuilder;
      }

      public override void BuildDough()
      {
         _pizzaBuilder.BuildDough();
      }

      public override void AddIngredients()
      {
         _pizzaBuilder.AddIngredients();
      }

      public override void Cook()
      {
         _pizzaBuilder.Cook();
      }

      public override IPizza GetPizza()
      {
         return _pizzaBuilder.GetPizza();
      }

      public Pizza GetInnerPizza()
      {
         // TODO - can this be improved?
         return (Pizza)_pizzaBuilder.GetPizza();
      }
   }
}
