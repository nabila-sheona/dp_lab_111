using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5_210042111
{
    internal class Program
    {
        static void Main(string[] args)
        {
  


            BundleChild techBundle = new BundleChild("Tech Bundle 1", "A bundle with electronics", 10);
           

            techBundle.DisplayProductInfo();
            Console.WriteLine($"Total Price: ${techBundle.CalculatePrice()}");
            Console.ReadKey();

        }
    }
   
}
