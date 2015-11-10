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
    public class hebergementsController : Controller
    {
        private ckaeyah101694fr24274_mariageEntities db = new ckaeyah101694fr24274_mariageEntities();

        // GET: hebergements
        public ActionResult Index()
        {
            var hebergement = db.hebergement.Include(h => h.lieu);
            return View(hebergement.ToList());
        }

        // GET: hebergements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hebergement hebergement = db.hebergement.Find(id);
            if (hebergement == null)
            {
                return HttpNotFound();
            }
            return View(hebergement);
        }

        // GET: hebergements/Create
        public ActionResult Create()
        {
            ViewBag.idLieu = new SelectList(db.lieu, "id", "titre");
            return View();
        }

        // POST: hebergements/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,titre,description,idLieu,prix,estOffert,debutOffert,finOffert")] hebergement hebergement)
        {
            if (ModelState.IsValid)
            {
                db.hebergement.Add(hebergement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idLieu = new SelectList(db.lieu, "id", "titre", hebergement.idLieu);
            return View(hebergement);
        }

        // GET: hebergements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hebergement hebergement = db.hebergement.Find(id);
            if (hebergement == null)
            {
                return HttpNotFound();
            }
            ViewBag.idLieu = new SelectList(db.lieu, "id", "titre", hebergement.idLieu);
            return View(hebergement);
        }

        // POST: hebergements/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,titre,description,idLieu,prix,estOffert,debutOffert,finOffert")] hebergement hebergement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hebergement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idLieu = new SelectList(db.lieu, "id", "titre", hebergement.idLieu);
            return View(hebergement);
        }

        // GET: hebergements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hebergement hebergement = db.hebergement.Find(id);
            if (hebergement == null)
            {
                return HttpNotFound();
            }
            return View(hebergement);
        }

        // POST: hebergements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hebergement hebergement = db.hebergement.Find(id);
            db.hebergement.Remove(hebergement);
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
