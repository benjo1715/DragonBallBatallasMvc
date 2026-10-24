using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DragonBallBatallasMvc.Models;

namespace DragonBallBatallasMvc.Controllers
{
    public class BatallasController : Controller
    {
        private DragonBallDbContext db = new DragonBallDbContext();

        // GET: Batallas
        public ActionResult Index()
        {
            var batallas = db.Batallas.Include(b => b.Guerrero);
            return View(batallas.ToList());
        }

        // GET: Batallas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batalla batalla = db.Batallas.Find(id);
            if (batalla == null)
            {
                return HttpNotFound();
            }
            return View(batalla);
        }

        // GET: Batallas/Create
        public ActionResult Create()
        {
            ViewBag.GuerreroId = new SelectList(db.Guerreros, "GuerreroId", "Nombre");
            return View();
        }

        // POST: Batallas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BatallaId,Titulo,Enemigo,Resultado,GuerreroId")] Batalla batalla)
        {
            if (ModelState.IsValid)
            {
                db.Batallas.Add(batalla);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GuerreroId = new SelectList(db.Guerreros, "GuerreroId", "Nombre", batalla.GuerreroId);
            return View(batalla);
        }

        // GET: Batallas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batalla batalla = db.Batallas.Find(id);
            if (batalla == null)
            {
                return HttpNotFound();
            }
            ViewBag.GuerreroId = new SelectList(db.Guerreros, "GuerreroId", "Nombre", batalla.GuerreroId);
            return View(batalla);
        }

        // POST: Batallas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BatallaId,Titulo,Enemigo,Resultado,GuerreroId")] Batalla batalla)
        {
            if (ModelState.IsValid)
            {
                db.Entry(batalla).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GuerreroId = new SelectList(db.Guerreros, "GuerreroId", "Nombre", batalla.GuerreroId);
            return View(batalla);
        }

        // GET: Batallas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batalla batalla = db.Batallas.Find(id);
            if (batalla == null)
            {
                return HttpNotFound();
            }
            return View(batalla);
        }

        // POST: Batallas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Batalla batalla = db.Batallas.Find(id);
            db.Batallas.Remove(batalla);
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
