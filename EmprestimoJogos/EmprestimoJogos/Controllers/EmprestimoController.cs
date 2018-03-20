using EmprestimoJogos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EmprestimoJogos.Controllers
{
    [Authorize]
    public class EmprestimoController : Controller
    {
        private EmprestimoJogosEntities db = new EmprestimoJogosEntities();

        // GET: Emprestimo
        public ActionResult Index()
        {
            IList<Emprestimo> emprestimos = db.Emprestimos.ToList();

            foreach (var emprestimo in emprestimos)
            {
                Amigo amigo = db.Amigos.Find(emprestimo.IdAmigo);
                if (amigo != null)
                {
                    emprestimos[emprestimos.IndexOf(emprestimo)].Amigo = amigo;
                }

                Jogo jogo = db.Jogos.Find(emprestimo.IdJogo);
                if (jogo != null)
                {
                    emprestimos[emprestimos.IndexOf(emprestimo)].Jogo = jogo;
                }
            }

            return View(emprestimos);
        }

        // GET: Emprestimo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }

            Amigo amigo = db.Amigos.Find(emprestimo.IdAmigo);
            if (amigo != null)
            {
                emprestimo.Amigo = amigo;
            }

            Jogo jogo = db.Jogos.Find(emprestimo.IdJogo);
            if (jogo != null)
            {
                emprestimo.Jogo = jogo;
            }

            return View(emprestimo);
        }

        // GET: Emprestimo/Create
        public ActionResult Create()
        {
            ViewBag.Amigos = new SelectList(db.Amigos, "IdAmigo", "Nome");
            ViewBag.Jogos = new SelectList(db.Jogos, "IdJogo", "Nome");

            return View();
        }

        // POST: Emprestimo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmprestimo,IdAmigo,IdJogo,DataEmprestimo")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                db.Emprestimos.Add(emprestimo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emprestimo);
        }

        // GET: Emprestimo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }

            Amigo amigo = db.Amigos.Find(emprestimo.IdAmigo);
            if (amigo != null)
            {
                emprestimo.Amigo = amigo;
            }

            Jogo jogo = db.Jogos.Find(emprestimo.IdJogo);
            if (jogo != null)
            {
                emprestimo.Jogo = jogo;
            }

            ViewBag.Amigos = new SelectList(db.Amigos, "IdAmigo", "Nome");
            ViewBag.Jogos = new SelectList(db.Jogos, "IdJogo", "Nome");

            return View(emprestimo);
        }

        // POST: Emprestimo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmprestimo,IdAmigo,IdJogo,DataEmprestimo")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emprestimo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emprestimo);
        }

        // GET: Emprestimo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }

            Amigo amigo = db.Amigos.Find(emprestimo.IdAmigo);
            if (amigo != null)
            {
                emprestimo.Amigo = amigo;
            }

            Jogo jogo = db.Jogos.Find(emprestimo.IdJogo);
            if (jogo != null)
            {
                emprestimo.Jogo = jogo;
            }

            return View(emprestimo);
        }

        // POST: Emprestimo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            db.Emprestimos.Remove(emprestimo);
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
