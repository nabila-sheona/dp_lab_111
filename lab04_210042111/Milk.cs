using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04_210042111
{
    public class Milk : ICondimentDecorator
    {
        public IBeverage Beverage { get; }

        public Milk(IBeverage beverage)
        {
            Beverage = beverage;
        }

        public string GetDescription() { return Beverage.GetDescription() + ", Milk"; }

        public double Cost() { return Beverage.Cost() + 0.10; }
    }


}
