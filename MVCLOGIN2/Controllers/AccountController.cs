using MVCLOGIN2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLOGIN2.Controllers
{
    public class AccountController : Controller
    {
        private sisEntities1 db = new sisEntities1();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(student model)
        {
            if (ModelState.IsValid)
            {
                var Username = db.students.FirstOrDefault(x => x.username == model.username && x.password == model.password);
                if (Username != null)
                {

                    faculty faculty = db.faculties.SingleOrDefault(f => f.facultyID == Username.facultyID);
                    department department = db.departments.SingleOrDefault(d => d.departmentID == Username.departmentID);
                    instructor instructor = db.instructors.SingleOrDefault(d => d.instructorID == Username.instructorID);


                    Session["StudentName"] = Username.stufullname;
                    Session["StudentNumber"] = Username.number;
                    Session["StudentDep"] = department.depname;
                    Session["StudentFac"] = faculty.facultyname;
                    Session["studepid"] = Username.departmentID;
                    Session["studentid"] = Username.studentID;
                    Session["stufoto"] = Username.image;
                    Session["stuinst"] = instructor.instfullname;
                    Session["curriculum"] = department.curriculum;
                    Session["Username"] = Username;
                    ViewBag.curriculum = department.curriculum;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Username or password wrong!!!";
                }
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}