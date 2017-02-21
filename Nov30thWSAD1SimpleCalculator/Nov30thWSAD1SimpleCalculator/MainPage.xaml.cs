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

namespace Nov30thWSAD1SimpleCalculator
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

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if(isSet)
            {
                txtCalculator.Text = oriNumber.ToString();
                oriNumber = 0;
                isSet = false;
            }
            Button b = (Button)sender;
            txtCalculator.Text += b.Content;
        }

        private void Function_Click(object sender, RoutedEventArgs e)
        {
            if (isSet)
            {
                txtCalculator.Text = oriNumber.ToString();
                oriNumber = 0;
                isSet = false;
            }
            Button b = (Button)sender;
            string f = b.Content.ToString();
            switch(f)
            {
                case "=":
                    string cal = txtCalculator.Text;
                    string numbers = "0123456789";
                    while(cal.Contains("!"))
                    {
                        int idx = cal.IndexOf("!");
                        int sidx = -1;
                        for (int i = idx - 1; i >= 0; i--)
                            if (numbers.IndexOf(cal[i]) == -1)
                            { 
                                sidx = i;
                                break;
                            }

                        string sotinhgiaithua = cal.Substring(sidx + 1, idx - sidx-1);
                        int giaithua = TinhGiaiThua(int.Parse(sotinhgiaithua));
                        string s1 = cal.Substring(0, sidx + 1);
                        string s2= cal.Substring(idx + 1, cal.Length - idx-1);
                        cal = s1 + giaithua.ToString() + s2;
                    }
                    Jace.CalculationEngine engine = new Jace.CalculationEngine();
                    txtCalculator.Text = engine.Calculate(cal).ToString();
                    break;
            }
        }

        int TinhGiaiThua(int g)
        {
            int gt = g;
            for (int i = 1; i < g; i++)
                gt = gt * i;
            return gt;
        }
        int oriNumber = 0;
        bool isSet = false;
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstConvert.SelectedIndex <= 0)
                return;

            var s = lstConvert.SelectedItem as ListBoxItem;
            
            string convert = s.Content.ToString();
            if (!isSet)
            { 
                oriNumber = int.Parse(txtCalculator.Text);
                isSet = true;
            }
            switch(convert)
            {
                case "BIN":
                    txtCalculator.Text = Convert.ToString(oriNumber,2);
                    break;
                case "OCT":
                    txtCalculator.Text = Convert.ToString(oriNumber, 8);
                    break;
                case "DEC":
                    txtCalculator.Text = Convert.ToString(oriNumber, 10);
                    break;
                case "HEX":
                    txtCalculator.Text = Convert.ToString(oriNumber,16);
                    break;
            }
        }
    }
}
