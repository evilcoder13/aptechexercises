using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Nov21stAWSADWeather
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WeatherPage : Page
    {
        string city = "Hanoi";
        WeatherData w = new WeatherData();
        public WeatherPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            LoadWeather();
        }

        void LoadWeather()
        {
            HttpClient client = new HttpClient();
            string jsonData = client.GetStringAsync("http://api.apixu.com/v1/current.json?key=26fbe2ec08ff4877bc693153161911&q=" + city).Result;

            JToken t = JToken.Parse(jsonData);
            w = new WeatherData();
            w.feelslike_c = (string)t.SelectToken("current").SelectToken("feelslike_c");
            w.humidity = (string)t.SelectToken("current").SelectToken("humidity");
            w.wind_kph = (string)t.SelectToken("current").SelectToken("wind_kph");
            w.wind_dir = (string)t.SelectToken("current").SelectToken("wind_dir");
            w.icon = (string)t.SelectToken("current").SelectToken("condition").SelectToken("icon");
            w.text = (string)t.SelectToken("current").SelectToken("condition").SelectToken("text");
            w.temp_c = (string)t.SelectToken("current").SelectToken("temp_c");
            if (w.icon.StartsWith("//"))
                w.icon = "http:" + w.icon;
            this.DataContext = w;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            NotificationUtil.TileNotification(w.text + "-" + w.temp_c, w.icon);
            //NotificationUtil.TileNotification(w.text + " - " + w.temp_c);
            NotificationUtil.BadgeNotification(w.feelslike_c.Split(new char[] { ',', '.' })[0]);
            NotificationUtil.ToastNotification("Updated!");
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (xnCity.SelectedIndex < 0)
                xnCity.SelectedIndex = 0;
            city = xnCity.SelectedValue.ToString();
            LoadWeather();
        }
    }
}
