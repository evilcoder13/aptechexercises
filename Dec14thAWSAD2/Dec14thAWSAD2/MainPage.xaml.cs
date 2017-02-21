using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

namespace Dec14thAWSAD2
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Language> ListLanguage = new List<Language>(){
            new Language() { Text="English", Value="en"},
            new Language() { Text="Vietnamese", Value="vi"},
            new Language() { Text="Japanese", Value="jp"},
            new Language() { Text="France", Value="fr"}
        };
        public MainPage()
        {
            this.InitializeComponent();
            cbToLanguage.DataContext = ListLanguage.ToList();
            ListLanguage.Add(new Language() { Text = "Auto", Value = "auto" });
            cbFromLanguage.DataContext = ListLanguage.ToList();
            cbToLanguage.DisplayMemberPath = "Text";
            cbToLanguage.SelectedValuePath = "Value";
            cbFromLanguage.DisplayMemberPath = "Text";
            cbFromLanguage.SelectedValuePath = "Value";
        }

        private void Translate_Click(object sender, RoutedEventArgs e)
        {
            //Link service: https://translate.googleapis.com/translate_a/single?client=gtx&sl=en&tl=vi&dt=t&q=text to translate
            HttpClient client = new HttpClient();
            string result = client.GetStringAsync(string.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}", cbFromLanguage.SelectedValue, cbToLanguage.SelectedValue, Uri.EscapeDataString(txtSourceTranslate.Text))).Result;

            if (!result.Contains("],["))
            {
                string translated = result.Split(new string[] { "\",\"" + txtSourceTranslate.Text }, StringSplitOptions.None)[0].Substring(4);
                txtTargetTranslate.Text = translated;
            }
            else
            {
                string[] results = result.Split(new string[] { "],[" }, StringSplitOptions.None);


                foreach(string r in results)
                {
                    string translated = r.Split(new string[] { "\",\"" }, StringSplitOptions.None)[0].Substring(1);
                    while (translated[0] == '['||translated[0] == '\"')
                        translated = translated.Substring(1);
                    txtTargetTranslate.Text += translated;
                }
            }
        }

        private void Movies_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MovieSearchPage));
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
