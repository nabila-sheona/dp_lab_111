using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04_210042111
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 1 espressoWithSugarAndMilk
            IBeverage beverage1 = new Milk(new Sugar(new Espresso()));
            Console.WriteLine("coffee bill: " + $"{beverage1.GetDescription()}" + "add-ons(if any): " + $"costs: ${beverage1.Cost()}");

            // 2 fancyCappuccino with double milk
            IBeverage beverage2 = new Cream(new Milk(new Milk(new Sugar(new Cappuccino()))));
            Console.WriteLine("coffee bill: " + $"{beverage2.GetDescription()}" + "add-ons(if any): " + $"costs: ${beverage2.Cost()}");

            // 3 latteWithMilkAndSugar
            IBeverage beverage3 = new Sugar(new Milk(new Latte()));
            Console.WriteLine("coffee bill: " + $"{beverage3.GetDescription()}" + "add-ons(if any): " + $"costs: ${beverage3.Cost()}");

            //4 only espresso
            IBeverage beverage4 = new Espresso();
            Console.WriteLine("coffee bill: " + $"{beverage4.GetDescription()} " + "add-ons(if any): " + $"costs: ${beverage4.Cost()}");

            //5 only americano
            IBeverage beverage5 = new Americano();
            Console.WriteLine("coffee bill: " + $"{beverage5.GetDescription()} " + "add-ons(if any): " + $"costs: ${beverage5.Cost()}");


            Console.ReadKey();
        }
    }
}
