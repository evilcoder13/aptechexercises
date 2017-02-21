using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WcfChatService1
{
    public class ChatDBContext:DbContext
    {
        public ChatDBContext():base()
        {
            base.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<TextMessage> TextMessages { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer(new ChatDBInit());
        }
    }
}