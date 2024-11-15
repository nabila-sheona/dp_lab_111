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

            WeatherFacade weatherFacade = new WeatherFacade();
            WeatherService weatherService = new WeatherService(weatherFacade);

            weatherService.Start();


            Console.ReadKey();
        }
    }
}
