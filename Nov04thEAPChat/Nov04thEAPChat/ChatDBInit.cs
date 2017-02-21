using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Nov04thEAPChat
{
    public class ChatDBInit : DropCreateDatabaseIfModelChanges<ChatDBContext>
    {
        protected override void Seed(ChatDBContext context)
        {
            context.TextMessages.AddRange(new List<TextMessage>(){
                new TextMessage() { Id=1, Content="Dong chat so 1", Sender="Thang", SentTime=DateTime.Now.AddMinutes(-5)},
                new TextMessage() { Id=2, Content="Dong chat so 2", Sender="Thanh", SentTime=DateTime.Now.AddMinutes(-4)},
                new TextMessage() { Id=3, Content="Dong chat so 3", Sender="Huy", SentTime=DateTime.Now.AddMinutes(-3)},
                new TextMessage() { Id=4, Content="Dong chat so 4", Sender="Thang", SentTime=DateTime.Now.AddMinutes(-2)},
                new TextMessage() { Id=5, Content="Dong chat so 5", Sender="Huy", SentTime=DateTime.Now.AddMinutes(-1)},
            });
            context.Users.Add(new User() { UserName = "Thang", Password = "123456" });
            context.Users.Add(new User() { UserName = "Thanh", Password = "654321" });
            context.Users.Add(new User() { UserName = "Huy", Password = "abcdef" });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}