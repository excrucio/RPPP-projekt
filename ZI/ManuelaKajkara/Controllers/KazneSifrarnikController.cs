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
    public class KazneSifrarnikController : Controller
    {
        private RPPP10 db = new RPPP10();

        // GET: /KazneSifrarnik/
        public ActionResult Index()
        {
            return View(db.VrstaKazne.ToList());
        }

        // GET: /KazneSifrarnik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VrstaKazne vrstakazne = db.VrstaKazne.Find(id);
            if (vrstakazne == null)
            {
                return HttpNotFound();
            }
            return View(vrstakazne);
        }

        // GET: /KazneSifrarnik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /KazneSifrarnik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SifraVrste,NazivVrste")] VrstaKazne vrstakazne)
        {
            if (ModelState.IsValid)
            {
                db.VrstaKazne.Add(vrstakazne);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vrstakazne);
        }

        // GET: /KazneSifrarnik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VrstaKazne vrstakazne = db.VrstaKazne.Find(id);
            if (vrstakazne == null)
            {
                return HttpNotFound();
            }
            return View(vrstakazne);
        }

        // POST: /KazneSifrarnik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SifraVrste,NazivVrste")] VrstaKazne vrstakazne)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vrstakazne).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vrstakazne);
        }

        // GET: /KazneSifrarnik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VrstaKazne vrstakazne = db.VrstaKazne.Find(id);
            if (vrstakazne == null)
            {
                return HttpNotFound();
            }
            return View(vrstakazne);
        }

        // POST: /KazneSifrarnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VrstaKazne vrstakazne = db.VrstaKazne.Find(id);
            db.VrstaKazne.Remove(vrstakazne);
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
