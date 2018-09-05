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
    public class studentsController : Controller
    {
        private sisEntities1 db = new sisEntities1();

        public ActionResult Index()
        {
            var students = db.students.Include(s => s.department).Include(s => s.faculty).Include(s => s.instructor);
            return View(students.ToList());
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        
        public ActionResult Create()
        {
            ViewBag.departmentID = new SelectList(db.departments, "departmentID", "depname");
            ViewBag.facultyID = new SelectList(db.faculties, "facultyID", "facultyname");
            ViewBag.instructorID = new SelectList(db.instructors, "instructorID", "instfullname");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "studentID,username,password,stufullname,number,departmentID,facultyID,instructorID,image")] student student)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.departmentID = new SelectList(db.departments, "departmentID", "depname", student.departmentID);
            ViewBag.facultyID = new SelectList(db.faculties, "facultyID", "facultyname", student.facultyID);
            ViewBag.instructorID = new SelectList(db.instructors, "instructorID", "instfullname", student.instructorID);
            return View(student);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.departmentID = new SelectList(db.departments, "departmentID", "depname", student.departmentID);
            ViewBag.facultyID = new SelectList(db.faculties, "facultyID", "facultyname", student.facultyID);
            ViewBag.instructorID = new SelectList(db.instructors, "instructorID", "instfullname", student.instructorID);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "studentID,username,password,stufullname,number,departmentID,facultyID,instructorID,image")] student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.departmentID = new SelectList(db.departments, "departmentID", "depname", student.departmentID);
            ViewBag.facultyID = new SelectList(db.faculties, "facultyID", "facultyname", student.facultyID);
            ViewBag.instructorID = new SelectList(db.instructors, "instructorID", "instfullname", student.instructorID);
            return View(student);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student student = db.students.Find(id);
            db.students.Remove(student);
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
