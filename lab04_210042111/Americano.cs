using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04_210042111
{
    internal class Americano : IBeverage
    {
        public string GetDescription() { return "Americano"; }

        public double Cost() { return 1.49; }
    }
}
