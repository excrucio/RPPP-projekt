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
    /// <summary>
    /// Ovo je kontroler koji radi sa pravnim osobama
    /// </summary>
    public class PravneOsobeController : Controller
    {

        private RPPP10 db = new RPPP10();

        /// <summary>
        /// Ovom funkcijom se prikazuje glavna stranica i prihvaća dva operanda s kojima radi
        /// </summary>
        /// <param name="SortOrder">Ovaj operand označava vrstu sortiranja koja će se izvesti</param>
        /// <param name="Pretraga">Ovaj operand je parametar za pretragu po nazivima</param>
        /// <returns>Vraća listu osoba koju prosljeđuje View-u</returns>
        public ActionResult Index(string SortOrder, string Pretraga)
        {
            ViewBag.NazivSort = String.IsNullOrEmpty(SortOrder) ? "Naziv_desc" : "";
            ViewBag.MjestoSort = SortOrder == "Mjesto" ? "Mjesto_desc" : "Mjesto";

            IEnumerable<PravnaOsoba> PravneOsobe = new PravnaOsobaBLL().DajSveOsobe();

            if (!String.IsNullOrEmpty(Pretraga))
            {
                PravneOsobe = PravneOsobe.Where(x => x.Naziv.Contains(Pretraga));
            }

            switch (SortOrder)
            {
                case "Naziv_desc":
                    PravneOsobe = PravneOsobe.OrderByDescending(x => x.Naziv);
                    break;
                case "Mjesto":
                    PravneOsobe = PravneOsobe.OrderBy(x => x.Mjesto);
                    break;
                case "Mjesto_desc":
                    PravneOsobe = PravneOsobe.OrderByDescending(x => x.Mjesto);
                    break;
                default:
                    PravneOsobe = PravneOsobe.OrderBy(x => x.Naziv);
                    break;
            }

            return View(PravneOsobe);
        }

        /// <summary>
        /// Ovom funkcijom se poziva View za dodavanje osoba
        /// </summary>
        /// <returns>Vraća View za dodavanje osoba</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Ovom funkcijom se dodaju osobe
        /// </summary>
        /// <param name="pravnaosoba">Ovaj prametar je osoba koja se dodaje tipa PravnaOsoba</param>
        /// <returns>Vraća View na glavnu stranicu ili ne ide nikud u slučaju greške</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Naziv,MB,OIB,Adresa,Mjesto")] PravnaOsoba pravnaosoba)
        {
            if (ModelState.IsValid)
            {
                new PravnaOsobaBLL().Unesi(pravnaosoba);
                return RedirectToAction("Index");
            }

            return View(pravnaosoba);
        }

        /// <summary>
        /// Ovo je funkcija za uređivanje osoba. traži osobu preko ID-a te ju šalje na View za uređivanje
        /// </summary>
        /// <param name="id">ID po kojem se traži osoba</param>
        /// <returns>Vraća View za uređivanje osobe </returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PravnaOsoba pravnaosoba = new PravnaOsobaBLL().DajJednuID((int)id);
            if (pravnaosoba == null)
            {
                return HttpNotFound();
            }

            TempData["ID"] = (int)id;
            
            return View(pravnaosoba);
        }

        /// <summary>
        /// Ovom funkcijom se dodaju osobe. Prima parametar tipa PravnaOsoba i sprema ga u bazu
        /// </summary>
        /// <param name="pravnaosoba">Parametar tipa PravnaOsoba koji se sprema</param>
        /// <returns>Vraća View na početnu stranicu ili nazad na uređivanje ukoliko postoji greška</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Naziv,MB,OIB,Adresa,Mjesto")] PravnaOsoba pravnaosoba)
        {
            if (ModelState.IsValid)
            {
                pravnaosoba.IDOsobe = Int32.Parse(TempData["ID"].ToString());
                new PravnaOsobaBLL().Promijeni(pravnaosoba);
                return RedirectToAction("Index");
            }
            return View(pravnaosoba);
        }

        /// <summary>
        /// Ovo je funkcija za traženje osobe za brisanje. Prima ID po kojem nađe osobu te ju postavi za brisanje.
        /// </summary>
        /// <param name="id">ID po kojem se traži osoba</param>
        /// <returns>Vraća View na stranicu koja traži potvrdu za brisanje</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PravnaOsoba pravnaosoba = new PravnaOsobaBLL().DajJednuID((int)id);
            if (pravnaosoba == null)
            {
                return HttpNotFound();
            }
            return View(pravnaosoba);
        }

        /// <summary>
        /// Ovom funkcijom se briše osoba. Prima ID po kojem ju briše.
        /// </summary>
        /// <param name="id">ID osobe koja se briše</param>
        /// <returns>Vraća View na Početnu stranicu ukoliko se potvrdilo da se osoba briše</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new PravnaOsobaBLL().Brisi(id);
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
