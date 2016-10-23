namespace PizzaManagement
{
   internal class SmallPizzaBuilderDecorator : PizzaBuilderDecorator
   {
      public SmallPizzaBuilderDecorator( PizzaBuilder pizzaBuilder ) : base( pizzaBuilder )
      {}

      public override void AddIngredients()
      {
         // Set Big Dough size or something
         _pizzaBuilder.AddIngredients();
      }
   }
}