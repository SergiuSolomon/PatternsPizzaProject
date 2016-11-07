
namespace PizzaManagement
{
   abstract class Substance
   {
      public decimal Weight { get; set; }
      public abstract void Accept( ISubstanceVisitor visitor );
   }
}
