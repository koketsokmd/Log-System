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
    public class Weekly_EvalController : Controller
    {
        private DDNA_DBEntities db = new DDNA_DBEntities();

        // GET: Weekly_Eval
        public ActionResult Index()
        {
            var tBL_Weekly = db.TBL_Weekly.Include(t => t.Mentor).Include(t => t.Student);
            return View(tBL_Weekly.ToList());
        }

        // GET: Weekly_Eval/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Weekly tBL_Weekly = db.TBL_Weekly.Find(id);
            if (tBL_Weekly == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Weekly);
        }

        // GET: Weekly_Eval/Create
        public ActionResult Create()
        {
            ViewBag.MentorID = new SelectList(db.Mentors, "MentorID", "Username");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Username");
            return View();
        }

        // POST: Weekly_Eval/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MentorID,StudentID,CellPhone,LearnershipIntk,Date,Task,CompletedToSatisifaction,Time,ProblemsExperienced,GeneralComments,LeanerSign,MentorSign")] TBL_Weekly tBL_Weekly)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Weekly.Add(tBL_Weekly);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MentorID = new SelectList(db.Mentors, "MentorID", "Username", tBL_Weekly.MentorID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Username", tBL_Weekly.StudentID);
            return View(tBL_Weekly);
        }

        // GET: Weekly_Eval/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Weekly tBL_Weekly = db.TBL_Weekly.Find(id);
            if (tBL_Weekly == null)
            {
                return HttpNotFound();
            }
            ViewBag.MentorID = new SelectList(db.Mentors, "MentorID", "Username", tBL_Weekly.MentorID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Username", tBL_Weekly.StudentID);
            return View(tBL_Weekly);
        }

        // POST: Weekly_Eval/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MentorID,StudentID,CellPhone,LearnershipIntk,Date,Task,CompletedToSatisifaction,Time,ProblemsExperienced,GeneralComments,LeanerSign,MentorSign")] TBL_Weekly tBL_Weekly)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Weekly).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MentorID = new SelectList(db.Mentors, "MentorID", "Username", tBL_Weekly.MentorID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Username", tBL_Weekly.StudentID);
            return View(tBL_Weekly);
        }

        // GET: Weekly_Eval/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Weekly tBL_Weekly = db.TBL_Weekly.Find(id);
            if (tBL_Weekly == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Weekly);
        }

        // POST: Weekly_Eval/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_Weekly tBL_Weekly = db.TBL_Weekly.Find(id);
            db.TBL_Weekly.Remove(tBL_Weekly);
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
