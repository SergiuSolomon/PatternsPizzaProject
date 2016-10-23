namespace PizzaManagement
{
   interface IPizzaBuilder
   {
      void BuildDough(DoughType doughType);
      void AddIngredients();
      void Cook();
      void AddToppings();
      IPizza GetPizza();
   }
}
