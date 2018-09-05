using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCLOGIN2.Models;
using MVCLOGIN2.Areas.Instructor.Helper;

namespace MVCLOGIN2.Areas.Instructor.Controllers
{
    [SessionsControl]
    public class gradesController : Controller
    {
        private sisEntities1 db = new sisEntities1();

        public ActionResult Index()
        {
            int y = int.Parse(Session["instructorID"].ToString());
            var grades = db.grades.Where(x => x.cours.instructorID == y);
            return View(grades.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grade grade = db.grades.Find(id);
            if (grade == null)
            {
                return HttpNotFound();
            }
            return View(grade);
        }

        public ActionResult Create()
        {
            int y = int.Parse(Session["instructorID"].ToString());
            ViewBag.courseID = new SelectList(db.courses.Where(x => x.instructorID == y), "courseID", "coursename");
            ViewBag.studentID = new SelectList(db.students, "studentID", "username");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "gradeID,finalpont,letterpoint,studentID,courseID")] grade grade)
        {
            if (ModelState.IsValid)
            {
                db.grades.Add(grade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            int y = int.Parse(Session["instructorID"].ToString());
            ViewBag.courseID = new SelectList(db.courses.Where(x => x.instructorID == y), "courseID", "coursename", grade.courseID);
            ViewBag.studentID = new SelectList(db.students, "studentID", "username", grade.studentID);
            return View(grade);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grade grade = db.grades.Find(id);
            if (grade == null)
            {
                return HttpNotFound();
            }

            int y = int.Parse(Session["instructorID"].ToString());
            ViewBag.courseID = new SelectList(db.courses.Where(x => x.instructorID == y), "courseID", "coursename", grade.courseID);
            ViewBag.studentID = new SelectList(db.students, "studentID", "username", grade.studentID);
            return View(grade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "gradeID,finalpont,letterpoint,studentID,courseID")] grade grade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            int y = int.Parse(Session["instructorID"].ToString());
            ViewBag.courseID = new SelectList(db.courses.Where(x => x.instructorID == y), "courseID", "coursename", grade.courseID);
            ViewBag.studentID = new SelectList(db.students, "studentID", "username", grade.studentID);
            return View(grade);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grade grade = db.grades.Find(id);
            if (grade == null)
            {
                return HttpNotFound();
            }
            return View(grade);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            grade grade = db.grades.Find(id);
            db.grades.Remove(grade);
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
