using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nov28thAWSAD1SimpleNote
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public DateTime? ExpireTime { get; set; }
        public string Category { get; set; }
        public bool Done { get; set; }
        public string RemainTime
        {
            get
            {
                if (ExpireTime != null)
                {
                    TimeSpan t;
                    if (ExpireTime > DateTime.Now)
                    {
                        t = ((DateTime)ExpireTime).Subtract(DateTime.Now);
                        return string.Format("{0:00}:{1:00}:{2:00}", t.TotalHours, t.Minutes, t.Seconds);
                    }
                    else
                    {
                        t = DateTime.Now.Subtract((DateTime)ExpireTime);
                        return string.Format("-{0:00}:{1:00}:{2:00}", t.TotalHours, t.Minutes, t.Seconds);
                    }
                }
                else
                    return "Infinity";
            }
        }
        public string UserName { get; set; }
    }
}
