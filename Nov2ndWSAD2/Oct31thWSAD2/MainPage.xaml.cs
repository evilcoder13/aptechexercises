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

namespace Nov2ndWSAD2
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

        private void OnClick_Login(object sender, RoutedEventArgs e)
        {
            AuthenticateAndLogin();
        }

        void AuthenticateAndLogin()
        {
            if (xnUsername.Text == "admin" && xnPassword.Password == "abcd@1234")
            {
                Frame.Navigate(typeof(NextPage));
            }
            else
                xnMsg.Text = "Sai username & password!";
        }

        private void OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key.Equals(Windows.System.VirtualKey.Enter))
                AuthenticateAndLogin();
        }
    }
}
