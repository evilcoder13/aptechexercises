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

namespace Oct28thWSAD2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Account> listAccount = new List<Account>();
        public MainPage()
        {
            this.InitializeComponent();
            //Khi load chuong trinh thi load du lieu da luu vao bien list Account de login
            LoadData();
        }

        async void LoadData()
        {
            //try
            //{
            //    listAccount = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Account>>(await Windows.Storage.FileIO.ReadTextAsync(await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appdata:///local/Login.txt"))));
            //}
            //catch { ThongBao("Chua co du lieu, vui long dang ky!"); }
            try
            {
                //Doc du lieu tren file Login.txt vao duoi dang Json, sau do convert ve kieu List<Account> va gan vao bien
                listAccount = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Account>>(await FileIO.ReadTextAsync(await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appdata:///local/Login.txt"))));
            }
            catch { ThongBao("Chua co du lieu, vui long dang ky!"); }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            //if(listAccount.Where(a => a.UserName.Equals(txtUserName.Text) && a.Password.Equals(txtPassword.Text)).Count()>0)
            //{
            //    ThongBao("Login thanh cong!");
            //    Frame.Navigate(typeof(Calculator));
            //}
            //else
            //    ThongBao("Sai ten dang nhap hoac mat khau!");
            
            //Dung Linq kiem tra xem du UserName & Password co trong csdl (list) thi se cho phep login.
            if (listAccount.Where(a => a.UserName.Equals(txtUserName.Text) && a.Password.Equals(txtPassword.Text)).Count() > 0)
            {
                ThongBao("Login thanh cong!");
                Frame.Navigate(typeof(Calculator));
            }
            else
                ThongBao("Sai ten dang nhap hoac mat khau!");
        }
        
        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            //if(!(listAccount.Where(u=>u.UserName.Equals(txtUserName.Text)).Count()>0))
            //listAccount.Add(new Account() { UserName=txtUserName.Text, Password=txtPassword.Text});
            //try
            //{
            //    await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync("Login.txt");
            //}
            //catch { }
            ////Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("Login.txt");
            //await Windows.Storage.FileIO.WriteTextAsync(await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appdata:///local/Login.txt")), Newtonsoft.Json.JsonConvert.SerializeObject(listAccount));
            //ThongBao("Them moi thanh cong!");

            //Kiem tra user dang ky da ton tai trong csdl hay chua.
            if (listAccount.Where(a => a.UserName.Equals(txtUserName.Text)).Count() > 0)
            {
                ThongBao("Username da ton tai trong csdl!");
                return;
            }
            else
                listAccount.Add(new Account() { UserName = txtUserName.Text, Password = txtPassword.Text }); //Add account vao list account hien co cua chuong trinh
            try
            {
                //Tao file Login.txt de luu du lieu Login. Try catch de xu ly truong hop file da ton tai (thi khong tao lai file nua)
                await ApplicationData.Current.LocalFolder.CreateFileAsync("Login.txt");
            }
            catch { }
            //Ghi du lieu list account hien co vao file Login.txt duoi dang json.
            await FileIO.WriteTextAsync(await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appdata:///local/Login.txt")), Newtonsoft.Json.JsonConvert.SerializeObject(listAccount));
            ThongBao("Dang ky thanh cong!");
        }

        void ThongBao(string message)
        {
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog(message);
            m.ShowAsync();
        }
    }
}
