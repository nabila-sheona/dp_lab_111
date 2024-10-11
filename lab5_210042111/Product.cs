using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab5_210042111
{
    public class Product : IProductComponent
    {
        private string _name;
        private string _description;
        private double _price;

        public Product(string name, string description, double price)
        {
            _name = name;
            _description = description;
            _price = price;
        }

        public string GetName() => _name;
        public string GetDescription() => _description;

        public void DisplayProductInfo()
        {
            Console.WriteLine($"Product: {GetName()}, Description: {GetDescription()}, Price: ${_price}");
        }

        public double CalculatePrice() => _price;
    }

}
