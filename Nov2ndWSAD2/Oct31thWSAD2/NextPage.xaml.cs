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

namespace Nov2ndWSAD2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NextPage : Page
    {
        int index = 0;
        string action = "";
        string message = "";
        string fileName = "";
        List<Contact> list = new List<Contact>()
        {
            new Contact() { Phone="0123456789", Name="Thang", Address="Dia chi cua Thang", Email="Thang@mail.com", Image="ms-appx:///Assets/profiles/profile-bill-gates.jpg"},
            new Contact() { Phone="1234567890", Name="Toan", Address="Dia chi cua Toan", Email="Toan@mail.com", Image="ms-appx:///Assets/profiles/profile-binh.jpg"},
            new Contact() { Phone="2345678901", Name="Huy", Address="Dia chi cua Huy", Email="Huy@mail.com", Image="ms-appx:///Assets/profiles/profile-larry-ellison.jpg"},
            new Contact() { Phone="3546789012", Name="Phuong", Address="Dia chi cua Phuong", Email="Phuong@mail.com", Image="ms-appx:///Assets/profiles/profile-quang.jpg"},
            new Contact() { Phone="4567890123", Name="Van", Address="Dia chi cua Van", Email="Van@mail.com", Image="ms-appx:///Assets/profiles/profile-steve-jobs.jpg"}
        };
        Windows.Storage.StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
        Windows.Storage.CreationCollisionOption option = Windows.Storage.CreationCollisionOption.ReplaceExisting;

        void loadData()
        {
            //xnImage.Source = null;
            if (index < 0)
                return;
                this.DataContext = list[index];
                xnFirst.IsEnabled = !(index==0);
                xnPrevious.IsEnabled = !(index==0);
                xnLast.IsEnabled = !(index == list.Count - 1);
                xnNext.IsEnabled = !(index == list.Count - 1);
                enableForm(false);
        }
        void enableForm(bool on)
        {
            xnName.IsEnabled = on;
            xnPhone.IsEnabled = on;
            xnAddress.IsEnabled = on;
            xnEmail.IsEnabled = on;
            xnBrowse.IsEnabled = on;
            fileName = "";
        }
        void enableSave(bool on)
        {

        }
        void enableNavigationButtons()
        {

        }
        void disableNavigationButtons()
        {

        }
        void validate()
        {
            /*
             *  Roll Number length must be greater than zero.
             *  Student name length must be greater than zero.
             *  Email must match the pattern: @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}"
             *
             */
        }
        public NextPage()
        {
            this.InitializeComponent();
            loadData();
        }

        private async void OnClick_BrowsePhotos(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fop = new FileOpenPicker();
            fop.FileTypeFilter.Add(".jpg");
            fop.FileTypeFilter.Add(".bmp");
            fop.FileTypeFilter.Add(".gif");
            fop.FileTypeFilter.Add(".png");
            fop.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            fop.ViewMode = PickerViewMode.Thumbnail;
            var f = await fop.PickSingleFileAsync();
            
            string newFileName = Guid.NewGuid().ToString() + f.Name;
            await f.CopyAsync(folder, newFileName);
            //xnImage.DataContext = "ms-appdata:///local/"+ newFileName;
            //Windows.UI.Xaml.Media.Imaging.BitmapImage bi = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("ms-appdata:///local/" + newFileName));
            //xnImage.Source = bi;
            fileName = newFileName;
            list[index].Image = "ms-appdata:///local/" + newFileName;
            loadData();
        }

        private void OnClick_Logout(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void OnClick_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void OnClick_Add(object sender, RoutedEventArgs e)
        {
            list.Add(new Contact());
            index = list.Count - 1;
            loadData();
            enableForm(true);
        }

        private void OnClick_Edit(object sender, RoutedEventArgs e)
        {
            enableForm(true);
        }

        private void OnClick_Delete(object sender, RoutedEventArgs e)
        {
            if (index < 0)
                return;
            list.RemoveAt(index);
            if (index >= list.Count - 1)
                index--;
            if(index>=0)
                loadData();
            popup("Delete success!");
        }

        //private void OnClick_Save(object sender, RoutedEventArgs e)
        //{
        //    Contact s;
        //    if(action=="Add")
        //    {
        //        s = new Contact();
        //        list.Add(s);
        //    }
        //    else
        //    {
        //        s = list[index];
        //    }
            
        //    s.Name = xnName.Text;
        //    s.RollNumber = xnRollNumber.Text;
        //    try
        //    {
        //        s.Age = int.Parse(xnAge.Text);
        //    }
        //    catch
        //    {
        //        popup("Age must be number!");
        //        return;
        //    }
        //    s.Email = xnEmail.Text;
        //    s.Image = "ms-appdata:///local/"+ fileName;
        //    popup("Saved success!");
        //}

        //private void OnClick_Cancel(object sender, RoutedEventArgs e)
        //{
        //    loadData();
        //}

        private async void OnClick_OpenFile(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fop = new FileOpenPicker();
            fop.FileTypeFilter.Add(".json");
            fop.FileTypeFilter.Add(".db");
            fop.SuggestedStartLocation = PickerLocationId.Desktop;
            fop.ViewMode = PickerViewMode.List;
            var f = await fop.PickSingleFileAsync();
            list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Contact>>(await FileIO.ReadTextAsync(f));
            if(list.Count>0)
            {
                index = 0;
                loadData();
            }
        }

        private void OnClick_First(object sender, RoutedEventArgs e)
        {
            index = 0;
            loadData();
        }

        private void OnClick_Previous(object sender, RoutedEventArgs e)
        {
            index--;
            loadData();
        }

        private void OnClick_Next(object sender, RoutedEventArgs e)
        {
            index++;
            loadData();
        }

        private void OnClick_Last(object sender, RoutedEventArgs e)
        {
            index = list.Count - 1;
            loadData();
        }

        private async void OnClick_SaveFile(object sender, RoutedEventArgs e)
        {
            FileSavePicker fsp = new FileSavePicker();
            fsp.DefaultFileExtension = ".json";
            fsp.FileTypeChoices.Add(new KeyValuePair<string,IList<string>>("Data file", new List<string>(){ ".json",".db" }));
            fsp.SuggestedFileName = "Data.json";
            fsp.SuggestedStartLocation = PickerLocationId.Desktop;
            var f = await fsp.PickSaveFileAsync();

            await FileIO.WriteTextAsync(f,Newtonsoft.Json.JsonConvert.SerializeObject(list));
            popup("Saved success!");
        }

        void popup(string message)
        {
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog(message);
            m.ShowAsync();
        }

        private void OnClick_Clear(object sender, RoutedEventArgs e)
        {

        }
    }
}
