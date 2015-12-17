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
    public class Kazne_WCFController : Controller
    {
        private RPPP10 db = new RPPP10();

        // GET: /Kazne_WCF/
        public ActionResult Index(string Sort, string Pretraga)
        {
            ViewBag.ImeSort = String.IsNullOrEmpty(Sort) ? "Ime_asc" : "";
            ViewBag.PrezimeSort = Sort == "Prezime" ? "Prezime_desc" : "Prezime";
            ServiceReference1.FirmaServisClient WCF = new ServiceReference1.FirmaServisClient();

            var kazna = WCF.DajSveKazne();
            List<Kazna> kazne = new List<Kazna>();

            foreach (ServiceReference1.Kazna i in kazna)
            {
                Kazna j = new Kazna();
                j.Osoba = new FizickaOsoba();
                j.IDOsobe = i.IDOsobe;
                j.IDKazne = i.IDKazne;
                j.IDPresude = i.IDPresude;
                j.Presuda = i.Presuda;
                j.Vrsta = i.Vrsta;
                j.Iznos = i.Iznos;
                j.Naziv = i.Naziv;
                j.Osoba.ImePrezime = i.Osoba.ImePrezime;
                j.Osoba.Prezime = i.Osoba.Prezime;
                j.Osoba.Ime = i.Osoba.Ime;
                j.Opis = i.Opis;
                j.Vrsta=i.Vrsta;
                kazne.Add(j);
            }

            WCF.Close();
            var vrste = new VrKaBLL().FetchAll();
            List<VrKa> vrk = new List<VrKa>();
            foreach (var item in vrste) vrk.Add(item);
            ViewBag.VrstaKazne = vrk;

            if (!String.IsNullOrEmpty(Pretraga))
            {
                kazne = kazne.Where(x => x.Osoba.ImePrezime.ToLower().Contains(Pretraga.ToLower())).ToList();
            }

            switch (Sort)
            {
                case "Ime_asc":
                    kazne = kazne.OrderBy(x => x.Osoba.Ime).ToList();
                    break;
                case "Prezime":
                    kazne = kazne.OrderBy(x => x.Osoba.Prezime).ToList();
                    break;
                case "Prezime_desc":
                    kazne= kazne.OrderByDescending(x => x.Osoba.Prezime).ToList();
                    break;
                default:
                    kazne = kazne.OrderByDescending(x => x.Osoba.Ime).ToList();
                    break;
            }
            foreach (Kazna item in kazne)
            {
                item.Naziv = new KaznaBLL().vrstaKazne((int)item.Vrsta).ToString();
                item.Presuda = new KaznaBLL().vrstaPresude((int)item.IDPresude).ToString();
            }

            return View(kazne);
        }

        // GET: /Kazne_WCF/Create
        public ActionResult Create()
        {
            return RedirectToAction("Kazni","Kazne");
        }

        // POST: /Kazne_WCF/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       /* [HttpPost]
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
        */
        // GET: /Kazne_WCF/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ServiceReference1.Kazna kazna = new ServiceReference1.Kazna();

            ServiceReference1.FirmaServisClient WCF = new ServiceReference1.FirmaServisClient();

            kazna = WCF.DajKaznu((int)id);

            if (kazna == null)
            {
                return HttpNotFound();
            }

            Kazna kaz = new Kazna();
            kaz.Osoba = new FizickaOsoba();
            kaz.IDOsobe = kazna.IDOsobe;
            kaz.IDKazne = kazna.IDKazne;
            kaz.IDPresude = kazna.IDPresude;
            kaz.Iznos = kazna.Iznos;
            kaz.Osoba.ImePrezime = kazna.Osoba.ImePrezime;
            kaz.Osoba.Prezime = kazna.Osoba.Prezime;
            kaz.Osoba.Ime = kazna.Osoba.Ime;
            kaz.Naziv = kazna.Naziv;
            kaz.Opis = kazna.Opis;
            kaz.Presuda = kazna.Presuda;
            kaz.Vrsta = kazna.Vrsta;

            WCF.Close();
            ViewBag.IDOsobe = new SelectList(db.Osoba, "IDOsobe", "OIB", kazna.IDOsobe);
            ViewBag.IDPresude = new SelectList(db.Presuda, "IDStavke", "IDStavke", kazna.IDPresude);
            ViewBag.Vrsta = new SelectList(db.VrstaKazne, "SifraVrste", "NazivVrste", kazna.Vrsta);

            return View(kaz);
        }

        // POST: /Kazne_WCF/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "IDOsobe,IDKazne,IDPresude,Iznos,Naziv,Opis,Presuda,Vrsta")]*/ Kazna kazna)
        {

                ServiceReference1.Kazna kaz = new ServiceReference1.Kazna();
                kaz.Osoba = new ServiceReference1.FizickaOsoba();
                kaz.IDOsobe = kazna.IDOsobe;
                kaz.IDKazne = kazna.IDKazne;
                kaz.IDPresude = kazna.IDPresude;
                kaz.Iznos = kazna.Iznos;
                kaz.Opis = kazna.Opis;
                kaz.Vrsta = kazna.Vrsta;

                ServiceReference1.FirmaServisClient WCF = new ServiceReference1.FirmaServisClient();

                WCF.PromijeniKaznu(kaz);

                WCF.Close();

                return RedirectToAction("Index");

        }

        // GET: /Kazne_WCF/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ServiceReference1.Kazna kazna = new ServiceReference1.Kazna();

            ServiceReference1.FirmaServisClient WCF = new ServiceReference1.FirmaServisClient();

            kazna = WCF.DajKaznu((int)id);

            if (kazna == null)
            {
                return HttpNotFound();
            }

            Kazna kaz = new Kazna();
            kaz.Osoba = new FizickaOsoba();
            kaz.IDOsobe = kazna.IDOsobe;
            kaz.IDKazne = kazna.IDKazne;
            kaz.IDPresude = kazna.IDPresude;
            kaz.Iznos = kazna.Iznos;
            kaz.Naziv = kazna.Naziv;
            kaz.Opis = kazna.Opis;
            kaz.Osoba.ImePrezime = kazna.Osoba.ImePrezime;
            kaz.Osoba.Prezime = kazna.Osoba.Prezime;
            kaz.Osoba.Ime = kazna.Osoba.Ime;
            kaz.Presuda = kazna.Presuda;
            kaz.Vrsta = kazna.Vrsta;

            WCF.Close();           
                
            kaz.Naziv = new KaznaBLL().vrstaKazne((int)kaz.Vrsta).ToString();
            kaz.Presuda = new KaznaBLL().vrstaPresude((int)kaz.IDPresude).ToString();


            return View(kaz);
        }

        // POST: /Kazne_WCF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceReference1.FirmaServisClient WCF = new ServiceReference1.FirmaServisClient();

            WCF.ObrisiKaznu(id);

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
