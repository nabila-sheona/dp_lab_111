using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04_210042111
{
    public class Cream : ICondimentDecorator
    {
        public IBeverage Beverage { get; }

        public Cream(IBeverage beverage)
        {
            Beverage = beverage;
        }

        public string GetDescription() { return Beverage.GetDescription() + ", Cream"; }

        public double Cost() { return Beverage.Cost() + 0.80; }
    }
}
