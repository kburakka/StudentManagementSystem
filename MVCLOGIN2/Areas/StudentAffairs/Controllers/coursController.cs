using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCLOGIN2.Models;
using MVCLOGIN2.Areas.StudentAffairs.Helper;

namespace MVCLOGIN2.Areas.StudentAffairs.Controllers
{
    [SessionsControl]
    public class coursController : Controller
    {
        private sisEntities1 db = new sisEntities1();

        
        public ActionResult Index()
        {
            var courses = db.courses.Include(c => c.department).Include(c => c.instructor);
            return View(courses.ToList());
        }

     
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cours cours = db.courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        
        public ActionResult Create()
        {
            ViewBag.departmentID = new SelectList(db.departments, "departmentID", "depname");
            ViewBag.instructorID = new SelectList(db.instructors, "instructorID", "instfullname");
            return View();
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "courseID,room,coursecode,coursename,ects,section,prerequisites,day,coursetype,departmentID,semesterno,instructorID,examdate,examtime,coursestart,courseend,quota")] cours cours)
        {
            if (ModelState.IsValid)
            {
                db.courses.Add(cours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.departmentID = new SelectList(db.departments, "departmentID", "depname", cours.departmentID);
            ViewBag.instructorID = new SelectList(db.instructors, "instructorID", "instfullname", cours.instructorID);
            return View(cours);
        }

    
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cours cours = db.courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            ViewBag.departmentID = new SelectList(db.departments, "departmentID", "depname", cours.departmentID);
            ViewBag.instructorID = new SelectList(db.instructors, "instructorID", "instfullname", cours.instructorID);
            return View(cours);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "courseID,room,coursecode,coursename,ects,section,prerequisites,day,coursetype,departmentID,semesterno,instructorID,examdate,examtime,coursestart,courseend,quota")] cours cours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.departmentID = new SelectList(db.departments, "departmentID", "depname", cours.departmentID);
            ViewBag.instructorID = new SelectList(db.instructors, "instructorID", "instfullname", cours.instructorID);
            return View(cours);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cours cours = db.courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cours cours = db.courses.Find(id);
            db.courses.Remove(cours);
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
