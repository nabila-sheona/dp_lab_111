using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5_210042111
{
    public interface IProductComponent
    {
        string GetName();
        string GetDescription();
        void DisplayProductInfo();
        double CalculatePrice();
    }

}
