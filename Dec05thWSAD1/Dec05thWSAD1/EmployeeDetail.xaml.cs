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
    public sealed partial class EmployeeDetail : Page
    {
        public EmployeeDetail()
        {
            this.InitializeComponent();
        }

        private void GoHome_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Employee emp = e.Parameter as Employee;
            this.DataContext = emp;

            tbEmployee.Text = string.Format("ID: {0}{1}Name: {2}{1}DOB: {3}{1}Deparment: {4}{1}", emp.Id, Environment.NewLine, emp.Name, emp.DOB, emp.Department);
            base.OnNavigatedTo(e);
        }
    }
}
