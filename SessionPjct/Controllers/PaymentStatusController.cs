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
    public class PaymentStatusController : Controller
    {
        private SessionDBEntities db = new SessionDBEntities();

        // GET: PaymentStatus
        public ActionResult Index()
        {
            return View(db.PaymentStatus.ToList());
        }

        // GET: PaymentStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentStatu paymentStatu = db.PaymentStatus.Find(id);
            if (paymentStatu == null)
            {
                return HttpNotFound();
            }
            return View(paymentStatu);
        }

        // GET: PaymentStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentStatusId,StatusName")] PaymentStatu paymentStatu)
        {
            if (ModelState.IsValid)
            {
                db.PaymentStatus.Add(paymentStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paymentStatu);
        }

        // GET: PaymentStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentStatu paymentStatu = db.PaymentStatus.Find(id);
            if (paymentStatu == null)
            {
                return HttpNotFound();
            }
            return View(paymentStatu);
        }

        // POST: PaymentStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentStatusId,StatusName")] PaymentStatu paymentStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paymentStatu);
        }

        // GET: PaymentStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentStatu paymentStatu = db.PaymentStatus.Find(id);
            if (paymentStatu == null)
            {
                return HttpNotFound();
            }
            return View(paymentStatu);
        }

        // POST: PaymentStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentStatu paymentStatu = db.PaymentStatus.Find(id);
            db.PaymentStatus.Remove(paymentStatu);
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
