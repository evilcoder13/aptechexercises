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

namespace Dec14thAWSAD2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MovieSearchPage : Page
    {
        public MovieSearchPage()
        {
            this.InitializeComponent();
            
        }

        void LoadData()
        {
            HttpClient client = new HttpClient();
            string data = client.GetStringAsync(string.Format("http://www.omdbapi.com/?t={0}&y={1}&plot=full&r=json",txtTitle.Text, txtReleaseYear.Text)).Result;
            Movie m = Newtonsoft.Json.JsonConvert.DeserializeObject<Movie>(data);
            this.DataContext = m;
        }

        private void Search_click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
