using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebChatWCF.Controllers
{
    public class WebChatController : Controller
    {
        ServiceReference1.SimpleChatServiceClient client = new ServiceReference1.SimpleChatServiceClient();
        // GET: WebChat
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ServiceReference1.User u)
        {
            //return View();
            int userID = client.Login(u.UserName, u.Password);
            if(userID<=0)
            {
                return View();
            }
            else
            {
                Session["userID"] = userID;
                return RedirectToAction("Chat");
            }
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(ServiceReference1.User u)
        {
            client.Register(u);
            return RedirectToAction("Index");
        }
        public ActionResult Chat()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Chat(string Message)
        {
            client.SendMessage(new ServiceReference1.Message() { Content = Message, SendTime = DateTime.Now, SenderId = Session["userId"] == null ? 1 : (int)Session["userId"] });
            return View();
        }

        public ActionResult LoadMessage()
        {
            return View(client.GetAllMessages());
        }
    }
}