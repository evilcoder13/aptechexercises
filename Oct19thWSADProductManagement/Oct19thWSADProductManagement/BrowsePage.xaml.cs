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

namespace Oct19thWSADProductManagement
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BrowsePage : Page
    {
        public BrowsePage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(e.Parameter.GetType()==typeof(Product))
            {
                Product p = e.Parameter as Product;
                this.DataContext = p;
                //if(!p.Image.StartsWith("Assets/") && !p.Image.StartsWith("ms-appx://") && !p.Image.StartsWith("roaming://"))
                //{ 
                //    Windows.UI.Xaml.Media.Imaging.BitmapImage bi = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                //    var f = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(new Uri(p.Image));
                //    bi.SetSource(await f.OpenAsync(Windows.Storage.FileAccessMode.Read));
                //    imgProductImage.Source = bi;
                //}
                btnDelete.IsEnabled = false;
                btnNext.IsEnabled = false;
                btnPrevious.IsEnabled = false;
            }
            else {
                pList = e.Parameter as List<Product>;
                BindDataByIndex();
            }
            base.OnNavigatedTo(e);
        }
        List<Product> pList;
        int index = 0;
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            if (pList != null)
                Frame.Navigate(typeof(MainPage), pList);
            else
                Frame.GoBack();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            index = index - 1;
            BindDataByIndex();
            
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            index = index + 1;
            BindDataByIndex();
        }

        async void BindDataByIndex()
        {
            this.DataContext = pList[index];
            //Windows.UI.Xaml.Media.Imaging.BitmapImage bi = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
            //var f = await Windows.Storage.StorageFile.GetFileFromPathAsync(pList[index].Image);
            //bi.SetSource(await f.OpenAsync(Windows.Storage.FileAccessMode.Read));
            //imgProductImage.Source = bi; 
            if (index == 0)
            {
                btnPrevious.IsEnabled = false;
                btnNext.IsEnabled = true;
            }
            else
                btnPrevious.IsEnabled = true;
            if (index == pList.Count - 1)
            {
                btnPrevious.IsEnabled = true;
                btnNext.IsEnabled = false;
            }
            else
                btnNext.IsEnabled = true;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            pList.RemoveAt(index);
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog("Delete Success!");
            m.ShowAsync();
        }
    }
}
