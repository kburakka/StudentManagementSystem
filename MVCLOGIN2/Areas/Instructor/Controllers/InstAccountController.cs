using MVCLOGIN2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLOGIN2.Areas.Instructor.Controllers
{
    public class InstAccountController : Controller
    {
        private sisEntities1 db = new sisEntities1();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(instructor model)
        {
            if (ModelState.IsValid) 
            {
                var Username = db.instructors.FirstOrDefault(x => x.instusername == model.instusername && x.instpassword == model.instpassword);
                if (Username != null)
                {

                    Session["Username"] = Username;
                    Session["instructorID"] = Username.instructorID;
                    return RedirectToAction("Index", "grades");
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
            return RedirectToAction("Login", "InstAccount");

        }
    }
}