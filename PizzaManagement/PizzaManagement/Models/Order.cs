using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.ComponentModel;

namespace PizzaManagement.Models
{
    /// <summary>
    /// prototype class
    /// </summary>
    [Serializable]
    public class Order: ICloneable, INotifyPropertyChanged
    {
        private Status _status;

        public PizzaType PizzaType { get; set; }
        public DoughType DoughType { get; set; }
        public List<ToppingType> Toppings { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public Status Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                RaisePropertyChanged(nameof(Status));
            }
        }

        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;

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

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
