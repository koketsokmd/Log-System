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
    public class Mentor_EvalController : Controller
    {
        private DDNA_DBEntities db = new DDNA_DBEntities();

        // GET: Mentor_Eval
        public ActionResult Index()
        {
            var mentor_Eval = db.Mentor_Eval.Include(m => m.Mentor).Include(m => m.Student);
            return View(mentor_Eval.ToList());
        }

        // GET: Mentor_Eval/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mentor_Eval mentor_Eval = db.Mentor_Eval.Find(id);
            if (mentor_Eval == null)
            {
                return HttpNotFound();
            }
            return View(mentor_Eval);
        }

        // GET: Mentor_Eval/Create
        public ActionResult Create()
        {
            ViewBag.MentorID = new SelectList(db.Mentors, "MentorID", "Username");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Username");
            return View();
        }

        // POST: Mentor_Eval/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,MentorID,Relevance,Knowledge,Communication,Teamwork,ProblemSolving,FinalJudgement,Punctuality,Manners,Instructions,Enthusiasm,Workload,Adaptibility,JobKnowledge,PeerTeamwork,Assistance,Comments,LeanerSign,MentorSign")] Mentor_Eval mentor_Eval)
        {
            if (ModelState.IsValid)
            {
                db.Mentor_Eval.Add(mentor_Eval);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MentorID = new SelectList(db.Mentors, "MentorID", "Username", mentor_Eval.MentorID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Username", mentor_Eval.StudentID);
            return View(mentor_Eval);
        }

        // GET: Mentor_Eval/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mentor_Eval mentor_Eval = db.Mentor_Eval.Find(id);
            if (mentor_Eval == null)
            {
                return HttpNotFound();
            }
            ViewBag.MentorID = new SelectList(db.Mentors, "MentorID", "Username", mentor_Eval.MentorID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Username", mentor_Eval.StudentID);
            return View(mentor_Eval);
        }

        // POST: Mentor_Eval/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,MentorID,Relevance,Knowledge,Communication,Teamwork,ProblemSolving,FinalJudgement,Punctuality,Manners,Instructions,Enthusiasm,Workload,Adaptibility,JobKnowledge,PeerTeamwork,Assistance,Comments,LeanerSign,MentorSign")] Mentor_Eval mentor_Eval)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mentor_Eval).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MentorID = new SelectList(db.Mentors, "MentorID", "Username", mentor_Eval.MentorID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Username", mentor_Eval.StudentID);
            return View(mentor_Eval);
        }

        // GET: Mentor_Eval/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mentor_Eval mentor_Eval = db.Mentor_Eval.Find(id);
            if (mentor_Eval == null)
            {
                return HttpNotFound();
            }
            return View(mentor_Eval);
        }

        // POST: Mentor_Eval/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Mentor_Eval mentor_Eval = db.Mentor_Eval.Find(id);
            db.Mentor_Eval.Remove(mentor_Eval);
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
