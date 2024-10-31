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
    public class TreinosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Treinos
        public ActionResult Index()
        {
            var treinoes = db.Treinoes.Include(t => t.Usuario);
            return View(treinoes.ToList());
        }

        // GET: Treinos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treino treino = db.Treinoes.Find(id);
            if (treino == null)
            {
                return HttpNotFound();
            }
            return View(treino);
        }

        // GET: Treinos/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome");
            return View();
        }

        // POST: Treinos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,DataTreino,UsuarioId")] Treino treino)
        {
            if (ModelState.IsValid)
            {
                db.Treinoes.Add(treino);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", treino.UsuarioId);
            return View(treino);
        }

        // GET: Treinos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treino treino = db.Treinoes.Find(id);
            if (treino == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", treino.UsuarioId);
            return View(treino);
        }

        // POST: Treinos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,DataTreino,UsuarioId")] Treino treino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treino).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", treino.UsuarioId);
            return View(treino);
        }

        // GET: Treinos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treino treino = db.Treinoes.Find(id);
            if (treino == null)
            {
                return HttpNotFound();
            }
            return View(treino);
        }

        // POST: Treinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Treino treino = db.Treinoes.Find(id);
            db.Treinoes.Remove(treino);
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
