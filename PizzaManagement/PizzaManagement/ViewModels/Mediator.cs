using PizzaManagement.Models;

namespace PizzaManagement.ViewModels
{
    public abstract class Mediator
    {
        public abstract void Send(Sender sender, Order order);
    }
}
