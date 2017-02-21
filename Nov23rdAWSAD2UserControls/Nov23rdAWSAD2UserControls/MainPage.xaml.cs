using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Nov23rdAWSAD2UserControls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            List<Language> l = new List<Language>();
            l.Add(new Language("en-US"));
            l.Add(new Language("vi-VN"));
            xnLanguage.DataContext = l;
            xnLanguage.DisplayMemberPath = "DisplayName";
            xnLanguage.SelectedValuePath = "LanguageTag";
            if (Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride == "en-US")
                xnLanguage.SelectedIndex = 0;
            else
                xnLanguage.SelectedIndex = 1;
        }

        private void xnLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (xnLanguage.SelectedIndex < 0)
                return;
            string locale = xnLanguage.SelectedValue.ToString();

            Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = locale;

            ResourceContext context = new ResourceContext();
            context.Languages = new List<string>() { locale };
            ResourceMap map = ResourceManager.Current.MainResourceMap.GetSubtree("Resources");
            lblChangeLanguage.Text = map.GetValue("lblChangeLanguage", context).ValueAsString;
            if(locale=="vi")
                xnLanguageImage.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("ms-appx:///Assets/flag-256x256-vn.png"));
            else
                xnLanguageImage.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("ms-appx:///Assets/flag-256x256-us.png"));
            //Frame.Navigate(typeof(MainPage));
            ((Frame)Window.Current.Content).Navigate(typeof(MainPage));
        }
    }
}
