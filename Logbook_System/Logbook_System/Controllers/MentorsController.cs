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
    public class MentorsController : Controller
    {
        private DDNA_DBEntities db = new DDNA_DBEntities();

        // GET: Mentors
        public ActionResult Index()
        {
            var mentors = db.Mentors.Include(m => m.Role);
            return View(mentors.ToList());
        }

        // GET: Mentors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mentor mentor = db.Mentors.Find(id);
            if (mentor == null)
            {
                return HttpNotFound();
            }
            return View(mentor);
        }

        // GET: Mentors/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName");
            return View();
        }

        // POST: Mentors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MentorID,Username,Password,Name,Surname,RoleID")] Mentor mentor)
        {
            if (ModelState.IsValid)
            {
                db.Mentors.Add(mentor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", mentor.RoleID);
            return View(mentor);
        }

        // GET: Mentors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mentor mentor = db.Mentors.Find(id);
            if (mentor == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", mentor.RoleID);
            return View(mentor);
        }

        // POST: Mentors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MentorID,Username,Password,Name,Surname,RoleID")] Mentor mentor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mentor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", mentor.RoleID);
            return View(mentor);
        }

        // GET: Mentors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mentor mentor = db.Mentors.Find(id);
            if (mentor == null)
            {
                return HttpNotFound();
            }
            return View(mentor);
        }

        // POST: Mentors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Mentor mentor = db.Mentors.Find(id);
            db.Mentors.Remove(mentor);
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
