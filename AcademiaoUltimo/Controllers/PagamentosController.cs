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
    public class PagamentosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pagamentos
        public ActionResult Index()
        {
            var pagamentoes = db.Pagamentoes.Include(p => p.Plano).Include(p => p.Usuario);
            return View(pagamentoes.ToList());
        }

        // GET: Pagamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamento pagamento = db.Pagamentoes.Find(id);
            if (pagamento == null)
            {
                return HttpNotFound();
            }
            return View(pagamento);
        }

        // GET: Pagamentos/Create
        public ActionResult Create()
        {
            ViewBag.PlanoId = new SelectList(db.Planoes, "Id", "Nome");
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome");
            return View();
        }

        // POST: Pagamentos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UsuarioId,PlanoId,DataPagamento")] Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                db.Pagamentoes.Add(pagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlanoId = new SelectList(db.Planoes, "Id", "Nome", pagamento.PlanoId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", pagamento.UsuarioId);
            return View(pagamento);
        }

        // GET: Pagamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamento pagamento = db.Pagamentoes.Find(id);
            if (pagamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlanoId = new SelectList(db.Planoes, "Id", "Nome", pagamento.PlanoId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", pagamento.UsuarioId);
            return View(pagamento);
        }

        // POST: Pagamentos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UsuarioId,PlanoId,DataPagamento")] Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlanoId = new SelectList(db.Planoes, "Id", "Nome", pagamento.PlanoId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", pagamento.UsuarioId);
            return View(pagamento);
        }

        // GET: Pagamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamento pagamento = db.Pagamentoes.Find(id);
            if (pagamento == null)
            {
                return HttpNotFound();
            }
            return View(pagamento);
        }

        // POST: Pagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pagamento pagamento = db.Pagamentoes.Find(id);
            db.Pagamentoes.Remove(pagamento);
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
