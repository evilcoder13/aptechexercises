using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dec09thAWSAD2RSSReader
{
    public class News
    {
        public string title { get; set; }
        public object description { get; set; }
        public DateTime pubDate { get; set; }
        public string link { get; set; }
        public string description1 { get {
            string s = description.ToString();
            if(s.Contains("cdata"))
            { 
            s = s.Substring(s.IndexOf(':')+3);
            s = Regex.Replace(s, "<.*?>", string.Empty);
            s = s.Substring(0, s.Length - 1);
            }
            return s;
        } }
    }
}
