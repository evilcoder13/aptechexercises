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

namespace Nov28thAWSAD1SimpleNote
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NotePage : Page
    {
        List<Note> list = new List<Note>(){
            new Note(){ Id=1, Title="Note 1", Done=false, Detail="Detail of note 1", Category="Personal", ExpireTime=DateTime.Now.AddMinutes(1), UserName="admin" },
            new Note(){ Id=1, Title="Note 2", Done=false, Detail="Detail of note 2", Category="Personal", ExpireTime=DateTime.Now.AddMinutes(3), UserName="admin" },
            new Note(){ Id=1, Title="Note 3", Done=false, Detail="Detail of note 3", Category="Personal", ExpireTime=DateTime.Now.AddMinutes(5), UserName="admin" },
            new Note(){ Id=1, Title="Note 4", Done=false, Detail="Detail of note 4", Category="Business", ExpireTime=DateTime.Now.AddMinutes(-1), UserName="admin" },
            new Note(){ Id=1, Title="Note 5", Done=false, Detail="Detail of note 5", Category="Business", ExpireTime=DateTime.Now.AddMinutes(-3), UserName="admin" },
            new Note(){ Id=1, Title="Note 6", Done=false, Detail="Detail of note 6", Category="Share", ExpireTime=DateTime.Now.AddMinutes(-5), UserName="admin" }
        };
        public NotePage()
        {
            this.InitializeComponent();
            lstTasks.DataContext = list.Where(n=>n.Done==false).OrderByDescending(n => n.ExpireTime);
            List<string> listCate = list.GroupBy(n => n.Category).Select(n => n.Key).ToList();
            listCate.Insert(0, "All");
            cbCategory.DataContext = listCate; 
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, object e)
        {
            if (filterCategory == "" || filterCategory=="All")
                lstTasks.DataContext = list.Where(n => n.Done == false).OrderByDescending(n => n.ExpireTime).ToList();
            else
                lstTasks.DataContext = list.Where(n => n.Done == false && n.Category.Equals(filterCategory)).OrderByDescending(n => n.ExpireTime).ToList();
        }
        DispatcherTimer timer = new DispatcherTimer();
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
        string filterCategory = "";
        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCategory.SelectedIndex >= 0)
                filterCategory = cbCategory.SelectedItem.ToString();

        }
    }
}
