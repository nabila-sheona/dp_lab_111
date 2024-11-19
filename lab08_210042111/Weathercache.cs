using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab08_210042111
{
    public class WeatheCache
    {
        public WeatherData WeatherData { get; }
        public DateTime Timestamp { get; }

        public WeatheCache(WeatherData weatherData, DateTime timestamp)
        {
            WeatherData = weatherData;
            Timestamp = timestamp;
        }
    }
}
