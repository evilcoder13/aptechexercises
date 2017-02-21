using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Nov23rdAWSAD2UserControls
{
    public sealed partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            this.InitializeComponent();

            string locale = Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride;

            ResourceContext context = new ResourceContext();
            context.Languages = new List<string>() { locale };
            ResourceMap map = ResourceManager.Current.MainResourceMap.GetSubtree("Resources");
            tbUsername.Text = map.GetValue("lblUsername", context).ValueAsString;
            tbPassword.Text = map.GetValue("lblPassword", context).ValueAsString;
            btnLogin.Content = map.GetValue("btnLogin", context).ValueAsString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtUserName.Text == "Admin" && txtPassword.Text == "1234567")
            {
                ((Frame)Window.Current.Content).Navigate(typeof(MyPage));
            }
            else
            {
                tbStatus.Text = "Login failed!";
            }
        }
    }
}
