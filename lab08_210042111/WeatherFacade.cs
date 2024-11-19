using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab08_210042111
{
    public class WeatherFacade
    {
       IWeatherService openWeatherMapAdapter;
       IWeatherService weatherStackAdapter;

        public WeatherFacade()
        {
            openWeatherMapAdapter = new OpenWeatherMapAdapter();

            weatherStackAdapter = new WeatherStackAdapters();

        }
        public async Task Start()
        {

            string city;
            Console.WriteLine("Enter the city name:");
            city = Console.ReadLine();


            Console.WriteLine("Select weather provider: 1. OpenWeatherMap, 2. WeatherStack");
            string model = Console.ReadLine();

            if (model == "1") model = "openWeatherMap";
            else if (model == "2") model = "weatherStack";
            else model = "openWeatherMap";//setting this one as default

            WeatherData weatherData = await GetWeatherByCityAsync(city, model);
            Console.WriteLine($"Weather in {city}: {weatherData.WeatherCondition}, {weatherData.WeatherTemperature}°C");

        }
        public async Task<WeatherData> GetWeatherByCityAsync(string city, string model)
        {
            double latitude = 36.5; 
            double longitude = 22;

            if (model == "openWeatherMap")
            {
                return await openWeatherMapAdapter.GetWeatherAsync(latitude, longitude, city);
            }
            else if (model == "weatherStack")
            {
                return await weatherStackAdapter.GetWeatherAsync(latitude, longitude, city);
            }
            else
            {
                return await openWeatherMapAdapter.GetWeatherAsync(latitude, longitude, city);
            }
        }

    }

}
