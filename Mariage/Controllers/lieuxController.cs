using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mariage.Models;

namespace Mariage.Controllers
{
    public class lieuxController : Controller
    {
        private ckaeyah101694fr24274_mariageEntities db = new ckaeyah101694fr24274_mariageEntities();

        // GET: lieux
        public ActionResult Index()
        {
            return View(db.lieu.ToList());
        }

        // GET: lieux/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lieu lieu = db.lieu.Find(id);
            if (lieu == null)
            {
                return HttpNotFound();
            }
            return View(lieu);
        }

        // GET: lieux/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lieux/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,titre,description,coordonneesMaps,rue,code_postal,ville,pays,telephone,urlPhoto,siteWeb")] lieu lieu)
        {
            if (ModelState.IsValid)
            {
                db.lieu.Add(lieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lieu);
        }

        // GET: lieux/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lieu lieu = db.lieu.Find(id);
            if (lieu == null)
            {
                return HttpNotFound();
            }
            return View(lieu);
        }

        // POST: lieux/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,titre,description,coordonneesMaps,rue,code_postal,ville,pays,telephone,urlPhoto,siteWeb")] lieu lieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lieu);
        }

        // GET: lieux/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lieu lieu = db.lieu.Find(id);
            if (lieu == null)
            {
                return HttpNotFound();
            }
            return View(lieu);
        }

        // POST: lieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lieu lieu = db.lieu.Find(id);
            db.lieu.Remove(lieu);
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
