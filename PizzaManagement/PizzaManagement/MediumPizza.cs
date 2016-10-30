
namespace PizzaManagement
{
   /// <summary>
   /// Represents a medium pizza
   /// </summary>
   class MediumPizza : Pizza
   {
      /// <summary>
      /// Default constructor
      /// </summary>
      public MediumPizza() : base( PizzaSize.Medium )
      {
         Description = "Medium " + base.Description;
      }

      /// <summary>
      /// The ingredients' weight is increased by this factor
      /// </summary>
      /// <returns></returns>
      protected override decimal GetWeightIncreaseFactor()
      {
         return 2.0m;
      }
   }
}
