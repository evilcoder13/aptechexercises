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

namespace Dec2ndWSAD1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NextPage : Page
    {
        public NextPage()
        {
            this.InitializeComponent();
        }

        private void OnClick_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void OnClick_Logout(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        BookList list = new BookList();
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book b = xnComboBox.SelectedItem as Book;
            this.DataContext = b;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            xnComboBox.DataContext = list;
            xnComboBox.DisplayMemberPath = "Title";
            xnComboBox.SelectedValuePath = "BookId";
            xnComboBox.SelectedIndex = 0;
            base.OnNavigatedTo(e);
        }
    }
}
