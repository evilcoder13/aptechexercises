using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.ApplicationModel.Background;
using Windows.Storage;

namespace Utilities
{
    public sealed class MyBackgroundTask : IBackgroundTask
    {
        /// <summary>
        /// Hàm mặc định để chạy background task khi được gọi
        /// </summary>
        /// <param name="taskInstance"></param>
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();
            //UpdateStatusAndTime();
            
            UpdateNewsInformation();
            deferral.Complete();
        }
        List<News> list = new List<News>();
        List<string> linkList = new List<string>();
        StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        DateTime maxPubDate = DateTime.Now.AddYears(-1);
         async void UpdateNewsInformation()
        {
            try
            {
                //Lấy thời điểm tin cuối cùng của lần lấy trước.
                maxPubDate = DateTime.Parse(await FileIO.ReadTextAsync(await localFolder.GetFileAsync("maxPubDate.txt")));
            }
            catch
            {
                //Nếu không có, coi như tin cuối cùng lấy cách đó 1 năm. (ít xảy ra)
                maxPubDate = DateTime.Now.AddYears(-1);
            }
             //Đoạn tiếp theo là load danh sách link RSS từ file và đọc danh sách tin từ danh sách link RSS
            try
            {
                linkList = JsonConvert.DeserializeObject<List<string>>(await FileIO.ReadTextAsync(await localFolder.GetFileAsync("Links.txt")));
            }
            catch { }
            if (linkList == null || linkList.Count <= 0)
            {
                linkList = new List<string>();
                linkList.Add("http://vnexpress.net/rss/tin-moi-nhat.rss");
            }

            list = new List<News>();
            foreach (string u in linkList)
                LoadData(u);
            list = list.OrderByDescending(l => l.pubDate).ToList(); // sắp xếp tin theo thời gian
             //Kiểm tra tin mới và update badge / toast liên quan đến tin mới
            if (list.Any(l => DateTime.Parse(l.pubDate) > maxPubDate))
            {
                List<News> list1 = list.Where(l => DateTime.Parse(l.pubDate) > maxPubDate).OrderByDescending(l => l.pubDate).ToList();
                Utilities.NotificationUtil.BadgeNotification(list1.Count.ToString());
                Utilities.NotificationUtil.ToastNotification(list1[0].title);
            }
            maxPubDate = list.Max(l => DateTime.Parse(l.pubDate));
            await FileIO.WriteTextAsync(await localFolder.CreateFileAsync("maxPubDate.txt", CreationCollisionOption.ReplaceExisting), maxPubDate.ToString());
        }
        /// <summary>
        /// Đọc tin từ link RSS vào list.
        /// </summary>
        /// <param name="url"></param>
        void LoadData(string url)
        {
            HttpClient client = new HttpClient();
            var xmldoc = client.GetStringAsync(url).Result;
            var x = XDocument.Parse(xmldoc);
            var d = x.Descendants(XName.Get("channel")).Single();
            var jsonString = JsonConvert.SerializeXNode(d);
            //JToken json = (JToken)JsonConvert.DeserializeObject(jsonString);
            JObject j = JObject.Parse(jsonString);
            IList<JToken> results = j["channel"]["item"].Children().ToList();
            foreach (var r in results)
            {
                News n = JsonConvert.DeserializeObject<News>(r.ToString());
                if (!list.Any(ne => ne.link == n.link))
                    list.Add(n);
            }
            //lstNews.DataContext = list;
        }
    }
}
