using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using Windows.Data.Xml.Dom;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Windows.Storage;
using Windows.ApplicationModel.Background;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Dec09thAWSAD2RSSReader
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //Load dữ liệu danh sách các link RSS
            LoadDataFile();
            //Từ danh sách link, đọc ra các tin có trong đó
            RefreshData();
            
        }
        DateTime maxPubDate = DateTime.Now.AddYears(-1);
        /// <summary>
        /// Từ danh sách link, đọc ra các tin có trong đó
        /// </summary>
        void RefreshData()
        {
            list = new List<News>();
            //Chạy lần lượt danh sách link RSS để đọc ra các tin trong đó
            foreach (string u in linkList)
                LoadData(u); //Load dữ liệu trong từng link, đưa vào biến list
            //Sắp xếp dữ liệu theo thời gian, tin mới lên trước, tin cũ xuống dưới
            list = list.OrderByDescending(l => l.pubDate).ToList();
            //Kiểm tra xem có tin nào mới kể từ lần lấy dữ liệu trước hay không
            if (list.Any(l => l.pubDate > maxPubDate))
            {
                //Nếu có, lấy ra danh sách tin mới
                List<News> list1 = list.Where(l => l.pubDate > maxPubDate).OrderByDescending(l=>l.pubDate).ToList();
                //Hiển thị danh sách số lượngt in mới vào badge
                Utilities.NotificationUtil.BadgeNotification(list1.Count.ToString());
                //Hiển thị tin mới nhất lên toast
                Utilities.NotificationUtil.ToastNotification(list1[0].title);
            }
            //Lấy ra thời gian của tin mới nhất để lần sau kiểm tra tin mới
            maxPubDate = list.Max(l => l.pubDate);
            //Bind danh sách tin vào listbox
            lstNews.DataContext = list;
        }

        List<News> list = new List<News>();
        List<string> linkList = new List<string>();
        /// <summary>
        /// Đọc dữ liệu từ URL của RSS vào list<News>
        /// </summary>
        /// <param name="url"></param>
        void LoadData(string url)
        {
            //Dùng HttpClient để tạo kết nối HTTP đến RSS
            HttpClient client = new HttpClient();
            var xmldoc = client.GetStringAsync(url).Result;
            //Đọc dữ liệu RSS vào dưới dạng xml
            var x = XDocument.Parse(xmldoc);
            //Lấy phần XML từ phần Channel
            var d = x.Descendants(XName.Get("channel")).Single();
            //Chuyển toàn bộ phần XML từ channel lấy được ở bước trên sang json
            var jsonString = JsonConvert.SerializeXNode(d);
            JObject j = JObject.Parse(jsonString);
            //Duyệt json lấy ra các mục item -> đưa vào list
            IList<JToken> results = j["channel"]["item"].Children().ToList();
            //Chạy từng mục item để lấy dữ liệu ra kiểu News
            foreach (var r in results)
            {
                //Chuyển từ jSON sang kiểu News
                News n = JsonConvert.DeserializeObject<News>(r.ToString());
                //Nếu dữ liệu đã tồn tại trong list, bỏ qua, nếu chưa sẽ add tiếp vào list để tránh trùng tin
                if(!list.Any(ne=>ne.link==n.link))
                    list.Add(n);
            }
            //lstNews.DataContext = list;
        }
        StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        /// <summary>
        /// Lưu danh sách các link RSS ra file
        /// </summary>
        void SaveDataFile()
        {
            //Lưu danh sách linkList là các link RSS ra file Links.txt trong localfolder
            FileIO.WriteTextAsync(localFolder.CreateFileAsync("Links.txt", CreationCollisionOption.ReplaceExisting).GetResults(), JsonConvert.SerializeObject(linkList));
        }
        /// <summary>
        /// Lấy danh sách link RSS từ file
        /// </summary>
        void LoadDataFile()
        {
            //Đọc file Links.txt trong localfolder để lấy ra danh sách các link RSS hiện có.
            try
            {
                linkList = JsonConvert.DeserializeObject<List<string>>(FileIO.ReadTextAsync(localFolder.GetFileAsync("Links.txt").GetResults()).GetResults());
            }
            catch { }
            //Trong trường hợp không có link RSS nào, cho 1 link mặc định để test
            if (linkList == null || linkList.Count <= 0)
            { 
                linkList = new List<string>();
                linkList.Add("http://vnexpress.net/rss/tin-moi-nhat.rss");
            }
            //Bind dữ liệu và combobox
            cbLinks.DataContext = linkList;
        }
        /// <summary>
        /// Khi bấm nút add link, add link hiện tại trên textbox vào list và combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddLink_Click(object sender, RoutedEventArgs e)
        {
            if (Uri.IsWellFormedUriString(txtUrl.Text, UriKind.RelativeOrAbsolute) && !linkList.Any(l=>l.Equals(txtUrl.Text)))
                linkList.Add(txtUrl.Text);
            cbLinks.DataContext = linkList.ToList();
            SaveDataFile();
            ThongBao("Link added successfully!");
        }
        /// <summary>
        /// Dùng để hiện thông báo dưới dạng popup
        /// </summary>
        /// <param name="message">Nội dung của popup</param>
        void ThongBao(string message)
        {
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog(message);
            m.ShowAsync();
        }
        /// <summary>
        /// Chọn link cần xoá từ combobox và xoá khi bấm nút delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteLink_Click(object sender, RoutedEventArgs e)
        {
            if(cbLinks.SelectedItem!=null)
            {
                linkList.Remove(cbLinks.SelectedItem.ToString());
                cbLinks.DataContext = linkList.ToList();
                SaveDataFile();
                ThongBao("Link removed!");
            }
        }
        /// <summary>
        /// Khi nháy đúp vào một tin bất kỳ, mở tin đó lên bằng trình duyệt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstNews_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (lstNews.SelectedIndex >= 0)
                Windows.System.Launcher.LaunchUriAsync(new Uri((lstNews.SelectedItem as News).link));
        }
        /// <summary>
        /// Khi bấm nút refresh, load lại dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }
        /// <summary>
        /// Khi bấm nút register, đăng ký background task mới với tên UpdateNews15Mins vào hệ thống
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            //Background Tasks
            RegisterBackgroundTask("UpdateNews15Mins");
        }
        /// <summary>
        /// Đăng ký backgroundtask với hệ thống
        /// </summary>
        /// <param name="n">Tên của background task</param>
        private void RegisterBackgroundTask(string n)
        {
            bool registered = false; // Biến kiểm tra xem background task đã từng được đăng ký hay chưa.
            //Chạy lặp từng background task của hệ thống.
            foreach (var task in BackgroundTaskRegistration.AllTasks)
            {
                //Nếu đã có background task có tên như tên được yêu cầu đăng ký
                if (task.Value.Name == n)
                {
                    //Hiện thông tin là đã đăng ký và set lại biến.
                    Utilities.NotificationUtil.ToastNotification("Background task has already been registered!");
                    registered = true;
                }
            }
            //Nếu biến không được set, nghĩa là chưa có background task với tên được yêu cầu thì đăng ký một background task mới
            if (!registered)
            {
                BackgroundTaskBuilder b = new BackgroundTaskBuilder(); // Tạo background task
                b.Name = n; // Đăng ký tên
                b.TaskEntryPoint = "Utilities.MyBackgroundTask"; // Đăng ký class gọi đến
                b.SetTrigger(new TimeTrigger(15, false)); // Đăng ký task dạng Timer, thời gian chạy mỗi 15 phút và không dừng sau lần chạy đầu tiên.
                BackgroundTaskRegistration t = b.Register(); // Đăng ký background task với hệ thống.
                Utilities.NotificationUtil.ToastNotification("New background task registered!"); // Thông báo đã đăng ký được
            }
            
            //Thongbao("Task Registered!");
        } 
    }
}
