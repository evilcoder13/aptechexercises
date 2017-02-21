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
using System.Net.Http;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Nov07thWSAD2ProductCart
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductPage : Page
    {
        List<Product> list = new List<Product>();
        string UserName = "";
        public ProductPage()
        {
            this.InitializeComponent();
            HttpClient client = new HttpClient();
            string listProduct = client.GetStringAsync("http://localhost:9000/api/products").Result;
            list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(listProduct);
            LoadData();
        }

        int index = 0;
        void LoadData()
        {
            if (list.Count <= 0)
                return;
            if (index < 0)
                index = 0;
            if (index > list.Count - 1)
                index = list.Count - 1;

            this.DataContext = list[index];
            xnPrevious.IsEnabled = !(index == 0);
            xnNext.IsEnabled = !(index == list.Count - 1);
            enableForm(false);
        }

        void enableForm(bool enable = true)
        {
            xnCategory.IsEnabled = xnPrice.IsEnabled = xnProdName.IsEnabled = enable;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
        List<Cart> listCart = new List<Cart>();
        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            Cart c = new Cart();
            c.ProductId = int.Parse(xnProdID.Text);
            var l1 = listCart.Where(p => p.ProductId == c.ProductId&&p.UserName==UserName).ToList();
            if (l1.Count <= 0)
            {
                c.Name = xnProdName.Text;
                c.Price = int.Parse(xnPrice.Text);

                c.Buy = true;
                c.Category = xnCategory.Text;
                c.UserName = UserName;
                c.Quantity = 1;

                listCart.Add(c);
            }
            else
            {
                c = l1[0];
                c.Quantity+=1;
            }
            ThongBao("Product added to cart!");
        }

        private void ShowCart_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CartPage), listCart);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void ReloadData_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            string listProduct = client.GetStringAsync("http://localhost:9000/api/products").Result;
            list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(listProduct);
            if (index > list.Count - 1)
                index = 0;
            if (list.Count > 0)
                LoadData();

        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            index--;
            LoadData();

        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            index++;
            LoadData();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new Product();
            enableForm();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //Remove data from service
            HttpClient client = new HttpClient();
            client.DeleteAsync("http://localhost:9000/api/products/" + xnProdID.Text);
            //End remove data from service
            list.RemoveAt(index);
            if (index > list.Count - 1)
                index--;
            if (index >= 0)
                LoadData();
        }
        void ThongBao(string message)
        {
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog(message);
            m.ShowAsync();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Product p = new Product();
            //p.Id = xnProdID.Text;
            p.Name = xnProdName.Text;
            try
            {
                p.Price = int.Parse(xnPrice.Text);
            }
            catch { ThongBao("Price must be number!"); xnPrice.Focus(Windows.UI.Xaml.FocusState.Keyboard); return; }
            p.Category = xnCategory.Text;
            HttpClient client = new HttpClient();
            //var formContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(p), System.Text.Encoding.UTF8, "text/json");
            //var formContent = new MultipartFormDataContent(Newtonsoft.Json.JsonConvert.SerializeObject(p));

            var formContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(p), System.Text.Encoding.UTF8, "text/json");
            var r = client.PostAsync("http://localhost:9000/api/products/",formContent);
            p = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(r.Result.Content.ReadAsStringAsync().Result);
            list.Add(p);
            index = list.Count - 1;
            LoadData();
            ThongBao("Data added successfully!");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if(e.Parameter.GetType()==typeof(string))
            {
                UserName = e.Parameter as string;
            }
            else
            {
                listCart = e.Parameter as List<Cart>;
                if (listCart.Count > 0)
                    UserName = listCart[0].UserName;
            }
        }
    }
}
