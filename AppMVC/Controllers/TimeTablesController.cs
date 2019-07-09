using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppMVC.Models;

namespace AppMVC.Controllers
{
    public class TimeTablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TimeTables
        public ActionResult Index( string SearchString)
        {
            var vreme = DateTime.UtcNow;
            var timeTab = db.TimeTables.Where(c => c.Time >= vreme);
            var timeTables = timeTab.Include(t => t.Hall).Include(t => t.Movie);
            
            if (!String.IsNullOrEmpty(SearchString))
            {
                //DateTime vreme = Convert.ToDateTime(SearchString).Date;
                //timeTables = timeTables.Where(v => v.Time.Date == vreme);
                DateTime Search = Convert.ToDateTime(SearchString);
                timeTables = timeTables.Where(r => DbFunctions.TruncateTime(r.Time) == Search.Date);

            }

            return View(timeTables.ToList());
        }

        // GET: TimeTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTable timeTable = db.TimeTables.Find(id);
            if (timeTable == null)
            {
                return HttpNotFound();
            }
            return View(timeTable);
        }

        // GET: TimeTables/Create
        [Authorize(Roles = "Editor,Admin")]
        public ActionResult Create()
        {
            ViewBag.HallId = new SelectList(db.Halls, "HallId", "HallName");
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title");
            return View();
        }

        // POST: TimeTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Editor,Admin")]
        public ActionResult Create([Bind(Include = "TimeId,HallId,MovieId,Time")] TimeTable timeTable)
        {
            if (ModelState.IsValid)
            {
                db.TimeTables.Add(timeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HallId = new SelectList(db.Halls, "HallId", "HallName", timeTable.HallId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title", timeTable.MovieId);
            return View(timeTable);
        }

        // GET: TimeTables/Edit/5
        [Authorize(Roles = "Admin,Editor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTable timeTable = db.TimeTables.Find(id);
            if (timeTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.HallId = new SelectList(db.Halls, "HallId", "HallName", timeTable.HallId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title", timeTable.MovieId);
            return View(timeTable);
        }

        // POST: TimeTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Editor")]
        public ActionResult Edit([Bind(Include = "TimeId,HallId,MovieId,Time")] TimeTable timeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HallId = new SelectList(db.Halls, "HallId", "HallName", timeTable.HallId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title", timeTable.MovieId);
            return View(timeTable);
        }

        // GET: TimeTables/Delete/5
        [Authorize(Roles = "Admin,Editor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTable timeTable = db.TimeTables.Find(id);
            if (timeTable == null)
            {
                return HttpNotFound();
            }
            return View(timeTable);
        }

        // POST: TimeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Editor")]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeTable timeTable = db.TimeTables.Find(id);
            db.TimeTables.Remove(timeTable);
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
