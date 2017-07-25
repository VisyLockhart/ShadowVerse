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
    public class SpellsController : Controller
    {
        private ShadowVerseEntities db = new ShadowVerseEntities();

        // GET: CMS/Spells
        public ActionResult Index()
        {
            return View(db.Spell.ToList());
        }

        // GET: CMS/Spells/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spell spell = db.Spell.Find(id);
            if (spell == null)
            {
                return HttpNotFound();
            }
            return View(spell);
        }

        // GET: CMS/Spells/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/Spells/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,story,ability,imgUrl,enhance")] Spell spell)
        {
            if (ModelState.IsValid)
            {
                db.Spell.Add(spell);

                //try
                //{
                db.SaveChanges();
                //}
                //catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                //{
                //    Exception raise = dbEx;
                //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                //    {
                //        foreach (var validationError in validationErrors.ValidationErrors)
                //        {
                //            string message = string.Format("{0}:{1}",
                //                validationErrors.Entry.Entity.ToString(),
                //                validationError.ErrorMessage);
                //            // raise a new exception nesting
                //            // the current instance as InnerException
                //            raise = new InvalidOperationException(message, raise);
                //        }
                //    }
                //    throw raise;
                //}
                return RedirectToAction("Index");
            }

            return View(spell);
        }

        // GET: CMS/Spells/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spell spell = db.Spell.Find(id);
            if (spell == null)
            {
                return HttpNotFound();
            }
            return View(spell);
        }

        // POST: CMS/Spells/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,story,ability,imgUrl,enhance")] Spell spell)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spell).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(spell);
        }

        // GET: CMS/Spells/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spell spell = db.Spell.Find(id);
            if (spell == null)
            {
                return HttpNotFound();
            }
            return View(spell);
        }

        // POST: CMS/Spells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Spell spell = db.Spell.Find(id);
            db.Spell.Remove(spell);
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
