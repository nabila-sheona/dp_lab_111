using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab08_210042111
{
    internal class Program
    {
        static void Main(string[] args)
        {
           WeatherService weatherService = new WeatherService();

            weatherService.Go();
        }
    }
}
