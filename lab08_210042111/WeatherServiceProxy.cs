using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab08_210042111
{
    public class WeatherServiceProxy : IWeatherService
    {
        private readonly IWeatherService weatherService;
        private readonly Dictionary<string, WeatheCache> cache = new Dictionary<string, WeatheCache>();
        private static TimeSpan CacheDuration = TimeSpan.FromMinutes(10);
        private static readonly TimeSpan RateLimitDuration = TimeSpan.FromSeconds(30);

        public WeatherServiceProxy(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        public async Task<WeatherData> GetWeatherAsync(double latitude, double longitude, string cityName)
        {
            string key = cityName.ToLower();
            DateTime curr = DateTime.Now;

            if (cache.TryGetValue(key, out WeatheCache entry))
            {
                if ((curr - entry.Timestamp) < CacheDuration)
                {
                    return entry.WeatherData;
                }
                if ((curr - entry.Timestamp) < RateLimitDuration)
                {
                    throw new Exception("Rate limit exceeded. Please try again later.");
                }
            }

            WeatherData data = await weatherService.GetWeatherAsync(latitude, longitude, cityName);
            cache[key] = new WeatheCache(data, curr);
            return data;
        }
    }






        
    
}
