using MVCLOGIN2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLOGIN2.Areas.StudentAffairs.Controllers
{
    public class IndexController : Controller
    {
        private sisEntities1 db = new sisEntities1();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(admin model)
        {
            if (ModelState.IsValid) 
            {
                var Username = db.admins.FirstOrDefault(x => x.username == model.username && x.password == model.password);
                if (Username != null)
                {

                    Session["Username"] = Username;

                    return RedirectToAction("Index", "Index");
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
            return RedirectToAction("Login", "Index");

        }
    }
}