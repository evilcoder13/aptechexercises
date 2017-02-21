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

namespace Nov25thAWSAD
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MathGame : Page
    {
        public MathGame()
        {
            this.InitializeComponent(); 
            txtTimer.Text = playTime.ToString();
            t.Interval = new TimeSpan(0,0,1);
            t.Tick += t_Tick;
            this.DataContext = true;
            NewCalculation();
        }

        void t_Tick(object sender, object e)
        {
            txtTimer.Text = (int.Parse(txtTimer.Text) - 1).ToString();
            if (txtTimer.Text == "0")
            {
                LoseGame();
            }
            //throw new NotImplementedException();
        }
        string UserName = "test";
        async void LoseGame()
        {
            t.Stop();
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog("You lose! Your point: " + point);
            m.ShowAsync();
            Windows.Storage.FileIO.AppendLinesAsync(await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appdata:///local/Result.txt")), new List<string>() {UserName + ":" + point});
            this.DataContext = false;
        }
        bool answer = false;
        int point = 0;
        int quest = 0;
        int level = 1;
        int playTime = 10;
        Random r = new Random();
        DispatcherTimer t = new DispatcherTimer();
        void NewCalculation()
        {
            if (level == null || level <= 0)
                level = 1;
            //Chia level, moi level tang se tang 2 so them 10 lan.
            txtNum1.Text = r.Next(0, (int)Math.Pow(10, level)).ToString();
            txtNum2.Text = r.Next(0, (int)Math.Pow(10, level)).ToString();
            //Random dau +-*/
            switch (r.Next(1, 5))
            {
                case 1:
                    txtSign.Text = "+";
                    break;
                case 2:
                    txtSign.Text = "-";
                    break;
                case 3:
                    txtSign.Text = "*";
                    break;
                case 4:
                default:
                    txtSign.Text = "/";
                    break;
            }
            answer = (r.Next(0, 10) > 5);
            Jace.CalculationEngine engine = new Jace.CalculationEngine();
            txtNum3.Text = engine.Calculate(txtNum1.Text + txtSign.Text + txtNum2.Text).ToString();
            if (!answer)
                do
                {
                    if (int.Parse(txtNum3.Text) < 10)
                        txtNum3.Text = r.Next(0, 10).ToString();
                    txtNum3.Text = (r.Next(int.Parse(txtNum3.Text) - 9, int.Parse(txtNum3.Text) + 9)).ToString();
                }
                while (txtNum3.Text == engine.Calculate(txtNum1.Text + txtSign.Text + txtNum2.Text).ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (t.IsEnabled)
                t.Stop();
            if (((Button)sender).Content.ToString().ToLower() == answer.ToString().ToLower())
            {
                point += level;
                quest++;
                if (quest % 10 == 0)
                    level++;
                NewCalculation();
                txtTimer.Text = playTime.ToString();
                t.Start();
            }
            else
            {
                LoseGame();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            UserName = e.Parameter as string;
            base.OnNavigatedTo(e);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private async void List_Click(object sender, RoutedEventArgs e)
        {
            string s = await Windows.Storage.FileIO.ReadTextAsync(await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appdata:///local/Result.txt")));
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog(s);
            m.ShowAsync();
        }
    }
}
