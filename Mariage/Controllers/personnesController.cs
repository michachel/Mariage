﻿using System;
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
    public class personnesController : Controller
    {
        private ckaeyah101694fr24274_mariageEntities db = new ckaeyah101694fr24274_mariageEntities();

        // GET: personnes
        public ActionResult Index()
        {
            List<personne> personnes = db.personne.ToList();

            foreach (personne p in personnes)
            {
                var conjoint = db.personne.Find(p.idConjoint);
                var parent = db.personne.Find(p.idParent);
                p.nomPrenomConjoint = conjoint== null? "Aucun": conjoint.nomPrenom;
                p.nomPrenomParent = parent == null ? "Aucun": parent.nomPrenom;
            }

            return View(personnes);
        }

        // GET: personnes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personne personne = db.personne.Find(id);
            if (personne == null)
            {
                return HttpNotFound();
            }
            return View(personne);
        }

        // GET: personnes/Create
        public ActionResult Create()
        {
            
            List<SelectListItem> listeGenres = new List<SelectListItem>() { new SelectListItem() { Text = "Femme", Value = "F" }, new SelectListItem() { Text = "Homme", Value = "H" } };
            
            ViewBag.idConjoint = new SelectList(db.personne, "id", "nomPrenom");
            ViewBag.idParent = new SelectList(db.personne, "id", "nomPrenom");
            ViewBag.Genres = listeGenres;

            return View();
        }
        

        // POST: personnes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom,prenom,idConjoint,genre,idParent,validation,urlPhoto,email")] personne personne)
        {
            if (ModelState.IsValid)
            {
                db.personne.Add(personne);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personne);
        }

        // GET: personnes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personne personne = db.personne.Find(id);
            if (personne == null)
            {
                return HttpNotFound();
            }
            List<String> listeGenre = new List<string>();
            listeGenre.Add("Femme");
            listeGenre.Add("Homme");
            

            List<SelectListItem> listeGenres = new List<SelectListItem>() { new SelectListItem() { Text = "Femme", Value = "F" }, new SelectListItem() { Text = "Homme", Value = "H" } };

            ViewBag.idConjoint = new SelectList(db.personne, "id", "nomPrenom", personne.idConjoint);
            ViewBag.idParent = new SelectList(db.personne, "id", "nomPrenom",personne.idParent);
            ViewBag.Genres = listeGenres;

            return View(personne);
        }

        // POST: personnes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,prenom,idConjoint,genre,idParent,validation,urlPhoto,email")] personne personne)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personne).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personne);
        }

        // GET: personnes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personne personne = db.personne.Find(id);
            if (personne == null)
            {
                return HttpNotFound();
            }
            return View(personne);
        }

        // POST: personnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            personne personne = db.personne.Find(id);
            db.personne.Remove(personne);
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
