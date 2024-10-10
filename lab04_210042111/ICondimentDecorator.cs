using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04_210042111
{
    public interface ICondimentDecorator : IBeverage
    {
        IBeverage Beverage { get; }

    }
   
}
