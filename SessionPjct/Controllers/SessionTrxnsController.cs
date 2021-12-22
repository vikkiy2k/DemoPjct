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
    public class SessionTrxnsController : Controller
    {
        private SessionDBEntities db = new SessionDBEntities();

        // GET: SessionTrxns
        public ActionResult Index()
        {
            return View(db.SessionTrxns.ToList());
        }

        // GET: SessionTrxns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionTrxn sessionTrxn = db.SessionTrxns.Find(id);
            if (sessionTrxn == null)
            {
                return HttpNotFound();
            }
            return View(sessionTrxn);
        }

        // GET: SessionTrxns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SessionTrxns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SessionTrnId,SessionId,MentorId,CandidateId,SessionStatus,PaymentStatus,SessionCount")] SessionTrxn sessionTrxn)
        {
            if (ModelState.IsValid)
            {
                db.SessionTrxns.Add(sessionTrxn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sessionTrxn);
        }

        // GET: SessionTrxns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionTrxn sessionTrxn = db.SessionTrxns.Find(id);
            if (sessionTrxn == null)
            {
                return HttpNotFound();
            }
            return View(sessionTrxn);
        }

        // POST: SessionTrxns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SessionTrnId,SessionId,MentorId,CandidateId,SessionStatus,PaymentStatus,SessionCount")] SessionTrxn sessionTrxn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sessionTrxn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sessionTrxn);
        }

        // GET: SessionTrxns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionTrxn sessionTrxn = db.SessionTrxns.Find(id);
            if (sessionTrxn == null)
            {
                return HttpNotFound();
            }
            return View(sessionTrxn);
        }

        // POST: SessionTrxns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SessionTrxn sessionTrxn = db.SessionTrxns.Find(id);
            db.SessionTrxns.Remove(sessionTrxn);
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
