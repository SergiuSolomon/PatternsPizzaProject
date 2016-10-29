using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaManagement.Models;

namespace PizzaManagement.ViewModels
{
    public class MainViewModel: Mediator
    {
         public MainViewModel (){
            Client = new ClientViewModel( this);
            Manufacturer = new ManufacturerViewModel(this);
        }
        public ClientViewModel Client { get; private set; }
        public ManufacturerViewModel Manufacturer { get; private set; }

        public override void Send(Sender sender, Order order)
        {
            if (sender == Client){
                Manufacturer.Notify(order,"You have a new order");
            } else if (sender == Manufacturer)
            {
                Client.Notify(order,"Pizza sent");
            } else
            {
                System.Diagnostics.Debug.Fail("Unknown sender");
            }
        }
    }
}
