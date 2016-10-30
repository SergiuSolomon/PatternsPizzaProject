using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaManagement
{
   public abstract class Pizza : IPizza
   {
      private Dictionary<IngredientType, decimal> _ingredients = new Dictionary<IngredientType, decimal>();
      private Dictionary<ToppingType, decimal> _toppings = new Dictionary<ToppingType, decimal>();

      protected Pizza( PizzaSize pizzaSize )
      {
         Size = pizzaSize;
      }

      public decimal FinalPrice
      {
         get {
            decimal finalPrice = ProductionPrice * 2;

            return finalPrice;
         }
      }

      public decimal ProductionPrice
      {
         get {
            uint productionPrice = 0;
            foreach ( var ingredientPair in _ingredients ) {
               // TODO
               // Get price per weight unit for each ingredient from somewhere
            }
            foreach ( var toppingPair in _toppings ) {
               // TODO
               // Get price per weight unit for each ingredient from somewhere
            }
            return productionPrice;
         }
      }

      public decimal Weight
      {
         get {
            decimal totalWeight = _ingredients.Values.Sum( weight => weight );
            totalWeight += _toppings.Values.Sum( weight => weight );
            return totalWeight;
         }
      }

      public PizzaSize Size { get; private set; }

      public DoughType DoughType { get; set; }
      public IEnumerable<IngredientType> Ingredients => _ingredients.Keys;
      public IEnumerable<ToppingType> Toppings => _toppings.Keys;
      public string Description { get; set; } = typeof( Pizza ).Name;

      protected abstract decimal GetWeightIncreaseFactor();

      public void AddIngredient( IngredientType ingredient, decimal weight ) // Shouldn't who adds the ingredients know their weight based on the size?
      {
         decimal currentWeight = 0;
         _ingredients.TryGetValue( ingredient, out currentWeight );
         _ingredients[ingredient] = currentWeight + weight * GetWeightIncreaseFactor();
      }

      public void AddTopping( ToppingType topping, decimal weight )
      {
         decimal currentWeight = 0;
         _toppings.TryGetValue( topping, out currentWeight );
         _toppings[topping] = currentWeight + weight * GetWeightIncreaseFactor();
      }

      public override string ToString()
      {
         StringBuilder stringBuilder = new StringBuilder();
         stringBuilder.AppendLine( $"{nameof( Description )} = {Description}" );
         stringBuilder.AppendLine( $"{nameof( Size )} = {Size}" );
         stringBuilder.AppendLine( $"{nameof( DoughType )} = {DoughType}" );
         stringBuilder.AppendLine( $"{nameof( ProductionPrice )} = {ProductionPrice}" );
         stringBuilder.AppendLine( $"{nameof( FinalPrice )} = {FinalPrice}" );
         stringBuilder.AppendLine( $"{nameof( Weight )} = {Weight}" );     
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
