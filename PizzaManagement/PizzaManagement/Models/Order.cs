using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using PizzaManagement.ViewModels;
using System.Text;

namespace PizzaManagement.Models
{
    /// <summary>
    /// prototype class
    /// </summary>
    [Serializable]
    public class Order : BaseModel, ICloneable
    {
        private Status _status;

        public PizzaType PizzaType { get; set; }
        public DoughType DoughType { get; set; }
        public List<ToppingType> Toppings { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public Status Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    RaisePropertyChanged(nameof(Status));
                }
            }
        }

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

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{nameof(PizzaType)} = {PizzaType}");
            stringBuilder.AppendLine($"{nameof(PizzaSize)} = {PizzaSize}");
            stringBuilder.AppendLine($"{nameof(DoughType)} = {DoughType}");

            if (null != Toppings && Toppings.Count > 0)
                stringBuilder.AppendLine($"{nameof(Toppings)} = {string.Join(",", Toppings)}");

            stringBuilder.AppendLine();
            return stringBuilder.ToString();
        }
    }
}
