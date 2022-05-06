using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using ORM;

namespace api.Controllers
{
    public class transacsController : Controller
    {
        private Model1 db = new Model1();

        // GET: transacs
        public ActionResult Index()
        {
            var transac = db.transac.Include(t => t.compte).Include(t => t.type);
            return View(transac.ToList());
        }

        // GET: transacs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transac transac = db.transac.Find(id);
            if (transac == null)
            {
                return HttpNotFound();
            }
            return View(transac);
        }

        // GET: transacs/Create
        public ActionResult Create()
        {
            ViewBag.compte_id = new SelectList(db.compte, "id", "libelle");
            ViewBag.type_id = new SelectList(db.type, "id", "type1");
            return View();
        }

        // POST: transacs/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,type_id,compte_id")] transac transac)
        {
            if (ModelState.IsValid)
            {
                db.transac.Add(transac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.compte_id = new SelectList(db.compte, "id", "libelle", transac.compte_id);
            ViewBag.type_id = new SelectList(db.type, "id", "type1", transac.type_id);
            return View(transac);
        }

        // GET: transacs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transac transac = db.transac.Find(id);
            if (transac == null)
            {
                return HttpNotFound();
            }
            ViewBag.compte_id = new SelectList(db.compte, "id", "libelle", transac.compte_id);
            ViewBag.type_id = new SelectList(db.type, "id", "type1", transac.type_id);
            return View(transac);
        }

        // POST: transacs/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type_id,compte_id")] transac transac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.compte_id = new SelectList(db.compte, "id", "libelle", transac.compte_id);
            ViewBag.type_id = new SelectList(db.type, "id", "type1", transac.type_id);
            return View(transac);
        }

        // GET: transacs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transac transac = db.transac.Find(id);
            if (transac == null)
            {
                return HttpNotFound();
            }
            return View(transac);
        }

        // POST: transacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            transac transac = db.transac.Find(id);
            db.transac.Remove(transac);
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
