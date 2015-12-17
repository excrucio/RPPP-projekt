using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.EF;

namespace ManuelaKajkara.Controllers
{
    public class PresudeController : Controller
    {
        private RPPP10 db = new RPPP10();

        // GET: /Presude/
        public ActionResult Index()
        {
            var presuda = db.Presuda.Include(p => p.TipPresude1);
            return View(presuda.ToList());
        }

        // GET: /Presude/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAL.EF.Presuda presuda = db.Presuda.Find(id);
            if (presuda == null)
            {
                return HttpNotFound();
            }
            return View(presuda);
        }

        // GET: /Presude/Create
        public ActionResult Create()
        {
            ViewBag.TipPresude = new SelectList(db.TipPresude, "SifraTipa", "NazivTipa");
            return View();
        }

        // POST: /Presude/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDStavke,Dokument,TipPresude")] DAL.EF.Presuda presuda)
        {
            if (ModelState.IsValid)
            {
                db.Presuda.Add(presuda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipPresude = new SelectList(db.TipPresude, "SifraTipa", "NazivTipa", presuda.TipPresude);
            return View(presuda);
        }

        // GET: /Presude/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAL.EF.Presuda presuda = db.Presuda.Find(id);
            if (presuda == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipPresude = new SelectList(db.TipPresude, "SifraTipa", "NazivTipa", presuda.TipPresude);
            return View(presuda);
        }

        // POST: /Presude/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDStavke,Dokument,TipPresude")] DAL.EF.Presuda presuda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(presuda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipPresude = new SelectList(db.TipPresude, "SifraTipa", "NazivTipa", presuda.TipPresude);
            return View(presuda);
        }

        // GET: /Presude/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAL.EF.Presuda presuda = db.Presuda.Find(id);
            if (presuda == null)
            {
                return HttpNotFound();
            }
            return View(presuda);
        }

        // POST: /Presude/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DAL.EF.Presuda presuda = db.Presuda.Find(id);
            db.Presuda.Remove(presuda);
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
