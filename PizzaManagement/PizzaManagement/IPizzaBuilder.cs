namespace PizzaManagement
{
   interface IPizzaBuilder
   {
      void BuildDough();
      void AddIngredients();
      void Cook();
      IPizza GetPizza();
   }
}
