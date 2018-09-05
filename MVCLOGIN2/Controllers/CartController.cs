using MVCLOGIN2.Helpers;
using MVCLOGIN2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLOGIN2.Controllers
{
    [SessionControl]
    public class CartController : Controller
    {
        private sisEntities1 db = new sisEntities1();
        // GET: Cart
        [HttpGet]
         
        public ActionResult Index()
        {
            return View(GetCart());
        }

         
        public ActionResult AddtoCart(int? courseid)
        {
            var cours = db.courses.FirstOrDefault(i => i.courseID == courseid);
            if (cours != null)
            {
                GetCart().AddCourse(cours, 1);
            }

            
            

            return RedirectToAction("CourseRegistration","Kullanicilar");
        }
         
        [HttpPost]
        public ActionResult AddtoCart(int courseid)
        {
            int studentID = int.Parse(Session["studentid"].ToString());
            var cours = db.courses.FirstOrDefault(i => i.courseID == courseid);
            


            if (cours != null)
            {
                GetCart().AddCourse(cours, 1);
            }
            try
            {
                take addc = new take();
                addc.studentID = studentID;
                addc.courseID = courseid;
                addc.semesterno = cours.semesterno;
                db.takes.Add(addc);
                db.SaveChanges();
                TempData["alert"] = "<script>alert('course is added');</script>";
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return RedirectToAction("CourseRegistration", "Kullanicilar");
        }

         
        public ActionResult RemoveFromCart(int? courseid)
        {
            var cours = db.courses.FirstOrDefault(i => i.courseID == courseid);
            if (cours != null)
            {
                GetCart().DeleteCourse(cours);
            }
            return RedirectToAction("CourseRegistration", "Kullanicilar");
        }
         
        [HttpPost]
        public ActionResult RemoveFromCart(int courseid)
        {
            int studentID = int.Parse(Session["studentid"].ToString());
            var cours = db.takes.Where(i => i.studentID == studentID && i.courseID == courseid).FirstOrDefault();

            if (cours != null)
            {  
                db.takes.Remove(cours);
            }
            db.SaveChanges();
            return RedirectToAction("CourseRegistration", "Kullanicilar");
        }

         
        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if(cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}