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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Nov18thAWSAD
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            xnComboBox.ItemsSource = new LanguageList();
            xnComboBox.DisplayMemberPath = "Name";
            xnComboBox.SelectedValuePath = "Locale";
            //var resourcestring = ResourceManager.Current.MainResourceMap.GetSubtree("Resources");
            //var r = resourcestring.GetValue("uidComboBox.Header");
            //xnTestText.Text = r.ValueAsString;
        }

        private void OnClick_Login(object sender, RoutedEventArgs e)
        {
            AuthenticateAndLogin();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private void AuthenticateAndLogin()
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();

            if (this.xnUsername.Text != "admin")
            {
                this.xnMsg.Text = loader.GetString("msg_wrong_username");//"Wrong username!";
                return;
            }

            if (this.xnPassword.Password != "abcd@1234")
            {
                this.xnMsg.Text = loader.GetString("msg_wrong_password"); //"Wrong password!";
                return;
            }

            Frame.Navigate(typeof(NextPage));
        }

        private void OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key.Equals(Windows.System.VirtualKey.Enter))
                AuthenticateAndLogin();
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (xnComboBox.SelectedIndex < 0)
                return;
            string locale = xnComboBox.SelectedValue.ToString();
            //Thay doi ngon ngu chuong trinh
            Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = locale;
            //Reset thread
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo(locale);
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = new System.Globalization.CultureInfo(locale);
            //Reset view & context
            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();
            Windows.ApplicationModel.Resources.Core.ResourceManager.Current.DefaultContext.Reset();
            //Chuyen trang
            Frame.Navigate(typeof(MainPage));
        }
    }
}
