using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Nov2ndEAPWCF
{
    public class TaskInit : DropCreateDatabaseIfModelChanges<TaskContext>
    {
        protected override void Seed(TaskContext context)
        {
            context.TaskGroups.AddRange(new List<TaskGroup>() {
                new TaskGroup() { Id=1, Name="Giải trí"},
                new TaskGroup() { Id=2, Name="Học tập"},
                new TaskGroup() { Id=3, Name="Làm việc"},
                new TaskGroup() { Id=4, Name="Khác"}
                });

            context.TaskClss.Add(new TaskCls() { Id = 1, Name = "Giải trí 1", EndTime = DateTime.Now.AddMinutes(5), GroupId = 1 });
            context.TaskClss.Add(new TaskCls() { Id = 2, Name = "Giải trí 2", EndTime = DateTime.Now.AddMinutes(15), GroupId = 1 });
            context.TaskClss.Add(new TaskCls() { Id = 3, Name = "Giải trí 3", EndTime = DateTime.Now.AddMinutes(25), GroupId = 1 });

            context.TaskClss.Add(new TaskCls() { Id = 4, Name = "Học tập 1", EndTime = DateTime.Now.AddMinutes(51), GroupId = 2 });
            context.TaskClss.Add(new TaskCls() { Id = 5, Name = "Học tập 2", EndTime = DateTime.Now.AddMinutes(52), GroupId = 2 });

            context.TaskClss.Add(new TaskCls() { Id = 6, Name = "Làm việc 1", EndTime = DateTime.Now.AddMinutes(50), GroupId = 3 });

            context.TaskClss.Add(new TaskCls() { Id = 7, Name = "Khác 1", EndTime = DateTime.Now.AddMinutes(35), GroupId = 4 });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}