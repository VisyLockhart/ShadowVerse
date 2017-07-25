using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShadowVerse.Models;

namespace ShadowVerse.Areas.CMS.Controllers
{
    public class AmuletsController : Controller
    {
        private ShadowVerseEntities db = new ShadowVerseEntities();

        // GET: CMS/Amulets
        public ActionResult Index()
        {
            return View(db.Amulet.ToList());
        }

        // GET: CMS/Amulets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amulet amulet = db.Amulet.Find(id);
            if (amulet == null)
            {
                return HttpNotFound();
            }
            return View(amulet);
        }

        // GET: CMS/Amulets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/Amulets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,story,ability,imgUrl,cdRound")] Amulet amulet)
        {
            if (ModelState.IsValid)
            {
                db.Amulet.Add(amulet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(amulet);
        }

        // GET: CMS/Amulets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amulet amulet = db.Amulet.Find(id);
            if (amulet == null)
            {
                return HttpNotFound();
            }
            return View(amulet);
        }

        // POST: CMS/Amulets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,story,ability,imgUrl,cdRound")] Amulet amulet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(amulet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(amulet);
        }

        // GET: CMS/Amulets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amulet amulet = db.Amulet.Find(id);
            if (amulet == null)
            {
                return HttpNotFound();
            }
            return View(amulet);
        }

        // POST: CMS/Amulets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Amulet amulet = db.Amulet.Find(id);
            db.Amulet.Remove(amulet);
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
