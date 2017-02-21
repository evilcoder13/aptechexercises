using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Nov04thAWSADChat
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Chat : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        public Chat()
        {
            this.InitializeComponent();
            LoadData();
            
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, object e)
        {
            LoadData();
        }
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        void LoadData()
        {
            timer.Stop();
            xnList.DataContext = client.GetAllAsync().Result;
            //Update tile
            XmlDocument newSquareTileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150Text01);
            XmlNodeList newSquareTileTextAttributes = newSquareTileXml.
            GetElementsByTagName("text");
            newSquareTileTextAttributes[0].AppendChild(
            newSquareTileXml.CreateTextNode("This is notification#3"));
            TileNotification n = new TileNotification(newSquareTileXml);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(n);

            //Update Badge
            XmlDocument myBadgeXml = BadgeUpdateManager.GetTemplateContent(BadgeTemplateType.BadgeGlyph);
            XmlElement badgeElement = (XmlElement)myBadgeXml.SelectSingleNode("/badge");
            badgeElement.SetAttribute("value", xnList.Items.Count.ToString());
            BadgeNotification myBadge = new BadgeNotification(myBadgeXml);
            BadgeUpdateManager.CreateBadgeUpdaterForApplication().
            Update(myBadge);

            timer.Start();
        }
        string Sender = "Khong biet";
        private void Send_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.TextMessage mess = new ServiceReference1.TextMessage();
            mess.Sender = Sender;
            mess.Content = xnMessage.Text;
            mess.SentTime = DateTime.Now;
            client.InsertMessageAsync(mess);
            xnMessage.Text = "";
            //Show toast notification
            ToastTemplateType myToastTemplate = ToastTemplateType.ToastText01;
            XmlDocument myToastXml = ToastNotificationManager.GetTemplateContent(myToastTemplate);
            XmlNodeList myToastTextElements = myToastXml.GetElementsByTagName("text");
            myToastTextElements[0].AppendChild(myToastXml.CreateTextNode("Message sent at: " + mess.SentTime.ToString()));
            ToastNotification myToast = new ToastNotification(myToastXml);
            ToastNotificationManager.CreateToastNotifier().Show(myToast);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Sender = e.Parameter.ToString();
            base.OnNavigatedTo(e);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
