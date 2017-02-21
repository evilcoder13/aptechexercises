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

namespace Dec07thWSAD1ProductManagement
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductPage : Page
    {
        public ProductPage()
        {
            this.InitializeComponent();
            if(list.Count>0)
            { 
                LoadData();
                LoadCategory();
            }
            else
            {
                btnNext.IsEnabled = false;
                btnPrevious.IsEnabled = false;
            }
        }
        void LoadCategory()
        {
            if(list.Count>0)
            {
                var d = list.Select(p => p.Category).Distinct().ToList();
                d.Insert(0, "");
                cbCategory.DataContext = d;
            }
        }
        void LoadData()
        {
            enableForm();
            this.DataContext = list[index];
            btnPrevious.IsEnabled = !(index == 0);
            btnNext.IsEnabled = !(index == list.Count - 1);
        }

        List<Product> list = new List<Product>();

        int index = 0;

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
        void ThongBao(string message)
        {
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog(message);
            m.ShowAsync();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Product p = new Product();
            p.Id = list.Max(a => a.Id) + 1;
            list.Add(p);
            index = list.Count - 1;
            LoadData();
            enableForm(true);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            enableForm(true);
        }

        void enableForm(bool check=false)
        {
            xnName.IsEnabled = check;
            xnPrice.IsEnabled = check;
            xnCategory.IsEnabled = check;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            list.RemoveAt(index);
            if (index > list.Count - 1)
                index--;
            if(list.Count==0)
            {
                ThongBao("Danh sach khong con phan tu nao!");
                index = 0;
                return;
            }
            LoadData();
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            index--;
            LoadData();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            index++;
            LoadData();
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            FileSavePicker fsp = new FileSavePicker();
            fsp.DefaultFileExtension = ".json";
            fsp.FileTypeChoices.Add(new KeyValuePair<string, IList<string>>("Database Files", new List<string>() { ".txt", ".json", ".db" }));
            fsp.SuggestedFileName = "Products" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".json";
            fsp.SuggestedStartLocation = PickerLocationId.Desktop;
            var f = await fsp.PickSaveFileAsync();

            await FileIO.WriteTextAsync(f, Newtonsoft.Json.JsonConvert.SerializeObject(list));
            ThongBao("Saved successfully!");
        }

        private async void Load_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fop = new FileOpenPicker();
            fop.FileTypeFilter.Add(".json");
            fop.FileTypeFilter.Add(".txt");
            fop.FileTypeFilter.Add(".db");
            fop.SuggestedStartLocation = PickerLocationId.Desktop;
            fop.ViewMode = PickerViewMode.List;
            var f = await fop.PickSingleFileAsync();
            list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(await FileIO.ReadTextAsync(f));
            if (list.Count > 0)
            {
                LoadData();
                LoadCategory();
            }
            ThongBao("Load successfully!");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
        List<Product> oriList = new List<Product>();
        bool Search = false;
        private void Search_Submitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            cbCategory.SelectedItem = "";
            if (!Search)
            {
                oriList = list;
                Search = true;
            }
            else
                if (string.IsNullOrEmpty(sender.QueryText))
                {
                    list = oriList;
                    Search = false;
                }
            list = oriList.Where(p => p.Name.Contains(sender.QueryText)).ToList();
            if(list.Count>0)
            { 
                index = 0;
                LoadData();
            }
        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sbSearch.QueryText = "";
            if (cbCategory.SelectedItem.ToString()!="" && !Search)
            {
                oriList = list;
                Search = true;
            }
            else
                if (string.IsNullOrEmpty(cbCategory.SelectedItem.ToString()))
                { 
                    list = oriList;
                    Search = false;
                }
            list = oriList.Where(p => p.Name.Contains(cbCategory.SelectedItem.ToString())).ToList();
            if (list.Count > 0)
            {
                index = 0;
                LoadData();
            }
        }
    }
}
