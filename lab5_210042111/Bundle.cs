using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab5_210042111
{
    public abstract class Bundle : IProductComponent
    {
        protected string _name;
        protected string _description;
        protected List<IProductComponent> _products = new List<IProductComponent>();

        public Bundle(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public string GetName() { return _name; }
        public string GetDescription() { return _description; }

        public void DisplayProductInfo()
        {
            Console.WriteLine($"Bundle: {GetName()}, Description: {GetDescription()}");
            foreach (var product in _products)
            {
                product.DisplayProductInfo();
            }
            Console.WriteLine($"Bundle Price (after discount): ${CalculatePrice()}");
        }

        public abstract double CalculatePrice();
        public abstract void BuildBundle();


        public void Add(IProductComponent productComponent) => _products.Add(productComponent);
        public void Remove(IProductComponent productComponent) => _products.Remove(productComponent);
    }

   
}
