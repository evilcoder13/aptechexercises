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

namespace Oct17thWSADEmployeeManagement
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
            Frame.Navigate(typeof(EmployeeList));
        }

        private async void BrowsePhoto_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fop = new FileOpenPicker();
            fop.FileTypeFilter.Add(".jpg");
            fop.FileTypeFilter.Add(".png");
            fop.FileTypeFilter.Add(".gif");
            fop.FileTypeFilter.Add(".tif");
            fop.FileTypeFilter.Add(".bmp");

            fop.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            fop.ViewMode = PickerViewMode.Thumbnail;

            var f = await fop.PickSingleFileAsync();
            if(f!=null)
            { 
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog(f.Name);
            m.ShowAsync();
            }
            else
            {
                Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog("No image has been choosen!");
                m.ShowAsync();
            }
        }

        private async void BrowseFolders_Click(object sender, RoutedEventArgs e)
        {
            FolderPicker fp = new FolderPicker();
            fp.FileTypeFilter.Add(".jpg");
            fp.FileTypeFilter.Add(".png");
            fp.FileTypeFilter.Add(".gif");
            fp.FileTypeFilter.Add(".tif");
            fp.FileTypeFilter.Add(".bmp");

            fp.SuggestedStartLocation = PickerLocationId.Desktop;
            fp.ViewMode = PickerViewMode.List;

            var f = await fp.PickSingleFolderAsync();

            var listFIles = await f.GetFilesAsync();
            string FileNames = "";
            foreach (var fi in listFIles)
                FileNames += fi.Name + Environment.NewLine;
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog("Files: "+FileNames);
            await m.ShowAsync();

            var listFIolders = await f.GetFoldersAsync();
            string FolderNames = "";
            foreach (var fo in listFIolders)
                FolderNames += fo.Name + Environment.NewLine;
            m = new Windows.UI.Popups.MessageDialog("Folders: " + FolderNames);
            m.ShowAsync();


        }
    }
}
