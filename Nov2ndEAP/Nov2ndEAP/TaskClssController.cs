using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;
namespace Nov2ndEAP
{
    public class TaskClssController:ApiController
    {
        TaskContext db = new TaskContext();
        public List<TaskCls> Get()
        {
            return db.TaskClss.ToList();
        }

        public List<TaskCls> Get(string id)
        {
            return db.TaskClss.Include(t=>t.TG).Where(t=>t.Name.Contains(id)||t.TG.Name.Contains(id)).ToList();
        }
    }
}
