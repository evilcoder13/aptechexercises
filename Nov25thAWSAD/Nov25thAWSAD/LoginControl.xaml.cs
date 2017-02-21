using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources.Core;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Nov25thAWSAD
{
    public sealed partial class LoginControl : UserControl
    {
        async void LoadData()
        {
            try
            {
                //Load danh sach Account tu file Login.txt nam trong Local Folder, du lieu string JSON duoc doc ra list
                list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Account>>(await FileIO.ReadTextAsync(await ApplicationData.Current.LocalFolder.GetFileAsync("Login.txt")));
                tbStatus.Text = map.GetValue("DataSaved", context).ValueAsString; //"Du lieu da duoc lay tu ban ghi gan nhat!";
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
            tbStatus.Text = map.GetValue("DataLoaded", context).ValueAsString;//"Luu du lieu thanh cong!";
        }
        
        List<Account> list = new List<Account>();
        ResourceContext context = new ResourceContext();
        ResourceMap map = ResourceManager.Current.MainResourceMap.GetSubtree("Resources");
        public LoginControl()
        {
            this.InitializeComponent();

            string locale = Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride;
            
            context.Languages = new List<string>() { locale };
            tbUsername.Text = map.GetValue("lblUsername", context).ValueAsString;
            tbPassword.Text = map.GetValue("lblPassword", context).ValueAsString;
            btnLogin.Content = map.GetValue("btnLogin", context).ValueAsString;
            btnRegister.Content = map.GetValue("btnRegister", context).ValueAsString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (list.Any(a => a.Username.Equals(txtUserName.Text) && a.Password.Equals(txtPassword.Password)))
            {
                ((Frame)Window.Current.Content).Navigate(typeof(MathGame), txtUserName.Text);
            }
            else
            {
                tbStatus.Text = map.GetValue("LoginFailed", context).ValueAsString;
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (txtUserName.Text == "" || txtPassword.Password == "")
            {
                tbStatus.Text = map.GetValue("BlankUsernamePassword", context).ValueAsString;
                return;
            }
            Account c = new Account();
            c.Username = txtUserName.Text;
            c.Password = txtPassword.Password;
            list.Add(c);
            SaveData();
        }
    }
}
