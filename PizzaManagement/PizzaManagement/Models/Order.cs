using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Models
{
    /// <summary>
    /// prototype class
    /// </summary>
    public class Order: ICloneable
    {
        public PizzaType PizzaType { get; set; }
        public DoughType DoughType { get; set; }
        public List<ToppingType> Toppings { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public Status Status { get; set; }

        public Order Clone()
        {
            return (Order)(MemberwiseClone());
        }

        object ICloneable.Clone()
        {
            return MemberwiseClone();
        }
    }
}
