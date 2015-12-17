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
    public class ZakonVrstaController : Controller
    {
        private RPPP10 db = new RPPP10();

        // GET: /ZakonVrsta/
        public ActionResult Index()
        {
            return View(new RazinaZakonaBLL().DajSveRazine());
        }

        // GET: /ZakonVrsta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RazinaZakona razinazakona = new RazinaZakonaBLL().DajRazinu((int)id);
            if (razinazakona == null)
            {
                return HttpNotFound();
            }
            return View(razinazakona);
        }

        // GET: /ZakonVrsta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ZakonVrsta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDRazine,Naziv")] RazinaZakona razinazakona)
        {
            if (ModelState.IsValid)
            {
                new RazinaZakonaBLL().RazinaUnesi(razinazakona);
                return RedirectToAction("Index");
            }

            return View(razinazakona);
        }

        // GET: /ZakonVrsta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RazinaZakona razinazakona = new RazinaZakonaBLL().DajRazinu((int) id);
            if (razinazakona == null)
            {
                return HttpNotFound();
            }
            return View(razinazakona);
        }

        // POST: /ZakonVrsta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDRazine,Naziv")] RazinaZakona razinazakona)
        {
            if (ModelState.IsValid)
            {
                new RazinaZakonaBLL().RazinaPromijeni(razinazakona);
                return RedirectToAction("Index");
            }
            return View(razinazakona);
        }

        // GET: /ZakonVrsta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RazinaZakona razinazakona = new RazinaZakonaBLL().DajRazinu((int) id);
            if (razinazakona == null)
            {
                return HttpNotFound();
            }
            return View(razinazakona);
        }

        // POST: /ZakonVrsta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new RazinaZakonaBLL().RazinaObrisi(id);
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
