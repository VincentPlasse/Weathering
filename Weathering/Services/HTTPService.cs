using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;

namespace Weathering.Services
{
    class HTTPService
    {
        /// <summary>
        /// Get Services call
        /// </summary>
        /// <param name="uri">Uri of the webservice</param>
        /// <param name="parameters">List of parameters in Key/Value pairs</param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> GetHttpResponseMessage(Uri uri, List<KeyValuePair<String, String>> parameters)
        {
            HttpResponseMessage response = null;
            HttpClient httpClient = new HttpClient();

            try
            {
                response = await httpClient.GetAsync(GetUriWithParameters(uri, parameters));
            }
            catch (TaskCanceledException ex)
            {
                LoggingService.LogMessage("Weathering.MainPage SearchButton_Click : TaskCanceledException" + ex.Message);
            }
            catch (Exception ex)
            {
                LoggingService.LogMessage("Weathering.MainPage SearchButton_Click : Exception" + ex.Message);
            }
            return response;
        }

        /// <summary>
        /// Adds to the uri the parameters
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static Uri GetUriWithParameters(Uri uri, List<KeyValuePair<String, String>> parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(uri).Append("?");
            foreach(KeyValuePair<String, String> pair in parameters)
            {
                sb.Append(pair.Key.ToString()).Append("=").Append(pair.Value.ToString()).Append("&");
            }
            sb.Remove(sb.Length - 1, 1);
            return new Uri(sb.ToString());
        }
    }
}
