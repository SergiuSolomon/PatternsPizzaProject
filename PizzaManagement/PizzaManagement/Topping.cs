
namespace PizzaManagement
{
   class Topping : Substance
   {
      public Topping( ToppingType type )
      {
         Type = type;
      }

      public ToppingType Type { get; }

      public override void Accept( ISubstanceVisitor visitor )
      {
         visitor.VisitTopping( this );
      }
   }
}
