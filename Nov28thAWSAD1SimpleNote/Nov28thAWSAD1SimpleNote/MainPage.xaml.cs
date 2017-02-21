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

namespace Nov28thAWSAD1SimpleNote
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //Load danh sach Account tu file
            LoadData();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        async void LoadData()
        {
            try
            {
                //Load danh sach Account tu file Login.txt nam trong Local Folder, du lieu string JSON duoc doc ra list
                list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Account>>(await FileIO.ReadTextAsync(await ApplicationData.Current.LocalFolder.GetFileAsync("Login.txt")));
                ThongBao("Du lieu da duoc lay tu ban ghi gan nhat!");
            }
            catch { }
        }

        async void SaveData()
        {
            try
            {
                //Tao file Login.txt trong Local Folder, neu file da co thi catch qua ma khong thong bao gi.
                await ApplicationData.Current.LocalFolder.CreateFileAsync("Login.txt");
            }
            catch { }
            //Luu du lieu vao file Login.txt trong Local Folder, list duoc luu lai duoi dang JSON
            await FileIO.WriteTextAsync(await ApplicationData.Current.LocalFolder.GetFileAsync("Login.txt"), Newtonsoft.Json.JsonConvert.SerializeObject(list));
            ThongBao("Luu du lieu thanh cong!");
        }
        /// <summary>
        /// Hien popup
        /// </summary>
        /// <param name="message">Thong bao tren popup</param>
        void ThongBao(string message)
        {
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog(message);
            m.ShowAsync();
        }
        List<Account> list = new List<Account>();
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            //Tim kiem cac username & password thoa man dieu kien tim kiem
            List<Account> list1 = list.Where(a => a.UserName.Equals(xnUserName.Text) && a.Password.Equals(xnPassword.Text)).ToList();
            //Kiem tra xem co tim thay phan tu nao (Account) thoa man dieu kien UserName va Password nhap vao khong
            if (list1.Count() > 0)
            {
                //Neu co account, lay ra Account dau tien de xu ly.
                Account c = list1[0];
                //Toast notification hien thong bao theo yeu cau de bai
                NotificationUtil.ToastNotification(xnUserName.Text + " logged in at " + DateTime.Now);
                //CHuyen trang sau khi login xong
                Frame.Navigate(typeof(NotePage), c.UserName);
            }
            else
                ThongBao("Incorrect username or password"); //Hien thong bao neu login sai.
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            //Thoat chuong trinh
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
