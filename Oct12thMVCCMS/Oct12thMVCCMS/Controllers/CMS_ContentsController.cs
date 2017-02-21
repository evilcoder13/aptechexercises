using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Oct12thMVCCMS.Models;
using PagedList;
using PagedList.Mvc;
namespace Oct12thMVCCMS.Controllers
{
    public class CMS_ContentsController : Controller
    {
        private CMSDBEntities db = new CMSDBEntities();

        // GET: CMS_Contents
        public ActionResult Index(int? page, string searchText, string orderColumn)
        {
            var cMS_Contents = db.CMS_Contents.Include(c => c.CMS_Zones);
            //Neu co text de tim kiem, thuc hien viec tim kiem voi parameter searchText
            if(searchText!=null)
                cMS_Contents = cMS_Contents.Where(c => c.Content_Headline.Contains(searchText) || c.Content_Body.Contains(searchText) || c.Content_Teaser.Contains(searchText));
            
            //Luu trang thai tim kiem / sap xep hien co vao ViewBag
            ViewBag.OrderColumn = orderColumn;
            ViewBag.SearchText = searchText;

            //Neu co sap xep thi sap xep theo cot va chieu sap xep duoc truyen vao thong qua parameter orderColumn
            switch(orderColumn)
            { 
                case "Content_HeadlineASC":
                    //Sap xep theo ABC
                    cMS_Contents = cMS_Contents.OrderBy(c => c.Content_Headline);
                    break;
                case "Content_HeadlineDESC":
                    //Sap xep nguoc theo ZYX
                    cMS_Contents = cMS_Contents.OrderByDescending(c => c.Content_Headline);
                    break;
                case "Content_TeaserASC":
                    cMS_Contents = cMS_Contents.OrderBy(c => c.Content_Headline);
                    break;
                case "Content_TeaserDESC":
                    cMS_Contents = cMS_Contents.OrderByDescending(c => c.Content_Teaser);
                    break;
                default:
                    cMS_Contents = cMS_Contents.OrderByDescending(c => c.Content_Teaser);
                    break;
            }
            //Tra ve view voi 5 tin / trang
            return View(cMS_Contents.ToPagedList(page ?? 1, 5));
        }

        // GET: CMS_Contents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMS_Contents cMS_Contents = db.CMS_Contents.Find(id);
            if (cMS_Contents == null)
            {
                return HttpNotFound();
            }
            return View(cMS_Contents);
        }

        // GET: CMS_Contents/Create
        public ActionResult Create()
        {
            ViewBag.Content_ZoneID = new SelectList(db.CMS_Zones, "Zone_ID", "Zone_Name");
            return View();
        }

        // POST: CMS_Contents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Content_ID,Content_Headline,Content_Teaser,Content_Body,Content_Avatar,Content_CreateDate,Content_ModifiedDate,Content_Status,Content_ZoneID,Content_UserID,Content_ModifiedUserID,Content_Comment,Content_IsFocus,Content_IsHot,Content_LgID,Content_Viewed,Content_FocusID")] CMS_Contents cMS_Contents)
        {
            if (ModelState.IsValid)
            {
                db.CMS_Contents.Add(cMS_Contents);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Content_ZoneID = new SelectList(db.CMS_Zones, "Zone_ID", "Zone_Name", cMS_Contents.Content_ZoneID);
            return View(cMS_Contents);
        }

        // GET: CMS_Contents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMS_Contents cMS_Contents = db.CMS_Contents.Find(id);
            if (cMS_Contents == null)
            {
                return HttpNotFound();
            }
            ViewBag.Content_ZoneID = new SelectList(db.CMS_Zones, "Zone_ID", "Zone_Name", cMS_Contents.Content_ZoneID);
            return View(cMS_Contents);
        }

        // POST: CMS_Contents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Content_ID,Content_Headline,Content_Teaser,Content_Body,Content_Avatar,Content_CreateDate,Content_ModifiedDate,Content_Status,Content_ZoneID,Content_UserID,Content_ModifiedUserID,Content_Comment,Content_IsFocus,Content_IsHot,Content_LgID,Content_Viewed,Content_FocusID")] CMS_Contents cMS_Contents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cMS_Contents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Content_ZoneID = new SelectList(db.CMS_Zones, "Zone_ID", "Zone_Name", cMS_Contents.Content_ZoneID);
            return View(cMS_Contents);
        }

        // GET: CMS_Contents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMS_Contents cMS_Contents = db.CMS_Contents.Find(id);
            if (cMS_Contents == null)
            {
                return HttpNotFound();
            }
            return View(cMS_Contents);
        }

        // POST: CMS_Contents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CMS_Contents cMS_Contents = db.CMS_Contents.Find(id);
            db.CMS_Contents.Remove(cMS_Contents);
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
