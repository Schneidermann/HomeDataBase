using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BackEndHome.Models;
using BackEndHome.Models.Contexto;

namespace BackEndHome
{
    public class DadosController : Controller
    {
        private MeuContexto db = new MeuContexto();

        // GET: Dados
        public ActionResult Index()
        {
            return View(db.Dados.ToList());
        }

        // GET: Dados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dados dados = db.Dados.Find(id);
            if (dados == null)
            {
                return HttpNotFound();
            }
            return View(dados);
        }

        // GET: Dados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dados/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DadosID,Nome,Descricao,Poligonos,Tamanho")] Dados dados)
        {
            if (ModelState.IsValid)
            {
                db.Dados.Add(dados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dados);
        }

        // GET: Dados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dados dados = db.Dados.Find(id);
            if (dados == null)
            {
                return HttpNotFound();
            }
            return View(dados);
        }

        // POST: Dados/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DadosID,Nome,Descricao,Poligonos,Tamanho")] Dados dados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dados);
        }

        // GET: Dados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dados dados = db.Dados.Find(id);
            if (dados == null)
            {
                return HttpNotFound();
            }
            return View(dados);
        }

        // POST: Dados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dados dados = db.Dados.Find(id);
            db.Dados.Remove(dados);
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
