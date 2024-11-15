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

        string service;

        public WeatherFacade()
        {
            openWeatherMapAdapter = new OpenWeatherMapAdapter();

            weatherStackAdapter = new WeatherStackAdapters();

           


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
