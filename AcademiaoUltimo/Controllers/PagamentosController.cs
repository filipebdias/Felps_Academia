using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AcademiaoUltimo.Models;
using Microsoft.AspNet.Identity;

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
        public ActionResult Details(int id)
        {
            var pagamento = db.Pagamentoes.Include(p => p.Plano).Include(p => p.Usuario)
                                   .FirstOrDefault(p => p.Id == id); // Certifique-se de que o nome da propriedade está correto

            if (pagamento == null)
            {
                return HttpNotFound(); // Isso deve retornar uma página 404 se o pagamento não for encontrado
            }

            return View(pagamento);
        }

        // GET: Pagamentos/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome"); // Certifique-se de que "Id" e "Nome" estão corretos
            ViewBag.PlanoId = new SelectList(db.Planoes, "Id", "Nome"); // O mesmo se aplica aos planos
            return View();
        }

        // POST: Pagamentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlanoId, UsuarioId")] Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                // Define a data do pagamento
                pagamento.DataPagamento = DateTime.Now;

                var userIdString = User.Identity.GetUserId();
                if (int.TryParse(userIdString, out int userId))
                {
                    pagamento.UsuarioId = userId; // Define o UsuarioId
                }
                else
                {
                    ModelState.AddModelError("", "Usuário não encontrado ou ID de usuário inválido.");
                }

                db.Pagamentoes.Add(pagamento);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            // Repreencher o ViewBag em caso de erro de validação
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", pagamento.UsuarioId); // Ocorre aqui
            ViewBag.PlanoId = new SelectList(db.Planoes, "Id", "Nome", pagamento.PlanoId); // Ocorre aqui
            return View(pagamento);
        }


        // GET: Pagamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            // Obtenha o pagamento que você está editando
            var pagamento = db.Pagamentoes.Find(id); // Altere conforme sua estrutura de dados
            if (pagamento == null)
            {
                return HttpNotFound();
            }

            // Preencher o ViewBag com a lista de usuários para o dropdown
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", pagamento.UsuarioId); // Ajuste conforme seu modelo
            ViewBag.PlanoId = new SelectList(db.Planoes, "Id", "Nome", pagamento.PlanoId); // Faça o mesmo para planos

            return View(pagamento);
        }

        // POST: Pagamentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PlanoId,UsuarioId,DataPagamento")] Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                var pagamentoExistente = db.Pagamentoes.Find(pagamento.Id);
                if (pagamentoExistente != null)
                {
                    pagamentoExistente.PlanoId = pagamento.PlanoId;
                    pagamentoExistente.DataPagamento = DateTime.Now; // Atualiza a data do pagamento
                    var userIdString = User.Identity.GetUserId();

                    if (int.TryParse(userIdString, out int userId))
                    {
                        pagamentoExistente.UsuarioId = userId; // Mantém o UsuarioId
                    }
                    else
                    {
                        ModelState.AddModelError("", "Usuário não encontrado ou ID de usuário inválido.");
                        ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", pagamento.UsuarioId); // Preencher o ViewBag novamente
                        ViewBag.PlanoId = new SelectList(db.Planoes, "Id", "Nome", pagamento.PlanoId);
                        return View(pagamento);
                    }

                    db.Entry(pagamentoExistente).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return HttpNotFound("Pagamento não encontrado.");
                }
            }

            // Caso ModelState não seja válido, reabasteça o ViewBag
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", pagamento.UsuarioId);
            ViewBag.PlanoId = new SelectList(db.Planoes, "Id", "Nome", pagamento.PlanoId);
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
