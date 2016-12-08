using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExtremeGym_App.Context;
using ExtremeGym_App.Models;

namespace ExtremeGym_App.Controllers
{
    public class PurchasesController : Controller
    {
        private ERMDBContext db = new ERMDBContext();

        // GET: Purchases
        public ActionResult Index(string Id)
        {
            ViewBag.MembersId = Id;
            return View(db.Purchases.Where(a=>a.MembersID==Id).ToList());
        }

        // GET: Purchases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchases purchases = db.Purchases.Find(id);
            if (purchases == null)
            {
                return HttpNotFound();
            }
            return View(purchases);
        }

        // GET: Purchases/Create
        public ActionResult Create(string membersId)
        {
            return View();
        }

        // POST: Purchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MembersID,Item,Quantity,Price,Date")] Purchases purchases)
        {
            if (ModelState.IsValid)
            {
                db.Purchases.Add(purchases);
                db.SaveChanges();
                return RedirectToAction("Index", new {id = purchases.MembersID });
            }

            return View(purchases);
        }

        // GET: Purchases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchases purchases = db.Purchases.Find(id);
            if (purchases == null)
            {
                return HttpNotFound();
            }
            return View(purchases);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MembersID,Item,Quantity,Price,Date")] Purchases purchases)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchases).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchases);
        }

        // GET: Purchases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchases purchases = db.Purchases.Find(id);
            if (purchases == null)
            {
                return HttpNotFound();
            }
            return View(purchases);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Purchases purchases = db.Purchases.Find(id);
            db.Purchases.Remove(purchases);
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
