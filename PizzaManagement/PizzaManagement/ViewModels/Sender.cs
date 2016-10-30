using PizzaManagement.Models;

namespace PizzaManagement.ViewModels
{
    public abstract class Sender
    {
        void Notify(Order order, string message)
        {

        }

        Mediator Mediator { get;  }
    }
}
