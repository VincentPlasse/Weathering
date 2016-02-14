using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace Weathering.Services
{
    class IconSelectorService : IValueConverter
    {
        /// <summary>
        /// Select the matching icon, based on Weather type id, for more info, see http://openweathermap.org/weather-conditions
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Uri uri = new Uri("ms-appx:///Images/appbar.weather.symbol.png");
            int numericValue = int.Parse(value.ToString());
            if (numericValue < 300)//thunder group
            {
                uri = new Uri("ms-appx:///Images/appbar.weather.thunder.png");
            }
            else if (numericValue < 400)//drizzle group
            {
                uri = new Uri("ms-appx:///Images/appbar.weather.chance.png");
            }
            else if (numericValue < 600)//rain group
            {
                uri = new Uri("ms-appx:///Images/appbar.weather.rain.png");
            }
            else if (numericValue < 700)//snow group
            {
                uri = new Uri("ms-appx:///Images/appbar.weather.snow.png");
            }
            else if (numericValue < 800)//atmosphere group
            {
                uri = new Uri("ms-appx:///Images/appbar.weather.mist.png");
            }
            else if (numericValue == 800)//clear group
            {
                uri = new Uri("ms-appx:///Images/appbar.weather.sun.png");
            }
            else if (numericValue < 900)//cloud group
            {
                uri = new Uri("ms-appx:///Images/appbar.weather.overcast.png");
            }
            else if (numericValue < 910)//extreme group
            {
                uri = new Uri("ms-appx:///Images/appbar.weather.station.png");
            }
            else if (numericValue < 956)//gentle breeze group
            {
                uri = new Uri("ms-appx:///Images/appbar.weather.overcast.png");
            }
            else if (numericValue < 1000)//violent storm group
            {
                uri = new Uri("ms-appx:///Images/appbar.weather.station.png");
            }
            return new BitmapImage(uri);
        }

        //not required
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}