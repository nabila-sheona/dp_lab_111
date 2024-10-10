using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04_210042111
{
    public class Sugar : ICondimentDecorator
    {
        public IBeverage Beverage { get; }

        public Sugar(IBeverage beverage)
        {
            Beverage = beverage;
        }

        public string GetDescription()
        {
            return Beverage.GetDescription() + ", Sugar";
        }

        public double Cost() { return Beverage.Cost() + 0.50; }
    }

}
