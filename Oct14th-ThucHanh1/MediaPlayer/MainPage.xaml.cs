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
using Windows.Media.MediaProperties;
using Windows.Media.Transcoding;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MediaPlayer
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

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }


        private async void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fop = new FileOpenPicker();
            fop.FileTypeFilter.Add(".mp4");
            fop.FileTypeFilter.Add(".avi");
            fop.FileTypeFilter.Add(".wmv");
            fop.SuggestedStartLocation = PickerLocationId.VideosLibrary;
            fop.ViewMode = PickerViewMode.Thumbnail;
            var f = await fop.PickSingleFileAsync();
            media1.SetSource(await f.OpenReadAsync(), f.FileType);
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            AppBarToggleButton b = (AppBarToggleButton)sender;
            if(media1.CanPause && b.Label=="Pause")
            { 
                media1.Pause();
                b.Icon = new SymbolIcon(Symbol.Play);
                b.Label = "Play";
            }
            else
            {
                media1.Play();
                
                b.Icon = new SymbolIcon(Symbol.Pause);
                b.Label = "Pause";
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            media1.Stop();
        }

        private async void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            FolderPicker fp = new FolderPicker();
            fp.FileTypeFilter.Add(".mp4");
            fp.FileTypeFilter.Add(".avi");
            fp.FileTypeFilter.Add(".wmv");
            fp.SuggestedStartLocation = PickerLocationId.VideosLibrary;
            var folder = await fp.PickSingleFolderAsync();

            var listMovies = await folder.GetFilesAsync();
            cbMovieList.DataContext = listMovies;
        }

        private async void cbMovieList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbMovieList.SelectedIndex < 0)
                return;

            StorageFile s = cbMovieList.SelectedItem as StorageFile;
            
            media1.SetSource(await s.OpenReadAsync(), s.FileType);
        }

        private async void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            MediaTranscoder mt = new MediaTranscoder();
            MediaEncodingProfile mep = MediaEncodingProfile.CreateAvi(VideoEncodingQuality.HD720p);
            //Chon file de convert
            FileOpenPicker fop = new FileOpenPicker();
            fop.FileTypeFilter.Add(".mp4");
            fop.FileTypeFilter.Add(".avi");
            fop.FileTypeFilter.Add(".wmv");
            fop.SuggestedStartLocation = PickerLocationId.VideosLibrary;
            fop.ViewMode = PickerViewMode.Thumbnail;
            var f = await fop.PickSingleFileAsync();
            //Chon file de luu
            FileSavePicker fsp = new FileSavePicker();
            fsp.DefaultFileExtension = ".avi";
            fsp.FileTypeChoices.Add(new KeyValuePair<string, IList<string>>("Videos", new List<string> { ".avi" }));
            fsp.SuggestedFileName = "MyMovieConverted.avi";
            fsp.SuggestedStartLocation = PickerLocationId.VideosLibrary;
            var f1 = await fsp.PickSaveFileAsync();
            
            //Convert file 
            Windows.UI.Popups.MessageDialog m;
            var trans = await mt.PrepareFileTranscodeAsync(f, f1, mep);
            if (trans.CanTranscode)
            {
                await trans.TranscodeAsync();
                m = new Windows.UI.Popups.MessageDialog("Convert thanh cong!");
                m.ShowAsync();
            }
            else
            {
                m = new Windows.UI.Popups.MessageDialog("Khong the convert!");
                m.ShowAsync();
            }
            
        }

        private async void MenuFlyoutItem_Click_1(object sender, RoutedEventArgs e)
        {
            MediaTranscoder mt = new MediaTranscoder();
            MediaEncodingProfile mep = MediaEncodingProfile.CreateAvi(VideoEncodingQuality.HD1080p);
            //Chon file de convert
            FileOpenPicker fop = new FileOpenPicker();
            fop.FileTypeFilter.Add(".mp4");
            fop.FileTypeFilter.Add(".avi");
            fop.FileTypeFilter.Add(".wmv");
            fop.SuggestedStartLocation = PickerLocationId.VideosLibrary;
            fop.ViewMode = PickerViewMode.Thumbnail;
            var f = await fop.PickSingleFileAsync();
            //Chon file de luu
            FileSavePicker fsp = new FileSavePicker();
            fsp.DefaultFileExtension = ".avi";
            fsp.FileTypeChoices.Add(new KeyValuePair<string, IList<string>>("Videos", new List<string> { ".avi" }));
            fsp.SuggestedFileName = "MyMovieConverted.avi";
            fsp.SuggestedStartLocation = PickerLocationId.VideosLibrary;
            var f1 = await fsp.PickSaveFileAsync();

            //Convert file 
            Windows.UI.Popups.MessageDialog m;
            var trans = await mt.PrepareFileTranscodeAsync(f, f1, mep);
            if (trans.CanTranscode)
            {
                await trans.TranscodeAsync();
                m = new Windows.UI.Popups.MessageDialog("Convert thanh cong!");
                m.ShowAsync();
            }
            else
            {
                m = new Windows.UI.Popups.MessageDialog("Khong the convert!");
                m.ShowAsync();
            }
            
        }
    }
}
