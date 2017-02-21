using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Nov04thEAPChat
{
    public class ChatDBContext : DbContext
    {
        public ChatDBContext()
            : base()
        {
            base.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<TextMessage> TextMessages { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer(new ChatDBInit());
        }
    }
}