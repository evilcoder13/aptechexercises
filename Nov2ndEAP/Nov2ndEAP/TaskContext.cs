using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nov2ndEAP
{
    public class TaskContext:DbContext
    {
        public TaskContext():base()
        {
            base.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<TaskGroup> TaskGroups { get; set; }
        public DbSet<TaskCls> TaskClss { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer(new TaskInit());
        }
    }
}
