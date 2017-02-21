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
using Windows.Storage;
using Windows.Storage.Pickers;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Dec05thWSAD1
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

        private void Employee_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Employees));
        }

        private async void BrowsePhoto_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fop = new FileOpenPicker();
            fop.FileTypeFilter.Add(".jpg");
            fop.FileTypeFilter.Add(".gif");
            fop.FileTypeFilter.Add(".png");
            fop.FileTypeFilter.Add(".bmp");

            fop.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            fop.ViewMode = PickerViewMode.Thumbnail;

            var f = await fop.PickSingleFileAsync();
            if (f != null && f.Name != "")
                ThongBao("Da chon file: " + f.Path);
        }

        void ThongBao(string message)
        {
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog(message);
            m.ShowAsync();
        }

        private async void Folder_click(object sender, RoutedEventArgs e)
        {
            FolderPicker fp = new FolderPicker();
            fp.FileTypeFilter.Add(".jpg");
            fp.FileTypeFilter.Add(".gif");
            fp.FileTypeFilter.Add(".png");
            fp.FileTypeFilter.Add(".bmp");
            fp.SuggestedStartLocation = PickerLocationId.ComputerFolder;
            fp.ViewMode = PickerViewMode.List;
            var f = await fp.PickSingleFolderAsync();

            if (f != null)
            {
                string ListFolders = "";
                string ListFiles = "";

                foreach (var fo in await f.GetFoldersAsync())
                {
                    ListFolders += fo.Name + Environment.NewLine;
                }

                foreach (var fi in await f.GetFilesAsync())
                {
                    ListFiles += fi.Name + Environment.NewLine;
                }

                ThongBao("Files: " + ListFiles + "Folders: " + ListFolders);
            }
            else
                ThongBao("Cancel!");
        }
    }
}
