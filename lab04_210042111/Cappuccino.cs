using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04_210042111
{
    internal class Cappuccino : IBeverage
    {
        public string GetDescription() { return "Cappuccino"; }
        public double Cost() { return 2.99; }
    }
}
