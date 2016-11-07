namespace PizzaManagement
{
   interface ISubstanceVisitor
   {
      void VisitIngredient( Ingredient ingredient );
      void VisitTopping( Topping topping );
   }
}