namespace PizzaManagement
{
   internal class MediumPizzaBuilderDecorator : PizzaBuilderDecorator
   {
      public MediumPizzaBuilderDecorator( PizzaBuilder pizzaBuilder ) : base( pizzaBuilder )
      {}

      public override void AddIngredients()
      {
         // Set Big Dough size or something
         _pizzaBuilder.AddIngredients();
      }
   }
}