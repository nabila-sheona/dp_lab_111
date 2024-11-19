using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net;
using Newtonsoft.Json.Linq;

namespace lab08_210042111
{
    public class OpenWeatherMapAdapter:IWeatherService
    {

        string ApiKey = "dac1719e24399fbaddf4ad41b384611b";

        public async Task<WeatherData> GetWeatherAsync(double latitude, double longitude, string cityName)
        {
            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={ApiKey}&units=metric";
            string response = await SendGetRequestAsync(apiUrl);

            JObject json = JObject.Parse(response);
            double temperature = (double)json["main"]["temp"];
            string weatherCondition = json["weather"][0]["description"].ToString();

            return new WeatherData(cityName, latitude, longitude, weatherCondition, temperature);
        }

        private async Task<string> SendGetRequestAsync(string apiUrl)
        {
            using (WebClient client = new WebClient())
            {
                return await client.DownloadStringTaskAsync(new Uri(apiUrl));
            }
        }

    }



}
