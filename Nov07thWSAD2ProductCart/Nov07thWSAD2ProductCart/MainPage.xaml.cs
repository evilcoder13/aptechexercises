using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Nov07thWSAD2ProductCart
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
                list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Account>>(await FileIO.ReadTextAsync(await ApplicationData.Current.LocalFolder.GetFileAsync("Login.txt")));
                ThongBao("Du lieu da duoc lay tu ban ghi gan nhat!");
            }
            catch { }
        }

        async void SaveData()
        {
            try
            {
                await ApplicationData.Current.LocalFolder.CreateFileAsync("Login.txt");
            }
            catch { }
            await FileIO.WriteTextAsync(await ApplicationData.Current.LocalFolder.GetFileAsync("Login.txt"), Newtonsoft.Json.JsonConvert.SerializeObject(list));
            ThongBao("Luu du lieu thanh cong!");
        }
        void ThongBao(string message)
        {
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog(message);
            m.ShowAsync();
        }
        List<Account> list = new List<Account>();
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            List<Account> list1 = list.Where(a => a.UserName.Equals(xnUserName.Text) && a.Password.Equals(xnPassword.Text)).ToList();
            if (list1.Count() > 0)
            {
                Account c = list1[0];
                Frame.Navigate(typeof(ProductPage), c.UserName);
            }
            else
                ThongBao("Incorrect username or password");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();


        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (xnUserName.Text == "" || xnPassword.Text == "")
            {
                ThongBao("Phai nhap username & password");
                return;
            }
            Account c = new Account();
            c.UserName = xnUserName.Text;
            c.Password = xnPassword.Text;
            list.Add(c);
            SaveData();
        }

        private void Share_Click(object sender, RoutedEventArgs e)
        {
            Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI();
        }
    }
}
