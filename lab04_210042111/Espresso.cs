using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04_210042111
{
    internal class Espresso : IBeverage
    {
        public string GetDescription() { return "Espresso"; }

        public double Cost() { return 1.99; }
    }
}
