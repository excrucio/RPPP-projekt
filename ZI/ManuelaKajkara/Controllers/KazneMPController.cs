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
    public class KazneMPController : Controller
    {
        private RPPP10 db = new RPPP10();

        // GET: /KazneMP/
        public ActionResult Index()
        {
            var kazna = db.Kazna.Include(k => k.Osoba).Include(k => k.TipPresude).Include(k => k.VrstaKazne);
            return View(kazna.ToList());
        }

        // GET: /KazneMP/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAL.EF.Kazna kazna = db.Kazna.Find(id);
            if (kazna == null)
            {
                return HttpNotFound();
            }
            return View(kazna);
        }

        // GET: /KazneMP/Create
        public ActionResult Create()
        {
            ViewBag.IDOsobe = new SelectList(db.Osoba, "IDOsobe", "OIB");
            ViewBag.IDPresude = new SelectList(db.TipPresude, "SifraTipa", "NazivTipa");
            ViewBag.Vrsta = new SelectList(db.VrstaKazne, "SifraVrste", "NazivVrste");
            return View();
        }

        // POST: /KazneMP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDKazne,IDPresude,IDOsobe,Vrsta,Iznos,Opis")] DAL.EF.Kazna kazna)
        {
            if (ModelState.IsValid)
            {
                db.Kazna.Add(kazna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDOsobe = new SelectList(db.Osoba, "IDOsobe", "OIB", kazna.IDOsobe);
            ViewBag.IDPresude = new SelectList(db.TipPresude, "SifraTipa", "NazivTipa", kazna.IDPresude);
            ViewBag.Vrsta = new SelectList(db.VrstaKazne, "SifraVrste", "NazivVrste", kazna.Vrsta);
            return View(kazna);
        }

        // GET: /KazneMP/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAL.EF.Kazna kazna = db.Kazna.Find(id);
            if (kazna == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDOsobe = new SelectList(db.Osoba, "IDOsobe", "OIB", kazna.IDOsobe);
            ViewBag.IDPresude = new SelectList(db.TipPresude, "SifraTipa", "NazivTipa", kazna.IDPresude);
            ViewBag.Vrsta = new SelectList(db.VrstaKazne, "SifraVrste", "NazivVrste", kazna.Vrsta);
            return View(kazna);
        }

        // POST: /KazneMP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDKazne,IDPresude,IDOsobe,Vrsta,Iznos,Opis")] DAL.EF.Kazna kazna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kazna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDOsobe = new SelectList(db.Osoba, "IDOsobe", "OIB", kazna.IDOsobe);
            ViewBag.IDPresude = new SelectList(db.TipPresude, "SifraTipa", "NazivTipa", kazna.IDPresude);
            ViewBag.Vrsta = new SelectList(db.VrstaKazne, "SifraVrste", "NazivVrste", kazna.Vrsta);
            return View(kazna);
        }

        // GET: /KazneMP/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAL.EF.Kazna kazna = db.Kazna.Find(id);
            if (kazna == null)
            {
                return HttpNotFound();
            }
            return View(kazna);
        }

        // POST: /KazneMP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DAL.EF.Kazna kazna = db.Kazna.Find(id);
            db.Kazna.Remove(kazna);
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
