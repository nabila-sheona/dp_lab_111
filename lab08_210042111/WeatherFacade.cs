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
       WeatherServiceProxy proxyWeatherStack;
       WeatherServiceProxy proxyOpenWeather;

        public WeatherFacade()
        {
            openWeatherMapAdapter = new OpenWeatherMapAdapter();
            weatherStackAdapter = new WeatherStackAdapters();
            proxyOpenWeather = new WeatherServiceProxy(openWeatherMapAdapter);
            proxyWeatherStack = new WeatherServiceProxy(weatherStackAdapter);
        }
        public async Task Start()
        {

            string city;
            Console.WriteLine("Enter the city name:");
            city = Console.ReadLine();


            Console.WriteLine("Select weather provider: 1. OpenWeatherMap, 2. WeatherStack");
            string model = Console.ReadLine();
            IWeatherService selectedService;

            if (model == "1")
            {
                selectedService = proxyOpenWeather;
            }
            else if (model == "2")
            {
                selectedService = proxyWeatherStack;
            }
            else
            {
                selectedService = proxyOpenWeather; // default
            }


            try
            {
                WeatherData weatherData = await selectedService.GetWeather(city);
                Console.WriteLine($"Weather in {city}: {weatherData.WeatherCondition}, {weatherData.WeatherTemperature}°C");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
        public async Task<WeatherData> GetWeatherByCityAsync(string city, string model)
        {
            //double latitude = 36.5; 
            //double longitude = 22;

            if (model == "openWeatherMap")
            {
                return await openWeatherMapAdapter.GetWeather(city);
            }
            else if (model == "weatherStack")
            {
                return await weatherStackAdapter.GetWeather(city);
            }
            else
            {
                return await openWeatherMapAdapter.GetWeather(city);
            }
        }

    }

}
