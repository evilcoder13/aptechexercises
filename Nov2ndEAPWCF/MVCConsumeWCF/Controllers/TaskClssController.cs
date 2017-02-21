using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCConsumeWCF.Controllers
{
    public class TaskClssController : Controller
    {
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        // GET: TaskClss
        public ActionResult Index()
        {
            return View(client.LayDuLieuTaskCls());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ServiceReference1.TaskCls tc)
        {
            client.InsertTaskCls(tc);
            return RedirectToAction("Index");
        }
    }
}