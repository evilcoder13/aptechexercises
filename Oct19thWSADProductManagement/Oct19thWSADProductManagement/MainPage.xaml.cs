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
    public sealed partial class MainPage : Page
    {
        List<Product> listProduct = new List<Product>()
        {
            new Product() { Id=1, Name="Pen", Image="Assets/Pen.jpg", Price=10000, Category="Office"},
            new Product() { Id=2, Name="Laptop 1", Image="Assets/Laptop1.jpg", Price=10000000, Category="Office"},
            new Product() { Id=3, Name="Laptop 2", Image="Assets/Laptop2.jpg", Price=8000000, Category="Laptop"},
            new Product() { Id=4, Name="Laptop 3", Image="Assets/Laptop3.jpg", Price=9000000, Category="Laptop"},
            new Product() { Id=5, Name="Laptop 4", Image="Assets/Laptop4.jpg", Price=12000000, Category="Business"},
            new Product() { Id=6, Name="Laptop 5", Image="Assets/Laptop5.jpg", Price=15000000, Category="Business"}
        };
        public MainPage()
        {
            this.InitializeComponent();
            lstProduct.DataContext = listProduct;
            var listCate = (from p in listProduct group p by p.Category into g select g.Key).ToList();
            cbSearchCategory.DataContext = listCate;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void SearchBox_QuerySubmit(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            lstProduct.DataContext = listProduct.Where(p => p.Name.Contains(sbSearchName.QueryText)).ToList();
        }

        private void SearchCate_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (cbSearchCategory.SelectedIndex < 0)
                return;

            lstProduct.DataContext = listProduct.Where(p => p.Category.Equals(cbSearchCategory.SelectedValue.ToString())).ToList();
        }

        private void lstProduct_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(BrowsePage), lstProduct.SelectedItem as Product);
        }

        private void AddPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DetailPage),listProduct);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Kiem tra neu khong co du lieu truyen ve
            if (e.Parameter == null || e.Parameter.ToString()=="")
            {
                base.OnNavigatedTo(e);
                return;
            }
            else
            { 
                listProduct = e.Parameter as List<Product>;
                lstProduct.DataContext = listProduct;
                base.OnNavigatedTo(e);
            }
        }

        private void BrowsePage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BrowsePage), listProduct);
        }
    }
}
