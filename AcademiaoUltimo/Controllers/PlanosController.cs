using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AcademiaoUltimo.Models;

namespace AcademiaoUltimo.Controllers
{
    public class PlanosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Planos
        public ActionResult Index()
        {
            return View(db.Planoes.ToList());
        }

        // GET: Planos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plano plano = db.Planoes.Find(id);
            if (plano == null)
            {
                return HttpNotFound();
            }
            return View(plano);
        }

        // GET: Planos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Planos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Preco,Descricao")] Plano plano)
        {
            if (ModelState.IsValid)
            {
                db.Planoes.Add(plano);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plano);
        }

        // GET: Planos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plano plano = db.Planoes.Find(id);
            if (plano == null)
            {
                return HttpNotFound();
            }
            return View(plano);
        }

        // POST: Planos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Preco,Descricao")] Plano plano)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plano).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plano);
        }

        // GET: Planos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plano plano = db.Planoes.Find(id);
            if (plano == null)
            {
                return HttpNotFound();
            }
            return View(plano);
        }

        // POST: Planos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plano plano = db.Planoes.Find(id);
            db.Planoes.Remove(plano);
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
