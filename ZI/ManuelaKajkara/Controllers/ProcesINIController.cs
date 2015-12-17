using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.EF;
using ManuelaKajkara.Models;
using ManuelaKajkara.BLLProviders;

namespace ManuelaKajkara.Controllers
{
    public class ProcesINIController : Controller
    {
        private RPPP10 db = new RPPP10();

        // GET: /ProcesINI/
        public ActionResult Index()
        {
            var proces = db.Proces.Include(p => p.VrstaOznake).Include(p => p.Sud1);
            return View(proces.ToList());
        }

        public ActionResult Search()
        {
            var vrste = new VrstaOznakeBLL().DajSveOznake();
            List<VrstaOznake> vro = new List<VrstaOznake>();
            foreach (var item in vrste) vro.Add(item);
            ViewBag.VrstaOznake = vro;

            var sudi = new SudBLL().FetchAll();
            List<Sud> sudovi = new List<Sud>();
            foreach (var item in sudi) sudovi.Add(item);
            ViewBag.Sudovi = sudovi;

            Proces_trazi model = new Proces_trazi
            {
                Naziv = "",
                Sud = -777,
                Vrsta = "Odaberi"
            };
            ViewBag.Nadjeni = "ne";
            return View(model);
        }

        [HttpPost, ActionName("Search")]
        public ActionResult Rezultati(Proces_trazi trazi)
        {

            ProNad_lista nadeno = new ProNad_lista();
            nadeno.Procesi = new List<ProcesPD>();

            List<ProcesPD> pro = new List<ProcesPD>();
            if (trazi.Naziv == null) trazi.Naziv = "";
            if (trazi.Vrsta == null) trazi.Vrsta = "Odaberi";
            if (trazi.Sud == 0) trazi.Sud = -777;
            if (trazi.Sud == -777)
            {
                if (trazi.Vrsta == "Odaberi")
                {
                    pro = new ProcesBLL().TraziNazSudVrs(trazi.Naziv);
                }
                else
                {
                    pro = new ProcesBLL().TraziNazSudVrs(trazi.Naziv, -777, trazi.Vrsta);
                }
            }
            else
            {

                pro = new ProcesBLL().TraziNazSudVrs(trazi.Naziv, trazi.Sud, trazi.Vrsta);
            }

            if (pro != null)
            {
                nadeno.Procesi = pro;
                ViewBag.Nadjeni = "da";
            }
            else {
                nadeno.Procesi = null;
                ViewBag.Nadjeni = "ne";
            }

            return View("~/Views/ProcesINI/Rezultati.cshtml", nadeno);
        }

        // GET: /ProcesINI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proces proces = db.Proces.Find(id);
            if (proces == null)
            {
                return HttpNotFound();
            }
            return View(proces);
        }

        // GET: /ProcesINI/Create
        public ActionResult Create()
        {
            ViewBag.Oznaka = new SelectList(db.VrstaOznake, "SifraOznake", "OpisOznake");
            ViewBag.Sud = new SelectList(db.Sud, "IDSuda", "Naziv");
            return View();
        }

        // POST: /ProcesINI/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDProcesa,Broj,Klasa,Oznaka,Naziv,Sud")] Proces proces)
        {
            if (ModelState.IsValid)
            {
                db.Proces.Add(proces);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Oznaka = new SelectList(db.VrstaOznake, "SifraOznake", "OpisOznake", proces.Oznaka);
            ViewBag.Sud = new SelectList(db.Sud, "IDSuda", "Naziv", proces.Sud);
            return View(proces);
        }

        // GET: /ProcesINI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proces proces = db.Proces.Find(id);
            if (proces == null)
            {
                return HttpNotFound();
            }
            ViewBag.Oznaka = new SelectList(db.VrstaOznake, "SifraOznake", "OpisOznake", proces.Oznaka);
            ViewBag.Sud = new SelectList(db.Sud, "IDSuda", "Naziv", proces.Sud);
            return View(proces);
        }

        // POST: /ProcesINI/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDProcesa,Broj,Klasa,Oznaka,Naziv,Sud")] Proces proces)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proces).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Oznaka = new SelectList(db.VrstaOznake, "SifraOznake", "OpisOznake", proces.Oznaka);
            ViewBag.Sud = new SelectList(db.Sud, "IDSuda", "Naziv", proces.Sud);
            return View(proces);
        }

        // GET: /ProcesINI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proces proces = db.Proces.Find(id);
            if (proces == null)
            {
                return HttpNotFound();
            }
            return View(proces);
        }

        // POST: /ProcesINI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proces proces = db.Proces.Find(id);
            db.Proces.Remove(proces);
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
