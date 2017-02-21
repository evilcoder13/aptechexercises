using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Oct17thMVCSchoolManagement.Models;
using PagedList;
using PagedList.Mvc;
namespace Oct17thMVCSchoolManagement.Controllers
{
    public class PeopleController : Controller
    {
        private SchoolDBEntities db = new SchoolDBEntities();

        // GET: People
        public ActionResult Index(int? CourseSearch, int? page, string SearchName, string OrderTable)
        {
            //Bind du lieu Couses vao DropDownList ten la : CourseSearch
            ViewBag.CourseSearch = new SelectList(db.Courses, "CourseID", "Title");
            //Lay du lieu bang People ket hop voi bang OfficeAssignment
            var people = db.People.Include(p => p.OfficeAssignment);
            //Tim kiem people theo Course (Quan he nhieu - nhieu)
            if (CourseSearch!=null)
                people = from p in db.People where p.Courses.Any(c => c.CourseID == CourseSearch) select p;
            //Tim kiem people theo first name hoac last name
            if (!string.IsNullOrEmpty(SearchName))
                people = people.Where(p => p.FirstName.Contains(SearchName) || p.LastName.Contains(SearchName));
            //Sap xep:
            switch(OrderTable)
            {
                case "LastNameDESC":
                    people = people.OrderByDescending(p => p.LastName);
                    break;
                case "LastNameASC":
                    people = people.OrderBy(p => p.LastName);
                    break;
                case "FirstNameDESC":
                    people = people.OrderByDescending(p => p.FirstName);
                    break;
                case "FirstNameASC":
                    people = people.OrderBy(p => p.FirstName);
                    break;
                case "HireDateDESC":
                    people = people.OrderByDescending(p => p.HireDate);
                    break;
                case "HireDateASC":
                    people = people.OrderBy(p => p.HireDate);
                    break;
                default:
                    people = people.OrderBy(p => p.PersonID);
                    break;
            }
            //Dua cac du lieu can thiet ra ViewBag de su dung lai.
            ViewBag.SearchName = SearchName;
            ViewBag.OrderTable = OrderTable;
            ViewBag.SearchCourse = CourseSearch;
            //Phan trang: Chuot phai vao Project chon Nuget Package Management -> tim PagedList -> cai PagedList.Mvc. Add using PagedList va PagedList.Mvc
            return View(people.ToPagedList(page??1,3)); //Thay ToList -> ToPagedList(page??1,3) trong do 3 la so phan tu tren 1 trang.
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            ViewBag.PersonID = new SelectList(db.OfficeAssignments, "InstructorID", "Location");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonID,LastName,FirstName,HireDate,EnrollmentDate")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(db.OfficeAssignments, "InstructorID", "Location", person.PersonID);
            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonID = new SelectList(db.OfficeAssignments, "InstructorID", "Location", person.PersonID);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonID,LastName,FirstName,HireDate,EnrollmentDate")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonID = new SelectList(db.OfficeAssignments, "InstructorID", "Location", person.PersonID);
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
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
