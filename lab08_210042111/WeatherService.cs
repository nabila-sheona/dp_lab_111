using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace lab08_210042111
{
    public class WeatherService
    {
        WeatherFacade weatherFacade;

        public WeatherService(WeatherFacade weatherFacade) {

            this.weatherFacade = weatherFacade; 
        
        }


        public async Task Start()
        {
           
            string city;
            Console.WriteLine("Enter the city name:");
            city = Console.ReadLine();


            Console.WriteLine("Select weather provider: 1. OpenWeatherMap, 2. WeatherStack");
            string model = Console.ReadLine() == "1" ? "openWeatherMap" : "weatherStack";

            
                WeatherData weatherData = await weatherFacade.GetWeatherByCityAsync(city, model);
                Console.WriteLine($"Weather in {city}: {weatherData.WeatherCondition}, {weatherData.WeatherTemperature}°C");
            
        }

       

      
    }
}
