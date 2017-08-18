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
    public class Student_EvalController : Controller
    {
        private DDNA_DBEntities db = new DDNA_DBEntities();

        // GET: Student_Eval
        public ActionResult Index()
        {
            var student_Eval = db.Student_Eval.Include(s => s.Mentor).Include(s => s.Student);
            return View(student_Eval.ToList());
        }

        // GET: Student_Eval/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Eval student_Eval = db.Student_Eval.Find(id);
            if (student_Eval == null)
            {
                return HttpNotFound();
            }
            return View(student_Eval);
        }

        // GET: Student_Eval/Create
        public ActionResult Create()
        {
            ViewBag.MentorID = new SelectList(db.Mentors, "MentorID", "Username");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Username");
            return View();
        }

        // POST: Student_Eval/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MentorID,StudentID,WorkplaceExperience,LearningProcess,CommunicationSkills,AccomodationOfLearners,LearnerProblemSolving,FinalJudgement,Comments,LeanerSign,MentorSign")] Student_Eval student_Eval)
        {
            if (ModelState.IsValid)
            {
                db.Student_Eval.Add(student_Eval);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MentorID = new SelectList(db.Mentors, "MentorID", "Username", student_Eval.MentorID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Username", student_Eval.StudentID);
            return View(student_Eval);
        }

        // GET: Student_Eval/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Eval student_Eval = db.Student_Eval.Find(id);
            if (student_Eval == null)
            {
                return HttpNotFound();
            }
            ViewBag.MentorID = new SelectList(db.Mentors, "MentorID", "Username", student_Eval.MentorID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Username", student_Eval.StudentID);
            return View(student_Eval);
        }

        // POST: Student_Eval/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MentorID,StudentID,WorkplaceExperience,LearningProcess,CommunicationSkills,AccomodationOfLearners,LearnerProblemSolving,FinalJudgement,Comments,LeanerSign,MentorSign")] Student_Eval student_Eval)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_Eval).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MentorID = new SelectList(db.Mentors, "MentorID", "Username", student_Eval.MentorID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Username", student_Eval.StudentID);
            return View(student_Eval);
        }

        // GET: Student_Eval/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Eval student_Eval = db.Student_Eval.Find(id);
            if (student_Eval == null)
            {
                return HttpNotFound();
            }
            return View(student_Eval);
        }

        // POST: Student_Eval/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Student_Eval student_Eval = db.Student_Eval.Find(id);
            db.Student_Eval.Remove(student_Eval);
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
