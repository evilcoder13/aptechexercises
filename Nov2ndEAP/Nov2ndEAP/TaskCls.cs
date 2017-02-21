using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Nov2ndEAP
{
    public class TaskCls
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(500, MinimumLength=1)]
        public string Name { get; set; }
        public DateTime EndTime { get; set; }
        public int GroupId { get; set; }
        public string RemainTime { get {
            if (EndTime == null)
                return "No data!";
            TimeSpan ts ;
            if (EndTime > DateTime.Now)
            {
                ts = EndTime.Subtract(DateTime.Now);
                return string.Format("{0:00}:{1:00}:{2:00}", ts.TotalHours, ts.Minutes, ts.Seconds);
            }
            else
            { 
                ts = DateTime.Now.Subtract(EndTime);
                return string.Format("-{0:00}:{1:00}:{2:00}", ts.TotalHours, ts.Minutes, ts.Seconds);
            }
            
        } }
        [ForeignKey("GroupId")]
        public virtual TaskGroup TG { get; set; }
    }
}
