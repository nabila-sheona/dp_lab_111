using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab08_210042111
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeather(string cityName);

    }
}
