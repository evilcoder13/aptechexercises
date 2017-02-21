using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Oct12thMVCCMS.Models;

namespace Oct12thMVCCMS.Controllers
{
    public class CMS_ZonesController : Controller
    {
        private CMSDBEntities db = new CMSDBEntities();

        // GET: CMS_Zones
        public ActionResult Index()
        {
            return View(db.CMS_Zones.ToList());
        }

        // GET: CMS_Zones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMS_Zones cMS_Zones = db.CMS_Zones.Find(id);
            if (cMS_Zones == null)
            {
                return HttpNotFound();
            }
            return View(cMS_Zones);
        }

        // GET: CMS_Zones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS_Zones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Zone_ID,Zone_Name,Zone_ParentID,Zone_Priority,Zone_Type,Zone_Alias")] CMS_Zones cMS_Zones)
        {
            if (ModelState.IsValid)
            {
                db.CMS_Zones.Add(cMS_Zones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cMS_Zones);
        }

        // GET: CMS_Zones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMS_Zones cMS_Zones = db.CMS_Zones.Find(id);
            if (cMS_Zones == null)
            {
                return HttpNotFound();
            }
            return View(cMS_Zones);
        }

        // POST: CMS_Zones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Zone_ID,Zone_Name,Zone_ParentID,Zone_Priority,Zone_Type,Zone_Alias")] CMS_Zones cMS_Zones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cMS_Zones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cMS_Zones);
        }

        // GET: CMS_Zones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMS_Zones cMS_Zones = db.CMS_Zones.Find(id);
            if (cMS_Zones == null)
            {
                return HttpNotFound();
            }
            return View(cMS_Zones);
        }

        // POST: CMS_Zones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CMS_Zones cMS_Zones = db.CMS_Zones.Find(id);
            db.CMS_Zones.Remove(cMS_Zones);
            db.SaveChanges();
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
