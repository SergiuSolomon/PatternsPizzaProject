namespace PizzaManagement
{
   public enum PizzaType
   {
      CheesePizza,
      VeggiePizza,
      PepperoniPizza
   }

   public enum DoughType
   {
      Thin,
      Traditional
   }

   public enum ToppingType
   {
      Corn,
      Olives,
      //Onions,
      //Tomatoes,
      //Salami,
      //Bacon
   }

   public enum IngredientType
   {
      Flour,
      Mozarella,
      Salami,
      Provolone,
      BlueCheese,
      ParmigianoReggiano,
      VeganCheese,
      VeganPesto,
      Peppers,
   }

   public enum PizzaSize
   {
      Small,
      Medium,
      Large
   }

   public enum Status
   {
      OrderReceived,
      OrderProcessed,
      OrderSent
   }
}
