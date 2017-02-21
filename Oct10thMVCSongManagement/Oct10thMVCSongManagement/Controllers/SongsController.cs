using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Oct10thMVCSongManagement.Models;
using PagedList.Mvc;
using PagedList;
namespace Oct10thMVCSongManagement.Controllers
{
    public class SongsController : Controller
    {
        private SongManagementDBEntities db = new SongManagementDBEntities();

        // GET: Songs
        public ActionResult Index(int? page)
        {
            ViewBag.searchGenre = new SelectList(db.Genres, "GenreName", "GenreName");
            var songs = db.Songs.Include(s => s.Genre).OrderBy(s => s.ID);
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            return View(songs.ToPagedList(pageNumber, 5));
        }
        [HttpPost]
        public ActionResult Index(int? page, string searchGenre="", string searchTitle="")
        {
            ViewBag.searchGenre = new SelectList(db.Genres, "GenreName", "GenreName");
            var songs = db.Songs.Include(s => s.Genre).Where(s => s.Title.Contains(searchTitle) && s.Genre.GenreName.Contains(searchGenre)).OrderBy(s => s.ID);
            ViewBag.searchTitle1 = searchTitle;
            ViewBag.searchGenre1 = searchGenre;
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            if (songs.Count() > (page-1) * 5)
                pageNumber = pageNumber;
            else
                pageNumber = 1;
                return View(songs.ToPagedList(pageNumber, 5));
        }

        // GET: Songs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // GET: Songs/Create
        public ActionResult Create()
        {
            ViewBag.GenreID = new SelectList(db.Genres, "ID", "GenreName");
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ArtistName,GenreID")] Song song)
        {
            if (ModelState.IsValid)
            {
                db.Songs.Add(song);
                db.SaveChanges();
                TempData["thongbao"] = "Nhap moi thanh cong!";
                return RedirectToAction("Index");
            }

            ViewBag.GenreID = new SelectList(db.Genres, "ID", "GenreName", song.GenreID);
            return View(song);
        }

        // GET: Songs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreID = new SelectList(db.Genres, "ID", "GenreName", song.GenreID);
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ArtistName,GenreID")] Song song)
        {
            if (ModelState.IsValid)
            {
                db.Entry(song).State = EntityState.Modified;
                db.SaveChanges();
                TempData["thongbao"] = "Sua thanh cong!";
                return RedirectToAction("Index");
            }
            ViewBag.GenreID = new SelectList(db.Genres, "ID", "GenreName", song.GenreID);
            return View(song);
        }

        // GET: Songs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Song song = db.Songs.Find(id);
            db.Songs.Remove(song);
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
