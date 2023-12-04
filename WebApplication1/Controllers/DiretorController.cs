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
    public class DiretorController : Controller
    {
        private etec2023GassnerEntities db = new etec2023GassnerEntities();

        // GET: Diretor
        public ActionResult Index()
        {
            return View(db.tb_diretor.ToList());
        }

        // GET: Diretor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_diretor tb_diretor = db.tb_diretor.Find(id);
            if (tb_diretor == null)
            {
                return HttpNotFound();
            }
            return View(tb_diretor);
        }

        // GET: Diretor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diretor/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Idade,Oscar")] tb_diretor tb_diretor)
        {
            if (ModelState.IsValid)
            {
                db.tb_diretor.Add(tb_diretor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_diretor);
        }

        // GET: Diretor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_diretor tb_diretor = db.tb_diretor.Find(id);
            if (tb_diretor == null)
            {
                return HttpNotFound();
            }
            return View(tb_diretor);
        }

        // POST: Diretor/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Idade,Oscar")] tb_diretor tb_diretor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_diretor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_diretor);
        }

        // GET: Diretor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_diretor tb_diretor = db.tb_diretor.Find(id);
            if (tb_diretor == null)
            {
                return HttpNotFound();
            }
            return View(tb_diretor);
        }

        // POST: Diretor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_diretor tb_diretor = db.tb_diretor.Find(id);
            db.tb_diretor.Remove(tb_diretor);
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
