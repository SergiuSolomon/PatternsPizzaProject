
namespace PizzaManagement
{
   /// <summary>
   /// Represents a large pizza
   /// </summary>
   class LargePizza : Pizza
   {
      /// <summary>
      /// Default constructor
      /// </summary>
      public LargePizza() : base( PizzaSize.Large )
      {
         Description = "Large " + base.Description;
      }

      /// <summary>
      /// The ingredients' weight is increased by this factor
      /// </summary>
      /// <returns></returns>
      protected override decimal GetWeightIncreaseFactor()
      {
         return 3.0m;
      }
   }
}
