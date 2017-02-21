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
using Windows.Storage;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Dec07thWSAD1ProductManagement
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadData();
        }

        async void LoadData()
        {
            try
            {
                var f = await local.GetFileAsync("Login.txt");
                string jsonString = await FileIO.ReadTextAsync(f);
                list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Account>>(jsonString);
            }
            catch { }
        }

        async void SaveData()
        {
            var f = await local.CreateFileAsync("Login.txt", CreationCollisionOption.ReplaceExisting);
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            await FileIO.WriteTextAsync(f, jsonString);
        }
        List<Account> list = new List<Account>();
        StorageFolder local = ApplicationData.Current.LocalFolder;
        private void Login_click(object sender, RoutedEventArgs e)
        {
            if (list.Any(a => a.Username == xnUsername.Text && a.Password == xnPassword.Password))
                Frame.Navigate(typeof(ProductPage));
            else
                ThongBao("Login failed!");
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(xnUsername.Text) && !string.IsNullOrEmpty(xnPassword.Password))
                if (!list.Any(a => a.Username.Equals(xnUsername.Text)))
                {
                    list.Add(new Account() { Username = xnUsername.Text, Password = xnPassword.Password });
                    SaveData();
                    ThongBao("Register successfully!");
                }
                else
                    ThongBao("Duplicate username!");
            else
                ThongBao("Username and Password must not be empty!");

        }

        void ThongBao(string message)
        {
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog(message);
            m.ShowAsync();
        }
    }
}
