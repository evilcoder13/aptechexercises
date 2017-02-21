using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using Windows.Devices.Geolocation;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Nov30thAWSADGooglePlace
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlacePage : Page
    {
        public PlacePage()
        {
            this.InitializeComponent();
            LoadPlaceData();
            //https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=20.9788577,105.8466552&radius=500&type=restaurant&keyword=&key=AIzaSyB6l7SDbvs4lffijunJeCANY3vbLiRf_9k
        }

        async void LoadPlaceData()
        {
            var g = new Geolocator(); 
            Geoposition p = await g.GetGeopositionAsync(); 
            string Lat = p.Coordinate.Point.Position.Latitude. ToString().Replace(',','.');
            string Long = p.Coordinate.Point.Position.Longitude.ToString().Replace(',', '.');
            location = Lat + "," + Long;

            if (cbTypes.SelectedIndex > 0)
                type = cbTypes.SelectedItem.ToString();
            else
                type = "restaurant";

            if (!string.IsNullOrEmpty(sbKeyword.QueryText))
                keyword = sbKeyword.QueryText;

            apiURL = string.Format("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={0}&radius=500&type={1}&keyword={2}&key=AIzaSyB6l7SDbvs4lffijunJeCANY3vbLiRf_9k",location,type,keyword);

            HttpClient client = new HttpClient();
            string jsonData = await client.GetStringAsync(apiURL);

            JObject j = JObject.Parse(jsonData);
            IList<JToken> results = j["results"].Children().ToList();
            List<PlaceInfo> list = new List<PlaceInfo>();
            foreach (JToken result in results)
            {
                PlaceInfo r = JsonConvert.DeserializeObject<PlaceInfo>(result.ToString());
                list.Add(r);
            }
            lstPlace.DataContext = list;
            //string Acc = p.Coordinate.Accuracy.ToString();	
        }
        string location = "20.9788577,105.8466552";
        string type = "restaurant";
        string keyword = "";
        string apiURL = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=20.9788577,105.8466552&radius=500&type=restaurant&keyword=&key=AIzaSyB6l7SDbvs4lffijunJeCANY3vbLiRf_9k";
        private void Goback_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
            

        }
    }
}
