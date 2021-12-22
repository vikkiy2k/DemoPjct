using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SessionPjct;

namespace SessionPjct.Controllers
{
    public class sessionstatusController : Controller
    {
        private SessionDBEntities db = new SessionDBEntities();

        // GET: sessionstatus
        public ActionResult Index()
        {
            return View(db.sessionstatus.ToList());
        }

        // GET: sessionstatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sessionstatu sessionstatu = db.sessionstatus.Find(id);
            if (sessionstatu == null)
            {
                return HttpNotFound();
            }
            return View(sessionstatu);
        }

        // GET: sessionstatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sessionstatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SessionStatusId,StatusName")] sessionstatu sessionstatu)
        {
            if (ModelState.IsValid)
            {
                db.sessionstatus.Add(sessionstatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sessionstatu);
        }

        // GET: sessionstatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sessionstatu sessionstatu = db.sessionstatus.Find(id);
            if (sessionstatu == null)
            {
                return HttpNotFound();
            }
            return View(sessionstatu);
        }

        // POST: sessionstatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SessionStatusId,StatusName")] sessionstatu sessionstatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sessionstatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sessionstatu);
        }

        // GET: sessionstatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sessionstatu sessionstatu = db.sessionstatus.Find(id);
            if (sessionstatu == null)
            {
                return HttpNotFound();
            }
            return View(sessionstatu);
        }

        // POST: sessionstatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sessionstatu sessionstatu = db.sessionstatus.Find(id);
            db.sessionstatus.Remove(sessionstatu);
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
