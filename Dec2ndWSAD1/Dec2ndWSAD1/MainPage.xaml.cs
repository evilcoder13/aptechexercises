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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Dec2ndWSAD1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnKeyDown_Username(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
                AuthenticateAndLogin();
        }

        private void OnKeyDown_Password(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
                AuthenticateAndLogin();
        }

        private void OnClick_Login(object sender, RoutedEventArgs e)
        {
            AuthenticateAndLogin();
        }
        private void AuthenticateAndLogin()
        {
            if (xnUsername.Text == "admin" && xnPassword.Password == "abcd@1234")
                Frame.Navigate(typeof(NextPage));
            else
                xnMsg.Text = "Incorrect username or password!";
        }
    }
}
