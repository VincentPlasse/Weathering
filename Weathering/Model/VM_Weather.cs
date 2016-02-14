using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Weathering.Model
{
    class VM_Weather
    {
        /// <summary>
        /// private raw model
        /// </summary>
        private Weather model;

        /// <summary>
        /// Static value allowing us to switch from Kelvin to Celcius temperatures
        /// </summary>
        private static double KELVIN_TO_CELCIUS = -273.15;

        /// <summary>
        /// Temperature in Celcius
        /// </summary>
        public String CelciusTemperatue
        {
            get
            {
                return Math.Round(this.model.Temperature + KELVIN_TO_CELCIUS).ToString() + "°C";
            }
        }

        /// <summary>
        /// Min temperature in Celcius
        /// </summary>
        public String CelciusMinTemperatue
        {
            get
            {
                return Math.Round(this.model.MinTemperature + KELVIN_TO_CELCIUS).ToString() + "°C";
            }
        }

        /// <summary>
        /// Max temperature in Celcius
        /// </summary>
        public String CelciusMaxTemperatue
        {
            get
            {
                return Math.Round(this.model.MaxTemperature + KELVIN_TO_CELCIUS).ToString() + "°C";
            }
        }

        /// <summary>
        /// Weather type ID, see http://openweathermap.org/weather-conditions
        /// </summary>
        public double WeatherTypeId
        {
            get
            {
                return this.model.WeatherTypeId;
            }
        }

        /// <summary>
        /// Weather type - in English
        /// </summary>
        public String WeatherType
        {
            get
            {
                return this.model.WeatherType;
            }
        }

        /// <summary>
        /// Percentage of humidity, rounded
        /// </summary>
        public String PercentageHumidity
        {
            get
            {
                return Math.Round(this.model.Humidity) + "%";
            }
        }

        /// <summary>
        /// Humidity Visibility, if forecast info is not known
        /// </summary>
        public Visibility HumidityVisibility
        {
            get
            {
                return Math.Round(this.model.Humidity) == 0 ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        /// <summary>
        /// Atmospheric pressure in hPa
        /// </summary>
        public String Pressure
        {
            get
            {
                return Math.Round(this.model.Pressure) + "hPa";
            }
        }

        /// <summary>
        /// Private singleton
        /// </summary>
        private DateTime day;
        /// <summary>
        /// Day from model timestamp
        /// </summary>
        public DateTime Day
        {
            get
            {
                if (day == null || day.Equals(DateTime.MinValue))
                {
                    day = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(Math.Round(this.model.Timestamp)).ToLocalTime();
                }
                return day;
            }
        }

        /// <summary>
        /// Formated day diplayed in "June 15" Format, see https://msdn.microsoft.com/fr-fr/library/zdtaw1bw%28v=vs.110%29.aspx for more examples
        /// </summary>
        public String FormatedDay
        {
            get
            {
                return Day.ToString("m");
            }
        }

        /// <summary>
        /// Constructor from model
        /// </summary>
        /// <param name="model"></param>
        public VM_Weather(Weather model)
        {
            this.model = model;
        }
    }
}
