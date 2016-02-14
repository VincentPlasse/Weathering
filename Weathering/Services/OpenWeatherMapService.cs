using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Weathering.Services
{
    class OpenWeatherMapService
    {
        private static String API_URL = "http://api.openweathermap.org/data/2.5/forecast/daily";
        private static String CITY_KEY = "q";
        private static String AMOUT_OF_DAYS_KEY = "cnt";
        private static String AMOUT_OF_DAYS_VALUE = "16";
        private static String TOKEN_KEY = "appid";
        private static String TOKEN_VALUE = "tobeaddedbyyou";

        public static async Task<HttpResponseMessage> getWeatherInfoForCity(String city) {

            List<KeyValuePair<String, String >> parameters = new List<KeyValuePair<String, String>>();
            parameters.Add(new KeyValuePair<String, String>(CITY_KEY, city));
            parameters.Add(new KeyValuePair<String, String>(AMOUT_OF_DAYS_KEY, AMOUT_OF_DAYS_VALUE));
            parameters.Add(new KeyValuePair<String, String>(TOKEN_KEY, TOKEN_VALUE));

            HttpResponseMessage result = await HTTPService.GetHttpResponseMessage(new Uri(API_URL), parameters);
            return result;
        }
    }
}
