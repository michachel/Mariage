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
    public class etapesController : Controller
    {
        private ckaeyah101694fr24274_mariageEntities db = new ckaeyah101694fr24274_mariageEntities();

        // GET: etapes
        public ActionResult Index()
        {
            var etape = db.etape.Include(e => e.etape2).Include(e => e.lieu);
            return View(etape.ToList());
        }

        // GET: etapes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            etape etape = db.etape.Find(id);
            if (etape == null)
            {
                return HttpNotFound();
            }
            return View(etape);
        }

        // GET: etapes/Create
        public ActionResult Create()
        {
            ViewBag.idEtapePrecedente = new SelectList(db.etape, "id", "titre");
            ViewBag.idLieu = new SelectList(db.lieu, "id", "titre");
            return View();
        }

        // POST: etapes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,titre,description,debut,fin,idEtapePrecedente,idLieu")] etape etape)
        {
            if (ModelState.IsValid)
            {
                db.etape.Add(etape);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEtapePrecedente = new SelectList(db.etape, "id", "titre", etape.idEtapePrecedente);
            ViewBag.idLieu = new SelectList(db.lieu, "id", "titre", etape.idLieu);
            return View(etape);
        }

        // GET: etapes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            etape etape = db.etape.Find(id);
            if (etape == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEtapePrecedente = new SelectList(db.etape, "id", "titre", etape.idEtapePrecedente);
            ViewBag.idLieu = new SelectList(db.lieu, "id", "titre", etape.idLieu);
            return View(etape);
        }

        // POST: etapes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,titre,description,debut,fin,idEtapePrecedente,idLieu")] etape etape)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etape).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEtapePrecedente = new SelectList(db.etape, "id", "titre", etape.idEtapePrecedente);
            ViewBag.idLieu = new SelectList(db.lieu, "id", "titre", etape.idLieu);
            return View(etape);
        }

        // GET: etapes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            etape etape = db.etape.Find(id);
            if (etape == null)
            {
                return HttpNotFound();
            }
            return View(etape);
        }

        // POST: etapes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            etape etape = db.etape.Find(id);
            db.etape.Remove(etape);
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
