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
    public class FizOsobeController : Controller
    {
        private RPPP10 db = new RPPP10();

        // GET: /FizOsobe/
        public ActionResult Index(string Sort, string Pretraga)
        {
            ViewBag.ImeSort = String.IsNullOrEmpty(Sort) ? "Ime_desc" : "";
            ViewBag.PrezimeSort = Sort == "Prezime" ? "Prezime_desc" : "Prezime";

            ServiceReference1.FirmaServisClient WCF = new ServiceReference1.FirmaServisClient();

            var fizickaosoba = WCF.DajSveFizickeOsobe();

            List<FizOsoba> Osobe = new List<FizOsoba>();

            foreach (ServiceReference1.FizOsoba i in fizickaosoba) {
                FizOsoba j = new FizOsoba();
                j.IDOsobe = i.IDOsobe;
                j.Ime = i.Ime;
                j.Prezime = i.Prezime;
                j.ImeOca = i.ImeOca;
                j.Datum = i.Datum;
                j.JMBG = i.JMBG;
                j.Poslodavac = i.Poslodavac;
                j.Odvjetnik = i.Odvjetnik;
                j.Sudac = i.Sudac;
                j.Adresa = i.Adresa;
                j.OIB = i.OIB;
                j.Mjesto = i.Mjesto;
                Osobe.Add(j);
            }

            WCF.Close();

            if (!String.IsNullOrEmpty(Pretraga))
            {
                Osobe = Osobe.Where(x => x.Ime.Contains(Pretraga)).ToList();
            }

            switch (Sort)
            {
                case "Ime_desc":
                    Osobe = Osobe.OrderByDescending(x => x.Ime).ToList();
                    break;
                case "Prezime":
                    Osobe = Osobe.OrderBy(x => x.Prezime).ToList();
                    break;
                case "Prezime_desc":
                    Osobe = Osobe.OrderByDescending(x => x.Prezime).ToList();
                    break;
                default:
                    Osobe = Osobe.OrderBy(x => x.Ime).ToList();
                    break;
            }

            return View(Osobe);
        }

        // GET: /FizOsobe/Create
        public ActionResult Create()
        {
            ViewBag.IDOsobe = new SelectList(db.Osoba, "IDOsobe", "OIB");
            ViewBag.Poslodavac = new SelectList(db.PravnaOsoba, "IDOsobe", "Naziv");
            return View();
        }

        // POST: /FizOsobe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDOsobe,Ime,Prezime,ImeOca,Datum,JMBG,Poslodavac,Odvjetnik,Sudac,OIB,Adresa,Mjesto")] FizOsoba fizickaosoba)
        {
            if (ModelState.IsValid)
            {
                ServiceReference1.FizOsoba osoba = new ServiceReference1.FizOsoba();

                osoba.Ime = fizickaosoba.Ime;
                osoba.Prezime = fizickaosoba.Prezime;
                osoba.ImeOca = fizickaosoba.ImeOca;
                osoba.Datum = fizickaosoba.Datum;
                osoba.JMBG = fizickaosoba.JMBG;
                osoba.Poslodavac = fizickaosoba.Poslodavac;
                osoba.Odvjetnik = fizickaosoba.Odvjetnik;
                osoba.Sudac = fizickaosoba.Sudac;
                osoba.Adresa = fizickaosoba.Adresa;
                osoba.OIB = fizickaosoba.OIB;
                osoba.Mjesto = fizickaosoba.Mjesto;

                ServiceReference1.FirmaServisClient WCF = new ServiceReference1.FirmaServisClient();

                WCF.UnesiFizickuOsobu(osoba);

                WCF.Close();

                return RedirectToAction("Index");
            }

            ViewBag.IDOsobe = new SelectList(db.Osoba, "IDOsobe", "OIB", fizickaosoba.IDOsobe);
            ViewBag.Poslodavac = new SelectList(db.PravnaOsoba, "IDOsobe", "Naziv", fizickaosoba.Poslodavac);
            return View(fizickaosoba);
        }

        // GET: /FizOsobe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ServiceReference1.FizOsoba osoba = new ServiceReference1.FizOsoba();

            ServiceReference1.FirmaServisClient WCF = new ServiceReference1.FirmaServisClient();

            osoba = WCF.DajFizickuOsobu((int)id);

            if (osoba == null)
            {
                return HttpNotFound();
            }

            FizOsoba fizickaosoba = new FizOsoba();

            fizickaosoba.IDOsobe = osoba.IDOsobe;
            fizickaosoba.Ime = osoba.Ime;
            fizickaosoba.Prezime = osoba.Prezime;
            fizickaosoba.ImeOca = osoba.ImeOca;
            fizickaosoba.Datum = osoba.Datum;
            fizickaosoba.JMBG = osoba.JMBG;
            fizickaosoba.Poslodavac = osoba.Poslodavac;
            fizickaosoba.Odvjetnik = osoba.Odvjetnik;
            fizickaosoba.Sudac = osoba.Sudac;
            fizickaosoba.Adresa = osoba.Adresa;
            fizickaosoba.OIB = osoba.OIB;
            fizickaosoba.Mjesto = osoba.Mjesto;

            WCF.Close();

            ViewBag.IDOsobe = new SelectList(db.Osoba, "IDOsobe", "OIB", fizickaosoba.IDOsobe);
            ViewBag.Poslodavac = new SelectList(db.PravnaOsoba, "IDOsobe", "Naziv", fizickaosoba.Poslodavac);

            return View(fizickaosoba);
        }

        // POST: /FizOsobe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDOsobe,Ime,Prezime,ImeOca,Datum,JMBG,Poslodavac,Odvjetnik,Sudac,OIB,Adresa,Mjesto")] FizOsoba fizickaosoba)
        {
            if (ModelState.IsValid)
            {
                ServiceReference1.FizOsoba osoba = new ServiceReference1.FizOsoba();

                osoba.IDOsobe = fizickaosoba.IDOsobe;
                osoba.Ime = fizickaosoba.Ime;
                osoba.Prezime = fizickaosoba.Prezime;
                osoba.ImeOca = fizickaosoba.ImeOca;
                osoba.Datum = fizickaosoba.Datum;
                osoba.JMBG = fizickaosoba.JMBG;
                osoba.Poslodavac = fizickaosoba.Poslodavac;
                osoba.Odvjetnik = fizickaosoba.Odvjetnik;
                osoba.Sudac = fizickaosoba.Sudac;
                osoba.Adresa = fizickaosoba.Adresa;
                osoba.OIB = fizickaosoba.OIB;
                osoba.Mjesto = fizickaosoba.Mjesto;

                ServiceReference1.FirmaServisClient WCF = new ServiceReference1.FirmaServisClient();

                WCF.PromijeniFizickuOsobu(osoba);

                WCF.Close();

                return RedirectToAction("Index");
            }
            ViewBag.IDOsobe = new SelectList(db.Osoba, "IDOsobe", "OIB", fizickaosoba.IDOsobe);
            ViewBag.Poslodavac = new SelectList(db.PravnaOsoba, "IDOsobe", "Naziv", fizickaosoba.Poslodavac);
            return View(fizickaosoba);
        }

        // GET: /FizOsobe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ServiceReference1.FizOsoba osoba = new ServiceReference1.FizOsoba();

            ServiceReference1.FirmaServisClient WCF = new ServiceReference1.FirmaServisClient();

            osoba = WCF.DajFizickuOsobu((int)id);

            if (osoba == null)
            {
                return HttpNotFound();
            }

            FizOsoba fizickaosoba = new FizOsoba();

            fizickaosoba.IDOsobe = osoba.IDOsobe;
            fizickaosoba.Ime = osoba.Ime;
            fizickaosoba.Prezime = osoba.Prezime;
            fizickaosoba.ImeOca = osoba.ImeOca;
            fizickaosoba.Datum = osoba.Datum;
            fizickaosoba.JMBG = osoba.JMBG;
            fizickaosoba.Poslodavac = osoba.Poslodavac;
            fizickaosoba.Odvjetnik = osoba.Odvjetnik;
            fizickaosoba.Sudac = osoba.Sudac;
            fizickaosoba.Adresa = osoba.Adresa;
            fizickaosoba.OIB = osoba.OIB;
            fizickaosoba.Mjesto = osoba.Mjesto;

            WCF.Close();

            return View(fizickaosoba);
        }

        // POST: /FizOsobe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceReference1.FirmaServisClient WCF = new ServiceReference1.FirmaServisClient();

            WCF.ObrisiFizickuOsobu(id);

            WCF.Close();

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
