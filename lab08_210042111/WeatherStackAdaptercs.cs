﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace lab08_210042111
{
    public class WeatherStackAdapters : IWeatherService
    {

        string ApiKey = "309d469af3c87de70e7d58bfa498d1e9";  

        public async Task<WeatherData> GetWeatherAsync(double latitude, double longitude, string cityName)
        {
            string apiUrl = $"http://api.weatherstack.com/current?access_key={ApiKey}&query={cityName}";
            string response = await SendGetRequestAsync(apiUrl);

            JObject json = JObject.Parse(response);
            string weatherCondition = json["current"]["weather_descriptions"][0].ToString();
            double temperature = (double)json["current"]["temperature"];

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