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
    public class annoucementsController : Controller
    {
        private sisEntities1 db = new sisEntities1();

        public ActionResult Index()
        {
            return View(db.annoucements.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            annoucement annoucement = db.annoucements.Find(id);
            if (annoucement == null)
            {
                return HttpNotFound();
            }
            return View(annoucement);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "text")] annoucement annoucement)
        {
            if (ModelState.IsValid)
            {
                db.annoucements.Add(annoucement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(annoucement);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            annoucement annoucement = db.annoucements.Find(id);
            if (annoucement == null)
            {
                return HttpNotFound();
            }
            return View(annoucement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "annoucementID,text")] annoucement annoucement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(annoucement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(annoucement);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            annoucement annoucement = db.annoucements.Find(id);
            if (annoucement == null)
            {
                return HttpNotFound();
            }
            return View(annoucement);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            annoucement annoucement = db.annoucements.Find(id);
            db.annoucements.Remove(annoucement);
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
