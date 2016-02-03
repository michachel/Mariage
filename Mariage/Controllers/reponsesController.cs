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
    public class reponsesController : Controller
    {
        private ckaeyah101694fr24274_mariageEntities db = new ckaeyah101694fr24274_mariageEntities();

        // GET: reponses
        public ActionResult Index()
        {
            return View(db.reponse.ToList());
        }

        // GET: reponses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reponse reponse = db.reponse.Find(id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            return View(reponse);
        }

        public ActionResult Succes()
        {
            return View();
        }

        // GET: reponses/Create
        public ActionResult Create()
        {

            List<SelectListItem> listeModeTransport = new List<SelectListItem>() {  new SelectListItem() { Text = "Je préfère rester en voiture !", Value = "voiture" },
                                                                                    new SelectListItem() { Text = "Bus offert par les mariés", Value = "bus" },
                                                                                    new SelectListItem() { Text = "Tout me va, tant que l'on ne m'oublie pas !", Value = "Tout" } };

            List<SelectListItem> listeArriveeTransport = new List<SelectListItem>() {  new SelectListItem() { Text = "Avion ou jet privé", Value = "Avion" },
                                                                                    new SelectListItem() { Text = "Voiture", Value = "Voiture" },
                                                                                    new SelectListItem() { Text = "Train", Value = "Train" },
                                                                                    new SelectListItem() { Text = "Je suis sur place", Value = "Je suis sur place" } };

            List<SelectListItem> listeCouchage = new List<SelectListItem>() {  new SelectListItem() { Text = "Hôtel offert par les mariés", Value = "Hôtel offert" },
                                                                                    new SelectListItem() { Text = "Hôtel non offert par les mariés", Value = "Hôtel non offert par les mariés" },
                                                                                    new SelectListItem() { Text = "Autre", Value = "Autre" } };

            ViewBag.modeTransport = listeModeTransport;
            ViewBag.arriveeTransport = listeArriveeTransport;
            ViewBag.hotelSamediSoir = listeCouchage;

            return View();
        }

        // POST: reponses/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,listeParticipants,modeTransport,arriveeTransport,dateArrivee,commentaires,hotelSamediSoir")] reponse reponse)
        {
                if (ModelState.IsValid)
            {
                db.reponse.Add(reponse);
                db.SaveChanges();
                return RedirectToAction("succes");
            }

            return View(reponse);
        }

        // GET: reponses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reponse reponse = db.reponse.Find(id);
            if (reponse == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> listeModeTransport = new List<SelectListItem>() {  new SelectListItem() { Text = "Je préfère rester en voiture !", Value = "voiture" },
                                                                                    new SelectListItem() { Text = "Bus offert par les mariés", Value = "bus" },
                                                                                    new SelectListItem() { Text = "Tout me va, tant que l'on ne m'oublie pas !", Value = "Tout" } };

            List<SelectListItem> listeArriveeTransport = new List<SelectListItem>() {  new SelectListItem() { Text = "Avion ou jet privé", Value = "Avion" },
                                                                                    new SelectListItem() { Text = "Voiture", Value = "Voiture" },
                                                                                    new SelectListItem() { Text = "Train", Value = "Train" },
                                                                                    new SelectListItem() { Text = "Je suis sur place", Value = "Je suis sur place" } };

            List<SelectListItem> listeCouchage = new List<SelectListItem>() {  new SelectListItem() { Text = "Hôtel offert par les mariés", Value = "Hôtel offert" },
                                                                                    new SelectListItem() { Text = "Hôtel non offert par les mariés", Value = "Hôtel non offert par les mariés" },
                                                                                    new SelectListItem() { Text = "Autre", Value = "Autre" } };

            ViewBag.modeTransport = listeModeTransport;
            ViewBag.arriveeTransport = listeArriveeTransport;
            ViewBag.hotelSamediSoir = listeCouchage;

            return View(reponse);
        }

        // POST: reponses/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,listeParticipants,modeTransport,arriveeTransport,dateArrivee,commentaires,hotelSamediSoir")] reponse reponse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reponse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reponse);
        }

        // GET: reponses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reponse reponse = db.reponse.Find(id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            return View(reponse);
        }

        // POST: reponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reponse reponse = db.reponse.Find(id);
            db.reponse.Remove(reponse);
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
