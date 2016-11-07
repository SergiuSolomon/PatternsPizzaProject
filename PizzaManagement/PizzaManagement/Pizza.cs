using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaManagement
{
   public abstract class Pizza : IPizza
   {
      private List<Substance> _substances = new List<Substance>();

      protected Pizza( PizzaSize pizzaSize )
      {
         Size = pizzaSize;
      }

      public decimal Price { get; set; }
      public decimal Calories { get; set; }

      public decimal Weight
      {
         get {
            decimal totalWeight = _substances.Sum( substance => substance.Weight );
            return totalWeight;
         }
      }


      public PizzaSize Size { get; private set; }

      public DoughType DoughType { get; set; }
      public IEnumerable<IngredientType> Ingredients
      {
         get
         {
            return _substances.OfType<Ingredient>().Select( substance => substance.Type );
         }
      }
      public IEnumerable<ToppingType> Toppings
      {
         get {
            return _substances.OfType<Topping>().Select( substance => substance.Type );
         }
      }
      public string Description { get; set; } = typeof( Pizza ).Name;

      protected abstract decimal GetWeightIncreaseFactor();

      public void AddIngredient( IngredientType type, decimal weight )
      {
         var ingredient = _substances.OfType<Ingredient>().Where( ingr => ingr.Type == type ).FirstOrDefault();
         if ( null == ingredient ) {
            ingredient = new Ingredient( type );
            _substances.Add( ingredient );
         }
         ingredient.Weight += weight * GetWeightIncreaseFactor();
      }

      public void AddTopping( ToppingType type, decimal weight )
      {
         var topping = _substances.OfType<Topping>().Where( ingr => ingr.Type == type ).FirstOrDefault();
         if ( null == topping ) {
            topping = new Topping( type );
            _substances.Add( topping );
         }
         topping.Weight += weight * GetWeightIncreaseFactor();
      }

      internal void Accept( ISubstanceVisitor substanceVisitor )
      {
         foreach ( var substance in _substances ) {
            substance.Accept( substanceVisitor );
         }
      }

      public override string ToString()
      {
         StringBuilder stringBuilder = new StringBuilder();
         stringBuilder.AppendLine( $"{nameof( Description )} = {Description}" );
         stringBuilder.AppendLine( $"{nameof( Size )} = {Size}" );
         stringBuilder.AppendLine( $"{nameof( DoughType )} = {DoughType}" );
         stringBuilder.AppendLine( $"{nameof( Price )} = {Price}" );
         stringBuilder.AppendLine( $"{nameof( Calories )} = {Calories}" );
         stringBuilder.AppendLine( $"{nameof( Weight )} = {Weight}" );     
         foreach ( var substance in _substances ) {
            Ingredient ingr = substance as Ingredient;
            if ( ingr != null ) {
               stringBuilder.AppendLine( $"Ingredient {ingr.Type} = {ingr.Weight}" );
            } else {
               Topping topping = (Topping)substance;
               stringBuilder.AppendLine( $"Topping {topping.Type} = {topping.Weight}" );
            }
         }
         stringBuilder.AppendLine();
         return stringBuilder.ToString();
      }
   }
}
