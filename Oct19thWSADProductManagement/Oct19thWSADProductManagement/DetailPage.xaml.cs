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

namespace Oct19thWSADProductManagement
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailPage : Page
    {
        List<Product> listProduct;
        public DetailPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            listProduct = e.Parameter as List<Product>;
            base.OnNavigatedTo(e);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Product p = new Product();
            int ID = 0;
            int.TryParse(txtID.Text, out ID);
            p.Id = ID;
            p.Name = txtName.Text;
            int Price = 0;
            int.TryParse(txtPrice.Text, out Price);
            p.Price = Price;
            p.Category = txtCategory.Text;
            p.Image = currentImage;
            listProduct.Add(p);
            txtCategory.Text = "";
            txtID.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            currentImage = "";
            imgProductImage.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("ms-appx:///Assets/empty-img.png"));
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog("Them moi thanh cong!");
            m.ShowAsync();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), listProduct);
        }
        string currentImage = "";
        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fop = new FileOpenPicker();
            fop.FileTypeFilter.Add(".jpg");
            fop.FileTypeFilter.Add(".png");
            fop.FileTypeFilter.Add(".bmp");
            fop.FileTypeFilter.Add(".gif");

            fop.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            fop.ViewMode = PickerViewMode.Thumbnail;

            var f = await fop.PickSingleFileAsync();

            Windows.UI.Xaml.Media.Imaging.BitmapImage bi = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
            bi.SetSource(await f.OpenAsync(FileAccessMode.Read));
            imgProductImage.Source = bi;
            currentImage = f.Path + f.Name;
            //imgProductImage.Source = new Image().r I f.Path + f.Name;
        }
    }
}
