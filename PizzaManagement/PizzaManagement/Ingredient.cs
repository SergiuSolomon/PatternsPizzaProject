
namespace PizzaManagement
{
   class Ingredient : Substance
   {
      public Ingredient( IngredientType type )
      {
         Type = type;
      }

      public IngredientType Type { get; }

      public override void Accept( ISubstanceVisitor visitor )
      {
         visitor.VisitIngredient( this );
      }
   }
}
