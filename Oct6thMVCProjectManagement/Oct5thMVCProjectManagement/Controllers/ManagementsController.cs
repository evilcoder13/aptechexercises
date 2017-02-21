using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Oct5thMVCProjectManagement.Models;

namespace Oct5thMVCProjectManagement.Controllers
{
    [Authorize]
    public class ManagementsController : Controller
    {
        private ProjectManagementDBContext db = new ProjectManagementDBContext();

        // GET: Managements
        [OutputCache(Duration=300)]
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.searchProjectName = new SelectList(db.Projects, "PrjName", "PrjName");
            var managements = db.Managements.Include(m => m.Cust).Include(m => m.Emp).Include(m => m.Prj);
            return View(managements.ToList());
        }

        // GET: Managements
        [HttpPost]
        [OutputCache(Duration = 300)]
        [AllowAnonymous]
        public ActionResult Index(string searchProjectName, string searchCustomerName, string searchEmployeeName)
        {
            ViewBag.searchProjectName = new SelectList(db.Projects, "PrjName", "PrjName");
            var managements = db.Managements.Include(m => m.Cust).Include(m => m.Emp).Include(m => m.Prj);
            if (!string.IsNullOrEmpty(searchProjectName))
                managements = managements.Where(m => m.Prj.PrjName.Contains(searchProjectName));
            if (!string.IsNullOrEmpty(searchCustomerName))
                managements = from m in managements where m.Cust.CustName.Contains(searchCustomerName) select m;
            if (!string.IsNullOrEmpty(searchEmployeeName))
                managements = managements.Where(m => m.Emp.EmpName.Contains(searchEmployeeName));
            return View(managements.ToList());
        }

        // GET: Managements/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id, int? id2, int? id3)
        {
            if (id == null || id2==null|| id3==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Management management = db.Managements.Where(m => m.EmpId == id && m.CustId == id2 && m.PrjId == id3).Single();
            if (management == null)
            {
                return HttpNotFound();
            }
            return View(management);
        }

        // GET: Managements/Create
        public ActionResult Create()
        {
            ViewBag.CustId = new SelectList(db.Customers, "CustId", "CustName");
            ViewBag.EmpId = new SelectList(db.Employees, "EmpId", "EmpName");
            ViewBag.PrjId = new SelectList(db.Projects, "PrjId", "PrjName");
            return View();
        }

        // POST: Managements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpId,CustId,PrjId,Note")] Management management)
        {
            if (ModelState.IsValid)
            {
                db.Managements.Add(management);
                db.SaveChanges();
                TempData["thongbao"] = "Them moi thanh cong!";
                return RedirectToAction("Index");
            }

            ViewBag.CustId = new SelectList(db.Customers, "CustId", "CustName", management.CustId);
            ViewBag.EmpId = new SelectList(db.Employees, "EmpId", "EmpName", management.EmpId);
            ViewBag.PrjId = new SelectList(db.Projects, "PrjId", "PrjName", management.PrjId);
            return View(management);
        }

        // GET: Managements/Edit/5
        public ActionResult Edit(int? id, int? id2, int? id3)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Management management = db.Managements.Find(id);
            if (management == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustId = new SelectList(db.Customers, "CustId", "CustName", management.CustId);
            ViewBag.EmpId = new SelectList(db.Employees, "EmpId", "EmpName", management.EmpId);
            ViewBag.PrjId = new SelectList(db.Projects, "PrjId", "PrjName", management.PrjId);
            return View(management);
        }

        // POST: Managements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpId,CustId,PrjId,Note")] Management management)
        {
            if (ModelState.IsValid)
            {
                db.Entry(management).State = EntityState.Modified;
                db.SaveChanges();
                TempData["thongbao"] = "Sua thanh cong!";
                return RedirectToAction("Index");
            }
            ViewBag.CustId = new SelectList(db.Customers, "CustId", "CustName", management.CustId);
            ViewBag.EmpId = new SelectList(db.Employees, "EmpId", "EmpName", management.EmpId);
            ViewBag.PrjId = new SelectList(db.Projects, "PrjId", "PrjName", management.PrjId);
            return View(management);
        }

        // GET: Managements/Delete/5
        public ActionResult Delete(int? id, int? id2, int? id3)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Management management = db.Managements.Where(m => m.EmpId == id && m.CustId == id2 && m.PrjId == id3).Single();
            if (management == null)
            {
                return HttpNotFound();
            }
            return View(management);
        }

        // POST: Managements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id, int? id2, int? id3)
        {
            Management management = db.Managements.Where(m => m.EmpId == id && m.CustId == id2 && m.PrjId == id3).Single();
            db.Managements.Remove(management);
            db.SaveChanges();
            TempData["thongbao"] = "Xoa thanh cong!";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
