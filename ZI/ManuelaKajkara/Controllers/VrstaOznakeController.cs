using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.EF;
using ManuelaKajkara.BLLProviders;

namespace ManuelaKajkara.Controllers
{
    public class VrstaOznakeController : Controller
    {
        private RPPP10 db = new RPPP10();

        // GET: /VrstaOznake/
        public ActionResult Index()
        {
            return View(new VrstaOznakeBLL().DajSveOznake());
        }

        // GET: /VrstaOznake/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VrstaOznake vrstaoznake = new VrstaOznakeBLL().DajOznaku(id);
            if (vrstaoznake == null)
            {
                return HttpNotFound();
            }
            return View(vrstaoznake);
        }

        // GET: /VrstaOznake/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /VrstaOznake/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SifraOznake,Opis")] VrstaOznake vrstaoznake)
        {
            if (ModelState.IsValid)
            {
                new VrstaOznakeBLL().UnesiOznaku(vrstaoznake);
                return RedirectToAction("Index");
            }

            return View(vrstaoznake);
        }

        // GET: /VrstaOznake/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VrstaOznake vrstaoznake = new VrstaOznakeBLL().DajOznaku(id);
            if (vrstaoznake == null)
            {
                return HttpNotFound();
            }

            TempData["Sifra"] = id;

            return View(vrstaoznake);
        }

        // POST: /VrstaOznake/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SifraOznake,Opis")] VrstaOznake vrstaoznake)
        {
            if (ModelState.IsValid)
            {
                new VrstaOznakeBLL().PromijeniOznaku(vrstaoznake.SifraOznake, vrstaoznake);
                return RedirectToAction("Index");
            }
            return View(vrstaoznake);
        }

        // GET: /VrstaOznake/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VrstaOznake vrstaoznake = new VrstaOznakeBLL().DajOznaku(id);
            if (vrstaoznake == null)
            {
                return HttpNotFound();
            }
            return View(vrstaoznake);
        }

        // POST: /VrstaOznake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            new VrstaOznakeBLL().ObrisiOznaku(id);
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
