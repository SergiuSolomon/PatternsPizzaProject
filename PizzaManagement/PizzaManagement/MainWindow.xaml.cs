using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PizzaManagement
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();

         IPizza pizza = Kitchen.Instance.MakePizza( PizzaType.CheesePizza, PizzaSize.Medium, DoughType.Traditional, new List<ToppingType> { ToppingType.Corn } );
         System.Diagnostics.Debug.Print( pizza.ToString() );

         pizza = Kitchen.Instance.MakePizza( PizzaType.VeggiePizza, PizzaSize.Small, DoughType.Thin, new List<ToppingType> { ToppingType.Olives, ToppingType.Olives } );
         System.Diagnostics.Debug.Print( pizza.ToString() );
      }
   }
}
