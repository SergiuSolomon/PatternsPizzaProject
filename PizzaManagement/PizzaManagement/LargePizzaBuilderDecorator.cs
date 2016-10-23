namespace PizzaManagement
{
   internal class LargePizzaBuilderDecorator : PizzaBuilderDecorator
   {
      public LargePizzaBuilderDecorator( PizzaBuilder pizzaBuilder ) : base( pizzaBuilder )
      {}

      public override void AddIngredients()
      {
         // Set Big Dough size or something
         _pizzaBuilder.AddIngredients();
      }
   }
}