using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JalgrattaEksam.Models;

namespace JalgrattaEksam.Controllers
{
    public class EksamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Eksams
        public ActionResult Index()
        {
            return View(db.Eksams.ToList());
        }

        // GET: Eksams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eksam eksam = db.Eksams.Find(id);
            if (eksam == null)
            {
                return HttpNotFound();
            }
            return View(eksam);
        }

        // GET: Eksams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Eksams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Eesnimi,Perenimi,Teooria,Slaalom,Ringtee,Tee,Luba")] Eksam eksam)
        {
            if (ModelState.IsValid)
            {
                db.Eksams.Add(eksam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eksam);
        }

        // GET: Eksams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eksam eksam = db.Eksams.Find(id);
            if (eksam == null)
            {
                return HttpNotFound();
            }
            return View(eksam);
        }

        // POST: Eksams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Eesnimi,Perenimi,Teooria,Slaalom,Ringtee,Tee,Luba")] Eksam eksam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eksam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eksam);
        }

        // GET: Eksams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eksam eksam = db.Eksams.Find(id);
            if (eksam == null)
            {
                return HttpNotFound();
            }
            return View(eksam);
        }

        // POST: Eksams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Eksam eksam = db.Eksams.Find(id);
            db.Eksams.Remove(eksam);
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
