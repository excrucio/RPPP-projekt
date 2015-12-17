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
    public class VrstaSpisaController : Controller
    {
        private RPPP10 db = new RPPP10();

        // GET: /VrstaSpisa/
        public ActionResult Index()
        {
            return View(db.VrstaSpisa.ToList());
        }

        // GET: /VrstaSpisa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VrstaSpisa vrstaspisa = db.VrstaSpisa.Find(id);
            if (vrstaspisa == null)
            {
                return HttpNotFound();
            }
            return View(vrstaspisa);
        }

        // GET: /VrstaSpisa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /VrstaSpisa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SifraVrste,NazivVrste")] VrstaSpisa vrstaspisa)
        {
            if (ModelState.IsValid)
            {
                db.VrstaSpisa.Add(vrstaspisa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vrstaspisa);
        }

        // GET: /VrstaSpisa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VrstaSpisa vrstaspisa = db.VrstaSpisa.Find(id);
            if (vrstaspisa == null)
            {
                return HttpNotFound();
            }
            return View(vrstaspisa);
        }

        // POST: /VrstaSpisa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SifraVrste,NazivVrste")] VrstaSpisa vrstaspisa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vrstaspisa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vrstaspisa);
        }

        // GET: /VrstaSpisa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VrstaSpisa vrstaspisa = db.VrstaSpisa.Find(id);
            if (vrstaspisa == null)
            {
                return HttpNotFound();
            }
            return View(vrstaspisa);
        }

        // POST: /VrstaSpisa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VrstaSpisa vrstaspisa = db.VrstaSpisa.Find(id);
            db.VrstaSpisa.Remove(vrstaspisa);
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
