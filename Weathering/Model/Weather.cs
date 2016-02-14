using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weathering.Model
{
    class Weather
    {
        /// <summary>
        /// Temperature in Kelvin
        /// </summary>
        public double Temperature { get; set; }

        /// <summary>
        /// Min temperature in Kelvin
        /// </summary>
        public double MinTemperature { get; set; }

        /// <summary>
        /// Max temperature in Kelvin
        /// </summary>
        public double MaxTemperature { get; set; }

        /// <summary>
        /// Weather type, in English
        /// </summary>
        public String WeatherType { get; set; }

        /// <summary>
        /// Weather type ID, see http://openweathermap.org/weather-conditions
        /// </summary>
        public double WeatherTypeId { get; set; }

        /// <summary>
        /// Humidity percentage (0-100)
        /// </summary>
        public double Humidity { get; set; }

        /// <summary>
        /// Atmospheric pressure in hPa
        /// </summary>
        public double Pressure { get; set; }

        /// <summary>
        /// Timestamp of forecast's day
        /// </summary>
        public double Timestamp { get; set; }

        /// <summary>
        /// Constructor with all attributes
        /// </summary>
        /// <param name="temperature"></param>
        /// <param name="minTemperature"></param>
        /// <param name="maxTemperature"></param>
        /// <param name="weatherType"></param>
        /// <param name="weatherTypeId"></param>
        /// <param name="humidity"></param>
        /// <param name="pressure"></param>
        /// <param name="timestamp"></param>
        public Weather(double temperature, double minTemperature, double maxTemperature, String weatherType, double weatherTypeId, double humidity, double pressure, double timestamp)
        {
            this.Temperature = temperature;
            this.MinTemperature = minTemperature;
            this.MaxTemperature = maxTemperature;
            this.WeatherType = weatherType;
            this.WeatherTypeId = weatherTypeId;
            this.Humidity = humidity;
            this.Pressure = pressure;
            this.Timestamp = timestamp;
        }
    }
}
