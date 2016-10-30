using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace PizzaManagement.Models
{
    /// <summary>
    /// prototype class
    /// </summary>
    [Serializable]
    public class Order: ICloneable
    {
        public PizzaType PizzaType { get; set; }
        public DoughType DoughType { get; set; }
        public List<ToppingType> Toppings { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public Status Status { get; set; }

        public Order Clone()
        {
            return DeepClone(this);
        }

        object ICloneable.Clone()
        {
            return DeepClone(this);
        }

        private T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }
    }
}
