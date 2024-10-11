using lab5_210042111;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5_210042111
{
    public class BundleChild : Bundle
    {
        private double _discountPercentage;

        public BundleChild(string name, string description, double discountPercentage)
            : base(name, description)
        {
            _discountPercentage = discountPercentage;
        }
        public override void BuildBundle()
        {
            Add(new Product("Laptop", "A high-performance laptop", 1200));
            Add(new Product("mpbile", "A high-performance mobile", 1000));

        }

        public override double CalculatePrice()
        {
            double totalPrice = 0;
            foreach (IProductComponent product in _products)
                totalPrice += product.CalculatePrice();
            return totalPrice * (1 - _discountPercentage / 100);
        }
    }
}


 
