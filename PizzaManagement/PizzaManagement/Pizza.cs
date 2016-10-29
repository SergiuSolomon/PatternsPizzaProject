using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaManagement
{
   public abstract class Pizza : IPizza
   {
      private Dictionary<IngredientType, uint> _ingredients = new Dictionary<IngredientType, uint>();
      private Dictionary<ToppingType, uint> _toppings = new Dictionary<ToppingType, uint>();
      // Maybe make derived Small/Medium/Big pizza and move this there?
      private Dictionary<PizzaSize, uint> _pizzaSizeIncreaseFactors = new Dictionary<PizzaSize, uint> {
         { PizzaSize.Small, 1 },
         { PizzaSize.Medium, 2 },
         { PizzaSize.Large, 3 }
      };

      public Pizza( PizzaSize pizzaSize )
      {
         Size = pizzaSize;
      }

      public uint FinalPrice // use decimal?
      {
         get {
            uint finalPrice = ProductionPrice * 2;

            return finalPrice;
         }
      }

      public uint ProductionPrice // use decimal?
      {
         get {
            uint productionPrice = 0;
            foreach ( var ingredientPair in _ingredients ) {
               // Get price per weight unit for each ingredient from somewhere
            }
            foreach ( var toppingPair in _toppings ) {
               // Get price per weight unit for each ingredient from somewhere
            }
            return productionPrice;
         }
      }

      public uint Weight // use decimal?
      {
         get {
            uint totalWeight = (uint)_ingredients.Values.Sum( weight => weight );
            totalWeight += (uint)_toppings.Values.Sum( weight => weight );
            return totalWeight;
         }
      }

      public PizzaSize Size { get; private set; }

      public DoughType DoughType { get; set; }
      public IEnumerable<IngredientType> Ingredients => _ingredients.Keys;
      public IEnumerable<ToppingType> Toppings => _toppings.Keys;
      public string Description { get; set; }

      public void AddIngredient( IngredientType ingredient, uint weight ) // Shouldn't who adds the ingredients know their weight based on the size?
      {
         uint currentWeight = 0;
         _ingredients.TryGetValue( ingredient, out currentWeight );
         _ingredients[ingredient] = currentWeight + weight * _pizzaSizeIncreaseFactors[Size];
      }

      public void AddTopping( ToppingType topping, uint weight )
      {
         uint currentWeight = 0;
         _toppings.TryGetValue( topping, out currentWeight );
         _toppings[topping] = currentWeight + weight * _pizzaSizeIncreaseFactors[Size];
      }

      public override string ToString()
      {
         StringBuilder stringBuilder = new StringBuilder();
         stringBuilder.AppendLine( $"{nameof( Description )} = {Description}" );
         stringBuilder.AppendLine( $"{nameof( ProductionPrice )} = {ProductionPrice}" );
         stringBuilder.AppendLine( $"{nameof( FinalPrice )} = {FinalPrice}" );
         stringBuilder.AppendLine( $"{nameof( Weight )} = {Weight}" );
         stringBuilder.AppendLine( $"{nameof( Size )} = {Size}" );
         foreach ( var ing in _ingredients ) {
            stringBuilder.AppendLine( $"Ingredient {ing.Key} = {ing.Value}" );
         }
         foreach ( var top in _toppings ) {
            stringBuilder.AppendLine( $"Topping {top.Key} = {top.Value}" );
         }
         stringBuilder.AppendLine();
         return stringBuilder.ToString();
      }
   }
}
