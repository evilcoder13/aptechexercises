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

namespace Nov07thWSAD2ProductCart
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CartPage : Page
    {
        public CartPage()
        {
            this.InitializeComponent();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            //Frame.GoBack();
            Frame.Navigate(typeof(ProductPage), listCart);
        }

        private async void Pay_Click(object sender, RoutedEventArgs e)
        {
            StorageFile sfile;
            if(listCart.Count>0)
            {
                try
                {
                    await ApplicationData.Current.LocalFolder.CreateFileAsync("" + listCart[0].UserName + "Order" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".json");
                }
                catch { }

                sfile = await ApplicationData.Current.LocalFolder.GetFileAsync("" + listCart[0].UserName + "Order" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".json");
            }
            else
            {
                try
                {
                    await ApplicationData.Current.LocalFolder.CreateFileAsync("Order" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".json");
                }
                catch { }

                sfile = await ApplicationData.Current.LocalFolder.GetFileAsync("Order" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".json");
            }
            await FileIO.WriteTextAsync(sfile, Newtonsoft.Json.JsonConvert.SerializeObject(listCart));
            listCart = new List<Cart>();
            ThongBao("Pay finished! Transaction saved into: " + sfile.Name);
            //StorageFolder.GetFolderFromPathAsync("ms-appdata:///local/")
            LoadData();
        }

        private void GoHome_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        List<Cart> listCart = new List<Cart>();

        void LoadData()
        {
            var list1 = listCart.Where(c => c.Buy).ToList();
            lstCart.DataContext = list1;
            xnTotal.Text = string.Format("Total: {0}", list1.Sum(c => c.Price * c.Quantity));
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            listCart = e.Parameter as List<Cart>;
            LoadData();
        }

        private void Check_change(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        void ThongBao(string message)
        {
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog(message);
            m.ShowAsync();
        }
    }
}
