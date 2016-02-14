using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Weathering.Services
{
    class LocalizationService : IValueConverter
    {
        /// <summary>
        /// Language used for localization
        /// </summary>
        public static String Language = "EN";

        /// <summary>
        /// Key/Value Dictionnary
        /// </summary>
        private static Dictionary<string, string> defaultValueDictionary;

        /// <summary>
        /// Load the dictionary only once.
        /// </summary>
        public static void LoadDefaultValueDictionary()
        {
            defaultValueDictionary = new Dictionary<string, string>();
            //Only english is added for now
            switch (Language)
            {
                case "EN":
                default:
                    defaultValueDictionary.Add("MainPage.Search", "Search");
                    defaultValueDictionary.Add("MainPage.ChooseACity", "Choose a city");
                    defaultValueDictionary.Add("UC_WeatherListItem.Temperature", "Temperature:" + System.Convert.ToChar(160));
                    defaultValueDictionary.Add("UC_WeatherListItem.Min", "Min:" + System.Convert.ToChar(160));
                    defaultValueDictionary.Add("UC_WeatherListItem.Max", "Max:" + System.Convert.ToChar(160));
                    defaultValueDictionary.Add("UC_WeatherListItem.Pressure", "Pressure:" + System.Convert.ToChar(160));
                    defaultValueDictionary.Add("UC_WeatherListItem.Humidity", "Humidity:" + System.Convert.ToChar(160));
                    break;
            }
        }

        /// <summary>
        /// IValueConverter Convert method
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return Convert(value.ToString());
        }

        /// <summary>
        /// Convert input value to localized string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String Convert (String value)
        {
            if (defaultValueDictionary == null || defaultValueDictionary.Count == 0)
            {
                LoadDefaultValueDictionary();
            }

            if (defaultValueDictionary.ContainsKey(value))
            {
                return defaultValueDictionary[value];
            }
            else
            {
                return "NotTranslated" + value;
            }
        }

        //Not required
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
