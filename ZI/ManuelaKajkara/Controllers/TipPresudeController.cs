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
    public class TipPresudeController : Controller
    {
        private RPPP10 db = new RPPP10();

        // GET: /TipPresude/
        public ActionResult Index()
        {
            return View(db.TipPresude.ToList());
        }

        // GET: /TipPresude/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipPresude tippresude = db.TipPresude.Find(id);
            if (tippresude == null)
            {
                return HttpNotFound();
            }
            return View(tippresude);
        }

        // GET: /TipPresude/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipPresude/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SifraTipa,NazivTipa")] TipPresude tippresude)
        {
            if (ModelState.IsValid)
            {
                db.TipPresude.Add(tippresude);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tippresude);
        }

        // GET: /TipPresude/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipPresude tippresude = db.TipPresude.Find(id);
            if (tippresude == null)
            {
                return HttpNotFound();
            }
            return View(tippresude);
        }

        // POST: /TipPresude/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SifraTipa,NazivTipa")] TipPresude tippresude)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tippresude).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tippresude);
        }

        // GET: /TipPresude/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipPresude tippresude = db.TipPresude.Find(id);
            if (tippresude == null)
            {
                return HttpNotFound();
            }
            return View(tippresude);
        }

        // POST: /TipPresude/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipPresude tippresude = db.TipPresude.Find(id);
            db.TipPresude.Remove(tippresude);
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
