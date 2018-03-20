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
    public class AmigoController : Controller
    {
        private EmprestimoJogosEntities db = new EmprestimoJogosEntities();

        // GET: Amigo
        public ActionResult Index()
        {
            IList<Amigo> amigos = db.Amigos.ToList();

            foreach (var amigo in amigos)
            {
                Localidade localidade = db.Localidades.Find(amigo.IdLocalidade);
                if (localidade != null)
                {
                    amigos[amigos.IndexOf(amigo)].Localidade = localidade;
                }
            }

            return View(amigos);
        }

        // GET: Amigo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amigo amigo = db.Amigos.Find(id);
            if (amigo == null)
            {
                return HttpNotFound();
            }

            Localidade localidade = db.Localidades.Find(amigo.IdLocalidade);
            if (localidade != null)
            {
                amigo.Localidade = localidade;
            }

            return View(amigo);
        }

        // GET: Amigo/Create
        public ActionResult Create()
        {
            ViewBag.Localidades = new SelectList(db.Localidades, "IdLocalidade", "Nome");

            return View();
        }

        // POST: Amigo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAmigo,Nome,IdLocalidade")] Amigo amigo)
        {
            if (ModelState.IsValid)
            {
                db.Amigos.Add(amigo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(amigo);
        }

        // GET: Amigo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.Localidades = new SelectList(db.Localidades, "IdLocalidade", "Nome");

            Amigo amigo = db.Amigos.Find(id);
            if (amigo == null)
            {
                return HttpNotFound();
            }

            Localidade localidade = db.Localidades.Find(amigo.IdLocalidade);
            if (localidade != null)
            {
                amigo.Localidade = localidade;
            }

            return View(amigo);
        }

        // POST: Amigo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAmigo,Nome,IdLocalidade")] Amigo amigo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(amigo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(amigo);
        }

        // GET: Amigo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amigo amigo = db.Amigos.Find(id);
            if (amigo == null)
            {
                return HttpNotFound();
            }

            Localidade localidade = db.Localidades.Find(amigo.IdLocalidade);
            if (localidade != null)
            {
                amigo.Localidade = localidade;
            }

            return View(amigo);
        }

        // POST: Amigo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Amigo amigo = db.Amigos.Find(id);
            db.Amigos.Remove(amigo);
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
