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
    public class LocalidadeController : Controller
    {
        private EmprestimoJogosEntities db = new EmprestimoJogosEntities();

        // GET: Localidade
        public ActionResult Index()
        {
            return View(db.Localidades.ToList());
        }

        // GET: Localidade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidade localidade = db.Localidades.Find(id);
            if (localidade == null)
            {
                return HttpNotFound();
            }
            return View(localidade);
        }

        // GET: Localidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Localidade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLocalidade,Nome")] Localidade localidade)
        {
            if (ModelState.IsValid)
            {
                db.Localidades.Add(localidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(localidade);
        }

        // GET: Localidade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidade localidade = db.Localidades.Find(id);
            if (localidade == null)
            {
                return HttpNotFound();
            }
            return View(localidade);
        }

        // POST: Localidade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLocalidade,Nome")] Localidade localidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(localidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(localidade);
        }

        // GET: Localidade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidade localidade = db.Localidades.Find(id);
            if (localidade == null)
            {
                return HttpNotFound();
            }
            return View(localidade);
        }

        // POST: Localidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Localidade localidade = db.Localidades.Find(id);
                db.Localidades.Remove(localidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                Exception erro = new Exception("Relacionamento entre cadastros não permite a remoção do cadastro atual.");
                return View("~/views/shared/error.cshtml", new HandleErrorInfo(erro, "Localidade", "Delete"));
            }
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
