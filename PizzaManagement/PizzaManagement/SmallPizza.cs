
namespace PizzaManagement
{
   /// <summary>
   /// Represents a small pizza
   /// </summary>
   class SmallPizza : Pizza
   {
      /// <summary>
      /// Default constructor
      /// </summary>
      public SmallPizza() : base( PizzaSize.Small )
      {
         Description = "Small " + base.Description;
      }

      /// <summary>
      /// The ingredients' weight is increased by this factor
      /// </summary>
      /// <returns></returns>
      protected override decimal GetWeightIncreaseFactor()
      {
         return 1.0m;
      }
   }
}
