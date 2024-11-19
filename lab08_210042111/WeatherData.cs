using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab08_210042111
{
    public class WeatherData
    {
        public string CityName { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string WeatherCondition { get; set; }

        public double WeatherTemperature { get; set; }

        public string LocationInformation{ get; set; }
   

        public WeatherData(string CityName, string WeatherCondition, double WeatherTemperature) { 
            
            this.CityName = CityName;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
                
            this.WeatherCondition = WeatherCondition;
            this.WeatherTemperature = WeatherTemperature;

        
        }








    }
}
