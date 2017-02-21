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

namespace Nov18thAWSAD
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NextPage : Page
    {
        public NextPage()
        {
            this.InitializeComponent();
        }

        private void OnClick_Logout(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void OnClick_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void OnClick_Play(object sender, RoutedEventArgs e)
        {
            xnVideoPlayer.Play();
        }

        private void OnClick_Pause(object sender, RoutedEventArgs e)
        {
            xnVideoPlayer.Pause();
        }

        private void OnClick_Stop(object sender, RoutedEventArgs e)
        {
            xnVideoPlayer.Stop();
        }

        private async void OnClick_OpenFileVideo(object sender, RoutedEventArgs e)
        {
            Windows.Storage.Pickers.FileOpenPicker picker = new Windows.Storage.Pickers.FileOpenPicker();

            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.VideosLibrary;
            picker.FileTypeFilter.Add(".mp4");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            //this.filePath.Text = file.Path;

            // Lỗi: nếu người dùng bấm chọn Open File nhưng ko chọn file
            // thì bị văng ứng dụng, vui lòng kiểm tra NULL.
            if (file != null)
            {
                var source = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                this.xnVideoPlayer.SetSource(source, file.ContentType);
                this.xnVideoPlayer.AutoPlay = true;
            }
        }

        private void OnClick_UpdateTile(object sender, RoutedEventArgs e)
        {
            //Goi den tile mac dinh cua chuong trinh & clear cac update hien co
            var updater = Windows.UI.Notifications.TileUpdateManager.CreateTileUpdaterForApplication();
            updater.EnableNotificationQueue(true);
            updater.Clear();
            //Khoi tao tile theo mau
            var tileXml = Windows.UI.Notifications.TileUpdateManager.GetTemplateContent(Windows.UI.Notifications.TileTemplateType.TileWide310x150ImageAndText01);
            Windows.Data.Xml.Dom.XmlNodeList nodesText = tileXml.GetElementsByTagName("text");
            nodesText[0].InnerText = "1Stay Hungry! Stay Foolish!";

            Windows.Data.Xml.Dom.XmlNodeList nodesImg = tileXml.GetElementsByTagName("image");
            //((Windows.Data.Xml.Dom.XmlElement)nodesImg[0]).SetAttribute("src", "ms-appx:///Assets/logo-310x150-google.png");
            ((Windows.Data.Xml.Dom.XmlElement)nodesImg[0]).SetAttribute("src", "ms-appx:///Assets/logo-310x150-apple-stevejobs.png");

            var binding = tileXml.ImportNode(tileXml.GetElementsByTagName("binding")[0], true);
            tileXml.GetElementsByTagName("visual")[0].AppendChild(binding);

            updater.Update(new Windows.UI.Notifications.TileNotification(tileXml));
        }

        private void OnClick_UpdateBadge(object sender, RoutedEventArgs e)
        {
            var updater = Windows.UI.Notifications.BadgeUpdateManager.CreateBadgeUpdaterForApplication();
            Windows.Data.Xml.Dom.XmlDocument badgeXml = Windows.UI.Notifications.BadgeUpdateManager.GetTemplateContent(Windows.UI.Notifications.BadgeTemplateType.BadgeNumber);
            (badgeXml.SelectSingleNode("/badge") as Windows.Data.Xml.Dom.XmlElement).SetAttribute("value", "50");
            updater.Update(new Windows.UI.Notifications.BadgeNotification(badgeXml));
        }
    }
}
