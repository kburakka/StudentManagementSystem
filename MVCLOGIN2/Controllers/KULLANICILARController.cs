using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCLOGIN2.Models;
using MVCLOGIN2.Helpers;

namespace MVCLOGIN2.Controllers
{
    [SessionControl]
    public class KULLANICILARController : Controller
    {
        private sisEntities1 db = new sisEntities1();
    
        public ActionResult CourseRegistration()
        {
            int s = int.Parse(Session["studentid"].ToString());
            var monday = db.takes.Where(x => x.studentID == s && x.cours.day == "monday");
            var tuesday = db.takes.Where(x => x.studentID == s && x.cours.day == "tuesday");
            var wednesday = db.takes.Where(x => x.studentID == s && x.cours.day == "wednesday");
            var thursday = db.takes.Where(x => x.studentID == s && x.cours.day == "thursday");
            var friday = db.takes.Where(x => x.studentID == s && x.cours.day == "friday");

            ViewBag.monday = monday;
            ViewBag.tuesday = tuesday;
            ViewBag.wednesday = wednesday;
            ViewBag.thursday = thursday;
            ViewBag.friday = friday;
            return View();
        }
         
        public CourseTakesModel getTakesStudentModel(int semesterNo)
        {
            int studentID = int.Parse(Session["studentid"].ToString());
            int departmantID = int.Parse(Session["studepid"].ToString());
            CourseTakesModel ctm = new CourseTakesModel();
            ctm.Courses = db.courses.Where(x => x.semesterno == semesterNo && x.departmentID == departmantID).ToList();
            ctm.TakeLessons = db.takes.Where(t => t.studentID == studentID && t.semesterno == semesterNo).ToList();
            ctm.AllTakenLessons = db.takes.Where(t => t.semesterno == semesterNo).ToList();
            return ctm;
        }
         
        public ActionResult Semester()
        {
            return View(getTakesStudentModel(1));
        }   
        public ActionResult Semester2()
        {
            return View(getTakesStudentModel(2));
        }         
        public ActionResult Semester3()
        {
            return View(getTakesStudentModel(3));
        }        
        public ActionResult Semester4()
        { 
            return View(getTakesStudentModel(4));
        }       
        public ActionResult Semester5()
        {
            return View(getTakesStudentModel(5));
        }       
        public ActionResult Semester6()
        {
            return View(getTakesStudentModel(6));
        }       
        public ActionResult Semester7()
        { 
            return View(getTakesStudentModel(7));   
        }       
        public ActionResult Semester8()
        {
            return View(getTakesStudentModel(8));
        }
         
        public ActionResult forum()
        {
            return View(db.courses.ToList());
        }
         
        public ActionResult Comment(int? id)
        {
            var cs = db.courses.FirstOrDefault(c => c.courseID == id);
            var forum = db.fora.Where(f => f.courseID == id);
            if(cs != null)
            {
                Session["CurrentCourse"] = cs.coursename;
                Session["CourseID"] = cs.courseID;
            }
            return View(forum.ToList());
        }
         
        [HttpPost]
        public ActionResult Comment(string text, int? id)
            {
            var cs = db.courses.FirstOrDefault(c => c.courseID == id);
            var forum = db.fora.Where(f => f.courseID == id);  
            bool sonuc = false;
            try
            {
                forum yeniyorum = new forum();

                yeniyorum.text = text;
                yeniyorum.studentID = int.Parse(Session["studentid"].ToString());
                yeniyorum.courseID = int.Parse(Session["CourseID"].ToString());
                yeniyorum.addedtime = DateTime.Now;
                yeniyorum.student = db.students.Find(yeniyorum.studentID);
                yeniyorum.Active = false;
                db.fora.Add(yeniyorum);
                sonuc = db.SaveChanges() > 0;
                TempData["alert"] = "<script>alert('yorum eklenmistir');</script>";
            }
            catch (Exception e)
            {
                e.ToString();
            }
            var newForum = db.fora.Where(f => f.courseID == id);
            return Comment(id);
        }

        
        public ActionResult Grades()
        {
            int studentID = int.Parse(Session["studentid"].ToString());
            var gradelist = db.grades.Where(g => g.studentID == studentID);
            return View(model:gradelist);
        }
         
        public ActionResult Message()
        { 
            return View();
        }
         
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]    
        public ActionResult NewMessage( string y, string text, string about)
        {
            var x = Session["StudentName"].ToString();

            try
            {
                message addc = new message();


                addc.fromname = x;
                addc.toname = y ;
                addc.text = text;
                addc.about = about;
                addc.addedtime = DateTime.Now;

                db.messages.Add(addc);
                db.SaveChanges();
                TempData["alert"] = "<script>alert('course is added');</script>";
            }
            catch (Exception e)
            {
                e.ToString();
            }
         
            return RedirectToAction("Message"); ;
        }
         
        public ActionResult Inbox()
        {
            var mesaj = Session["StudentName"].ToString();
            var inbox = db.messages.Where(x => x.toname == mesaj);

            return View(inbox.ToList());
        }
         
        public ActionResult Sent()
        {
            var mesaj = Session["StudentName"].ToString();
            var sent = db.messages.Where(x => x.fromname== mesaj);

            return View(sent.ToList());
        }
         
        public ActionResult Exam()
        {
            int s = int.Parse(Session["studentid"].ToString());
            var courses = db.takes.Where(x => x.studentID == s);
            return View(courses.ToList());
        }

        public ActionResult Schedule()
        {
            int s = int.Parse(Session["studentid"].ToString());
            var monday = db.takes.Where(x => x.studentID == s && x.cours.day == "monday");
            var tuesday = db.takes.Where(x => x.studentID == s && x.cours.day == "tuesday");
            var wednesday = db.takes.Where(x => x.studentID == s && x.cours.day == "wednesday");
            var thursday = db.takes.Where(x => x.studentID == s && x.cours.day == "thursday");
            var friday = db.takes.Where(x => x.studentID == s && x.cours.day == "friday");

            ViewBag.monday = monday;
            ViewBag.tuesday = tuesday;
            ViewBag.wednesday = wednesday;
            ViewBag.thursday = thursday;
            ViewBag.friday = friday;

            return View();
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
 