using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfChatService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        ChatDBContext db = new ChatDBContext();
        public List<TextMessage> GetAll()
        {
            return db.TextMessages.ToList();
        }

        public List<TextMessage> GetAfterId(int id)
        {
            return db.TextMessages.Where(m=>m.Id>id).ToList();
        }

        public List<TextMessage> GetAfterTime(DateTime t)
        {
            return db.TextMessages.Where(m => m.SentTime > t).ToList();
        }

        public void InsertMessage(TextMessage tm)
        {
            db.TextMessages.Add(tm);
            db.SaveChanges();
        }
    }
}
