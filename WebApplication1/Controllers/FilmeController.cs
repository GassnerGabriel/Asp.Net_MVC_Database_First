using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FilmeController : Controller
    {
        private etec2023GassnerEntities db = new etec2023GassnerEntities();

        // GET: Filme
        public ActionResult Index()
        {
            var tb_filme = db.tb_filme.Include(t => t.tb_diretor);
            return View(tb_filme.ToList());
        }

        // GET: Filme/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_filme tb_filme = db.tb_filme.Find(id);
            if (tb_filme == null)
            {
                return HttpNotFound();
            }
            return View(tb_filme);
        }

        // GET: Filme/Create
        public ActionResult Create()
        {
            ViewBag.Diretor = new SelectList(db.tb_diretor, "Id", "Nome");
            return View();
        }

        // POST: Filme/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Lancamento,Nota,Diretor")] tb_filme tb_filme)
        {
            if (ModelState.IsValid)
            {
                db.tb_filme.Add(tb_filme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Diretor = new SelectList(db.tb_diretor, "Id", "Nome", tb_filme.Diretor);
            return View(tb_filme);
        }

        // GET: Filme/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_filme tb_filme = db.tb_filme.Find(id);
            if (tb_filme == null)
            {
                return HttpNotFound();
            }
            ViewBag.Diretor = new SelectList(db.tb_diretor, "Id", "Nome", tb_filme.Diretor);
            return View(tb_filme);
        }

        // POST: Filme/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Lancamento,Nota,Diretor")] tb_filme tb_filme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_filme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Diretor = new SelectList(db.tb_diretor, "Id", "Nome", tb_filme.Diretor);
            return View(tb_filme);
        }

        // GET: Filme/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_filme tb_filme = db.tb_filme.Find(id);
            if (tb_filme == null)
            {
                return HttpNotFound();
            }
            return View(tb_filme);
        }

        // POST: Filme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_filme tb_filme = db.tb_filme.Find(id);
            db.tb_filme.Remove(tb_filme);
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
