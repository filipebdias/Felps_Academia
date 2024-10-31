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
    public class InstrutorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Instrutors
        public ActionResult Index()
        {
            return View(db.Instrutors.ToList());
        }

        // GET: Instrutors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrutor instrutor = db.Instrutors.Find(id);
            if (instrutor == null)
            {
                return HttpNotFound();
            }
            return View(instrutor);
        }

        // GET: Instrutors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instrutors/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Especialidade")] Instrutor instrutor)
        {
            if (ModelState.IsValid)
            {
                db.Instrutors.Add(instrutor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instrutor);
        }

        // GET: Instrutors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrutor instrutor = db.Instrutors.Find(id);
            if (instrutor == null)
            {
                return HttpNotFound();
            }
            return View(instrutor);
        }

        // POST: Instrutors/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Especialidade")] Instrutor instrutor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instrutor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instrutor);
        }

        // GET: Instrutors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrutor instrutor = db.Instrutors.Find(id);
            if (instrutor == null)
            {
                return HttpNotFound();
            }
            return View(instrutor);
        }

        // POST: Instrutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instrutor instrutor = db.Instrutors.Find(id);
            db.Instrutors.Remove(instrutor);
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
