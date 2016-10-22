using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Models
{
    public enum PizzaType
    {
        CheesePizza,
        VaggiePizza,
        PepperoniPizza
    }

    public enum Status
    {
        OrderReceived,
        OrderProcessed,
        OrderSent
    }

    public class Order
    {
        public PizzaType PizzaType { get; set; }
        public bool ExtraIngredients { get; set; }
        public Status Status { get; set; }
    }
}
