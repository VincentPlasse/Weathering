using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Weathering.Services;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using Windows.Data.Json;
using Windows.System;
using Weathering.Model;
using Windows.UI.ViewManagement;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Weathering
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// Text displayed when SearchField is empty
        /// </summary>
        private static String SEARCHFIELD_TOOLTIP = "MainPage.ChooseACity";

        /// <summary>
        /// Constructor, set default app dimensions for Windows 10
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(480, 800);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.WeatherList.ItemsSource = null;
            SearchField.Text = LocalizationService.Convert(SEARCHFIELD_TOOLTIP);
        }

        /// <summary>
        /// Uses OpenWeatherMapService to get weather informations then format result to List<VM_Weather> for WeatherList ItemsSource's data context
        /// </summary>
        private async void SearchWeather()
        {
            HttpResponseMessage response = await OpenWeatherMapService.getWeatherInfoForCity(SearchField.Text);
            if (response != null && response.StatusCode.Equals(HttpStatusCode.Ok))
            {
                JsonObject data = JsonObject.Parse(response.Content.ToString());
                if (data.ContainsKey("cod") && data.GetNamedString("cod").Equals("404"))
                {
                    //city not found
                    this.WeatherList.ItemsSource = null;
                    LoggingService.LogMessage("Weathering.MainPage : City not found : " + SearchField.Text);
                }
                else
                {
                    JsonArray list = data.GetNamedArray("list");

                    if (list.Count > 0)
                    {
                        List<VM_Weather> weatherDays = new List<VM_Weather>();
                        for (uint i = 0; i < list.Count; i++)
                        {
                            JsonObject day = list.GetObjectAt(i);
                            weatherDays.Add(new VM_Weather(
                                new Weather(day.GetNamedObject("temp").GetNamedNumber("day"),
                                day.GetNamedObject("temp").GetNamedNumber("min"),
                                day.GetNamedObject("temp").GetNamedNumber("max"),
                                day.GetNamedArray("weather").GetObjectAt(0).GetNamedString("main"),
                                day.GetNamedArray("weather").GetObjectAt(0).GetNamedNumber("id"),
                                day.GetNamedNumber("humidity"),
                                day.GetNamedNumber("pressure"),
                                day.GetNamedNumber("dt")
                                ))
                            );
                        }
                        this.WeatherList.ItemsSource = weatherDays;
                    }
                }
            }
            else
            {
                //unable to reach server
                this.WeatherList.ItemsSource = null;
                LoggingService.LogMessage("Weathering.MainPage : Unable to reach server");
            }
        }

        /// <summary>
        /// Click event on search button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchWeather();
        }

        /// <summary>
        /// Enter Key pressed on search filed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchField_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                SearchWeather();
            }
        }

        /// <summary>
        /// Remove tooltip on search field when getting focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchField_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchField.Text.Equals(LocalizationService.Convert(SEARCHFIELD_TOOLTIP)))
            {
                SearchField.Text = String.Empty;
            }
        }

        /// <summary>
        /// Display tooltip on seach field if empty on focus lost
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchField_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SearchField.Text.Equals(String.Empty))
            {
                SearchField.Text = LocalizationService.Convert(SEARCHFIELD_TOOLTIP);
            }
        }

    }
}
