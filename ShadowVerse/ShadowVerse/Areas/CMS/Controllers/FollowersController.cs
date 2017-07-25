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
    public class FollowersController : Controller
    {
        private ShadowVerseEntities db = new ShadowVerseEntities();

        // GET: CMS/Followers
        public ActionResult Index()
        {
            return View(db.Follower.ToList());
        }

        // GET: CMS/Followers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Follower follower = db.Follower.Find(id);
            if (follower == null)
            {
                return HttpNotFound();
            }
            return View(follower);
        }

        // GET: CMS/Followers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/Followers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,story,imgUrl,attack,defense,ability,onslaught,ward,bane,enhance,fanfare,lastWords,trait")] Follower follower)
        {
            if (ModelState.IsValid)
            {
                db.Follower.Add(follower);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(follower);
        }

        // GET: CMS/Followers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Follower follower = db.Follower.Find(id);
            if (follower == null)
            {
                return HttpNotFound();
            }
            return View(follower);
        }

        // POST: CMS/Followers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,story,imgUrl,attack,defense,ability,onslaught,ward,bane,enhance,fanfare,lastWords,trait")] Follower follower)
        {
            if (ModelState.IsValid)
            {
                db.Entry(follower).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(follower);
        }

        // GET: CMS/Followers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Follower follower = db.Follower.Find(id);
            if (follower == null)
            {
                return HttpNotFound();
            }
            return View(follower);
        }

        // POST: CMS/Followers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Follower follower = db.Follower.Find(id);
            db.Follower.Remove(follower);
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
