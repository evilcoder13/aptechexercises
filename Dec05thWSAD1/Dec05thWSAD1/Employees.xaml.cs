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

namespace Dec05thWSAD1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Employees : Page
    {
        List<Employee> ListEmployee = new List<Employee>() { 
            new Employee(){ Id=1, Name="Nguyen Van A", DOB=new DateTime(1980,1,1), Department="Code"},
            new Employee(){ Id=2, Name="Trinh Thi B", DOB=new DateTime(1981,1,1), Department="Design"},
            new Employee(){ Id=3, Name="Tran Van C", DOB=new DateTime(1982,1,1), Department="HR"},
            new Employee(){ Id=4, Name="Pham Thi D", DOB=new DateTime(1983,1,1), Department="Code"},
            new Employee(){ Id=5, Name="Do Van E", DOB=new DateTime(1984,1,1), Department="Design"},
            new Employee(){ Id=6, Name="Hoang Thi F", DOB=new DateTime(1985,1,1), Department="HR"}
        };
        public Employees()
        {
            this.InitializeComponent();
            lstEmployee.DataContext = ListEmployee;
            cbSearchDepartment.DataContext = ListEmployee.Select(f => f.Department).Distinct();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void Search_Submit(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            lstEmployee.DataContext = ListEmployee.Where(e => e.Name.Contains(sender.QueryText)).ToList();
        }

        private void ChangeDepartment_Click(object sender, SelectionChangedEventArgs e)
        {
            if(cbSearchDepartment.SelectedIndex<=0)
            {
                lstEmployee.DataContext = ListEmployee;
            }
            else
            {
                lstEmployee.DataContext = ListEmployee.Where(f => f.Department.Equals(cbSearchDepartment.SelectedValue)).ToList();
            }
        }

        private void Employee_Detail(object sender, SelectionChangedEventArgs e)
        {
            Frame.Navigate(typeof(EmployeeDetail), lstEmployee.SelectedItem);
        }
    }
}
