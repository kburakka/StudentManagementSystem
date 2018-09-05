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
    public class HomeController : Controller
    {
        private sisEntities1 db = new sisEntities1();

        public ActionResult Index()
        {
            var textlist = db.annoucements.ToList();

            return View(model: textlist);
           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}