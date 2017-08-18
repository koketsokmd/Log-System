using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Logbook_System.DB;

namespace Logbook_System.Controllers
{
    public class Daily_RegisterController : Controller
    {
        private DDNA_DBEntities db = new DDNA_DBEntities();

        // GET: Daily_Register
        public ActionResult Index()
        {
            var daily_Register = db.Daily_Register.Include(d => d.Student);
            return View(daily_Register.ToList());
        }

        // GET: Daily_Register/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Daily_Register daily_Register = db.Daily_Register.Find(id);
            if (daily_Register == null)
            {
                return HttpNotFound();
            }
            return View(daily_Register);
        }

        // GET: Daily_Register/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Username");
            return View();
        }

        // POST: Daily_Register/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,Date")] Daily_Register daily_Register)
        {
            if (ModelState.IsValid)
            {
                db.Daily_Register.Add(daily_Register);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Username", daily_Register.StudentID);
            return View(daily_Register);
        }

        // GET: Daily_Register/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Daily_Register daily_Register = db.Daily_Register.Find(id);
            if (daily_Register == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Username", daily_Register.StudentID);
            return View(daily_Register);
        }

        // POST: Daily_Register/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,Date")] Daily_Register daily_Register)
        {
            if (ModelState.IsValid)
            {
                db.Entry(daily_Register).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Username", daily_Register.StudentID);
            return View(daily_Register);
        }

        // GET: Daily_Register/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Daily_Register daily_Register = db.Daily_Register.Find(id);
            if (daily_Register == null)
            {
                return HttpNotFound();
            }
            return View(daily_Register);
        }

        // POST: Daily_Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Daily_Register daily_Register = db.Daily_Register.Find(id);
            db.Daily_Register.Remove(daily_Register);
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
