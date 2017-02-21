using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Entity;
namespace Nov2ndEAPWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        TaskContext db = new TaskContext();
        public List<TaskGroup> LayDuLieuTaskGroup()
        {
            return db.TaskGroups.ToList();
        }

        public List<TaskCls> LayDuLieuTaskCls()
        {
            return db.TaskClss.ToList();
        }

        public List<TaskCls> TimKiemTaskCls(string search)
        {
            return db.TaskClss.Include(t => t.TG).Where(t => t.Name.Contains(search) || t.TG.Name.Contains(search)).ToList();
        }

        public void InsertTaskCls(TaskCls tc)
        {
            db.TaskClss.Add(tc);
            db.SaveChanges();
        }
    }
}
