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
using Newtonsoft.Json;
using Windows.Storage;
using Windows.Storage.Pickers;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Oct17thWSADEmployeeManagement
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EmployeeList : Page
    {
        List<Employee> ListEmployee = new List<Employee>() { 
            new Employee() { Id=1, Name="Thang", DOB=new DateTime(1986,10,10), Department="HR"},
            new Employee() { Id=2, Name="Thanh", DOB=new DateTime(1987,10,10), Department="Code"},
            new Employee() { Id=3, Name="Huy", DOB=new DateTime(1988,10,10), Department="Design"},
            new Employee() { Id=4, Name="Hai", DOB=new DateTime(1989,10,10), Department="Design"},
            new Employee() { Id=5, Name="Toan", DOB=new DateTime(1990,10,10), Department="Code"},
            new Employee() { Id=6, Name="Vien", DOB=new DateTime(1991,10,10), Department="HR"}
        }; 
        public EmployeeList()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lstEmployee.DataContext = ListEmployee;
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void sbSearch_QuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            lstEmployee.DataContext = ListEmployee.Where(e => e.Name.Contains(sbSearch.QueryText)).ToList();
        }

        private void cbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbDepartment.SelectedIndex < 0)
                return;

            var cbi = cbDepartment.SelectedItem as ComboBoxItem;
            string s = cbi.Content.ToString();
            List<Employee> list;
            switch(s)
            {
                case "HR":
                    list = ListEmployee.Where(e1 => e1.Department == "HR").ToList();
                    break;
                case "Code":
                    list = ListEmployee.Where(e1 => e1.Department == "Code").ToList();
                    break;
                case "Design":
                    list = ListEmployee.Where(e1 => e1.Department == "Design").ToList();
                    break;
                default:
                    list = ListEmployee;
                    break;
            }
            lstEmployee.DataContext = list;
        }

        private void lstEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Frame.Navigate(typeof(EmployeeDetail), lstEmployee.SelectedItem as Employee);
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            FileSavePicker fsp = new FileSavePicker();
            fsp.DefaultFileExtension = ".json";
            fsp.FileTypeChoices.Add(new KeyValuePair<string,IList<string>>("Data File", new List<string>{ ".json", ".db" }));
            fsp.SuggestedFileName = "database.json";
            fsp.SuggestedStartLocation = PickerLocationId.Desktop;
            var f = await fsp.PickSaveFileAsync();

            await FileIO.WriteTextAsync(f, JsonConvert.SerializeObject(ListEmployee));
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog("Da luu thanh cong!");
            m.ShowAsync();
        }

        private async void Open_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fop = new FileOpenPicker();
            fop.FileTypeFilter.Add(".json");
            fop.FileTypeFilter.Add(".db");
            fop.SuggestedStartLocation = PickerLocationId.Desktop;
            fop.ViewMode = PickerViewMode.List;
            var f = await fop.PickSingleFileAsync();

            ListEmployee = (List<Employee>)JsonConvert.DeserializeObject<List<Employee>>(await FileIO.ReadTextAsync(f));
            lstEmployee.DataContext = ListEmployee.ToList();
            //ListEmployee = (List<Employee>)JsonConvert.DeserializeObject<List<Employee>>(await FileIO.ReadTextAsync(f));
            //ListEmployee = (List<Employee>)listMoi.Cast<Employee>();
            //lstEmployee.DataContext = ListEmployee.ToList();
        }

        private void lstEmployee_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (lstEmployee.SelectedIndex < 0)
                return;

            Employee e1 = lstEmployee.SelectedItem as Employee;
            ListEmployee.Remove(e1);

            lstEmployee.DataContext = ListEmployee.ToList();
        }
    }
}
