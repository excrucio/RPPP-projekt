using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.EF;
using PagedList;
using ManuelaKajkara.BLLProviders;
using ManuelaKajkara.Models;
using ManuelaKajkara;

namespace ManuelaKajkara.Controllers
{
    /// <summary>
    /// Razred za postavljanje pogleda oblika zaglavlje-detalji kazni
    /// </summary>
    public class KazneController : Controller
    {

        /// <summary>
        /// db je baza podataka
        /// </summary>
        private RPPP10 db = new RPPP10();


        /// <summary>
        /// Ovom funkcijom se prikazuje stranica za pretragu kazni
        /// </summary>
        /// <returns>Vraća View na stranicu za pretraživanje kazni</returns>
        public ActionResult Search()
        {
            var vrste = new VrKaBLL().FetchAll();
            List<VrKa> vrk = new List<VrKa>();
            foreach (var item in vrste) vrk.Add(item);
            ViewBag.VrstaKazne = vrk;

            Osobe_lista model = new Osobe_lista
            {
                osoba = null,
                PagingInfo = new PagingInfo(),
                kazne = null,
                VrstaKazne=1
            };
            ViewBag.Nadjeni = "ne";
            return View(model);
        }

        /// <summary>
        /// Ovo je funkcija za pretraživanje kazni. Traži kazne preko Imena i/ili prezimena kažnjene osobe i/ili vrste kazne te rezultat šalje na View za prikaz rezultata
        /// </summary>
        /// <param name="trazi">Parametar tipa Osobe_lista s listom osoba i podacima (ime, prezime, vrsta kazne) po kojem se traže kazne</param>
        /// <returns>Vraća View za pregled rezultata pretrage</returns>
        [HttpPost, ActionName("Search")]
        public ActionResult Rezultati(Osobe_lista trazi=null)
        {
            var vrste = new VrKaBLL().FetchAll();
            List<VrKa> vrk = new List<VrKa>();
            foreach (var item in vrste) vrk.Add(item);
            ViewBag.VrstaKazne = vrk;

            Osobe_lista model = new Osobe_lista
            {
                osoba = trazi.osoba,
                PagingInfo = new PagingInfo(),
                kazne = trazi.kazne
            };

            Nadeno_lista nadeno = new Nadeno_lista();
            nadeno.osobe = new List<Osobe_lista>();

            var ose = new OsobaBLL().TraziIP(model.osoba.Ime, model.osoba.Prezime);
            if (ose != null){
                foreach (var os in ose)
                {
                    Osobe_lista osobaN = new Osobe_lista();
                    var kaz = new KaznaBLL().Fetch(os.IDOsobe);
                    var kaz2 = new KaznaBLL().Fetch(os.IDOsobe);
                    foreach (var k in kaz)
                    {
                        if (k.Vrsta != trazi.VrstaKazne)
                        {
                            kaz2.Remove(k);
                        }
                    }
                    os.ImePrezime = os.Ime + " " + os.Prezime;
                    osobaN.kazne = kaz2;
                    osobaN.PagingInfo = new PagingInfo();
                    osobaN.osoba = os;
                    osobaN.osoba.ImePrezime = os.ImePrezime;
                    nadeno.osobe.Add(osobaN);
                }
            }
            var kazn = new KaznaBLL().FetchAll();

            foreach (var k in kazn)
            {
                if (k.Vrsta == trazi.VrstaKazne)
                {
                    Osobe_lista osoba = new Osobe_lista();
                    osoba.osoba = new FizickaOsoba();

                    osoba.osoba.ImePrezime = k.Osoba.ImePrezime;
                    osoba.osoba.IDOsobe = k.IDOsobe;
                    osoba.kazne = Enumerable.Repeat(k, 1);
                    nadeno.osobe.Add(osoba);
                }
            }
            foreach (var osb in nadeno.osobe)
            {
                foreach (Kazna item in osb.kazne)
                {
                    item.Naziv = new KaznaBLL().vrstaKazne((int)item.Vrsta).ToString();
                    item.Presuda = new KaznaBLL().vrstaPresude((int)item.IDPresude).ToString();
                }
            }

            ViewBag.Nadjeni = "da";
            return View("~/Views/Kazne/Rezultati.cshtml",nadeno);
        }


        /// <summary>
        /// Ovom funkcijom se prikazuje glavna stranica (Index) i prihvaća jedan operand
        /// </summary>
        /// <param name="Page">Ovaj operand označava stranicu koju treba prikazati</param>
        /// <returns>Vraća listu osoba koju prosljeđuje View-u</returns>
        public ActionResult Index(int Page = 1)
        {

            var Osoba = new OsobaBLL().DajOsobu(Page - 1);
            var SveOsobe = new OsobaBLL().FetchAll();
            int BrojOsoba = SveOsobe.Count();
            var Kazne = new KaznaBLL().Fetch(Osoba.IDOsobe);

            foreach (Kazna item in Kazne) {
                item.Naziv = new KaznaBLL().vrstaKazne((int)item.Vrsta).ToString();
                item.Presuda = new KaznaBLL().vrstaPresude((int)item.IDPresude).ToString();
            }

            PagingInfo pagingInfoOsobe = new PagingInfo
            {
                CurrentPage = Page,
                ItemsPerPage = 1,
                TotalItems = BrojOsoba
            };

            if (pagingInfoOsobe.TotalPages < Page)
            {
                Page = pagingInfoOsobe.TotalPages;
                pagingInfoOsobe.CurrentPage = Page;
            }

            Osobe_lista model = new Osobe_lista
            {
                osoba = Osoba,
                PagingInfo = pagingInfoOsobe,
                kazne = Kazne
            };

            return View(model);
        }

        /// <summary>
        /// Ovo je funkcija za prikaz detalja kazne. Traži kaznu preko ID-a te ju šalje na View za detalje
        /// </summary>
        /// <param name="id">ID kazne koja se traži</param>
        /// <returns>Vraća View na stranicu za prikaz detalja kazne</returns>
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kazna kazna = new KaznaBLL().DajKaznu(id);
            if (kazna == null)
            {
                return HttpNotFound();
            }
            ViewBag.Title=kazna.Osoba.ImePrezime;
            return View(kazna);
        }

        /// <summary>
        /// Ovom funkcijom se poziva View za dodavanje kazne osobi i prihvaća jedan operand
        /// </summary>
        /// <param name="id">Ovaj operand označava osobu kojoj treba dodati kaznu</param>
        /// <returns>Vraća View za dodavanje kazne osobi</returns>
        public ActionResult DodajKaznu(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FizickaOsoba oso = new OsobaBLL().Fetch(id);
            if (oso == null)
            {
                return HttpNotFound();
            }
            ViewBag.Title = oso.ImePrezime;
            ViewBag.IDOsobe = new SelectList(db.Osoba, "IDOsobe", "IDOsobe", id);
            ViewBag.IDPresude = new SelectList(db.Presuda, "IDStavke", "IDStavke");
            ViewBag.Vrsta = new SelectList(db.VrstaKazne, "SifraVrste", "NazivVrste");
            ViewData["Pogreška"] = "-";
            return View();
        }

        /// <summary>
        /// Ovom funkcijom se dodaje kazna nekoj osobi 
        /// </summary>
        /// <param name="kazna">Ovaj prametar je kazna koja se dodaje osobi, tipa je Kazna</param>
        /// <returns>Vraća View na glavnu stranicu ili ne ide nikud u slučaju greške</returns>
        [HttpPost]
        public ActionResult DodajKaznu([Bind(Include = "IDKazne,IDPresude,IDOsobe,Vrsta,Iznos,Opis")] Kazna kazna)
        {
            try { 
                new KaznaBLL().Insert(kazna);
            }
            catch (Exception e)
            {
                ViewData["Pogreška"] = e.Data;
                FizickaOsoba oso = new OsobaBLL().Fetch(kazna.IDOsobe);
                if (oso == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Title = oso.ImePrezime;

                ViewBag.IDOsobe = new SelectList(db.Osoba, "IDOsobe", "IDOsobe", kazna.IDOsobe);
                ViewBag.IDPresude = new SelectList(db.Presuda, "IDStavke", "IDStavke");
                ViewBag.Vrsta = new SelectList(db.VrstaKazne, "SifraVrste", "NazivVrste");
                return View();
            }
                return RedirectToAction("Index");
        }

        /// <summary>
        /// Ovo je funkcija za uređivanje kazne. Traži kaznu preko ID-a te ju šalje na View za uređivanje
        /// </summary>
        /// <param name="idkazne">ID po kojem se traži kazna za uređivanje</param>
        /// <returns>Vraća View za uređivanje kazne </returns>
        public ActionResult Edit(Nullable<int> idKazne=-757)
        {
            if (idKazne == null || idKazne==-757)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var kazna = new KaznaBLL().DajKaznu((int)idKazne);
            if (kazna == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDOsobe = new SelectList(db.Osoba, "IDOsobe", "OIB", kazna.IDOsobe);
            ViewBag.IDPresude = new SelectList(db.Presuda, "IDStavke", "IDStavke", kazna.IDPresude);
            ViewBag.Vrsta = new SelectList(db.VrstaKazne, "SifraVrste", "NazivVrste", kazna.Vrsta);
            return View(kazna);
        }

        /// <summary>
        /// Ovom funkcijom se sprema izmjenjena kazna. Prima parametar tipa Kazna i sprema ga u bazu
        /// </summary>
        /// <param name="kazna">Parametar tipa Kazna koji se sprema u bazu. Izmjenjena kazna</param>
        /// <returns>Vraća View na početnu stranicu ili nazad na uređivanje ukoliko postoji greška</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include="IDKazne,IDPresude,IDOsobe,Vrsta,Iznos,Opis")]*/ Kazna kazna)
        {
            try
            {
                new KaznaBLL().Update(kazna);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                
                ViewData["Pogreška"] = e.Message;
            }


            if (kazna.IDKazne == -757)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var kaz = new KaznaBLL().DajKaznu((int)kazna.IDKazne);
            if (kaz == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDOsobe = new SelectList(db.Osoba, "IDOsobe", "OIB", kaz.IDOsobe);
            ViewBag.IDPresude = new SelectList(db.Presuda, "IDStavke", "IDStavke", kaz.IDPresude);
            ViewBag.Vrsta = new SelectList(db.VrstaKazne, "SifraVrste", "NazivVrste", kaz.Vrsta);
            return View(kazna);

        }

        /// <summary>
        /// Ovo je funkcija za traženje kazne za brisanje. Prima ID po kojem nađe kaznu te ju postavi za brisanje.
        /// </summary>
        /// <param name="id">ID po kojem se traži kazna za brisanje</param>
        /// <returns>Vraća View na stranicu koja traži potvrdu za brisanje kazne</returns>
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var kazna = new KaznaBLL().DajKaznu(id);

            ViewBag.Title = new KaznaBLL().DajKaznu(id).Osoba.ImePrezime;
            ViewBag.IDOsobe = new SelectList(db.Osoba, "IDOsobe", "OIB", kazna.IDOsobe);
            ViewBag.IDPresude = new SelectList(db.TipPresude, "SifraTipa", "NazivTipa", kazna.IDPresude);
            ViewBag.Vrsta = new SelectList(db.VrstaKazne, "SifraVrste", "NazivVrste", kazna.Vrsta);
            return View(kazna);
        }

        /// <summary>
        /// Ovom funkcijom se briše kazna. Prima ID po kojem ju briše.
        /// </summary>
        /// <param name="id">ID kazne koja se briše</param>
        /// <returns>Vraća View na Početnu stranicu i briše osobu ukoliko se potvrdilo da se osoba briše ili samo vraća Početnu stranicu u slučaju odustajanja</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new KaznaBLL().Delete(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Ovom funkcijom se sprema uređena osoba i njene uređene kazne. Prima jedan operand
        /// </summary>
        /// <param name="podaci">Operand tipa Edit_lista u kojem je osoba i njene kazne koje treba spremiti u bazu</param>
        /// <returns>Vraća View na početnu stranicu ili nazad an uređivanje ako postoje greške</returns>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Ovom funkcijom se prikazujee stranica za uređivanje osobe i njenih kazni- Prihvaća jedan operand
        /// </summary>
        /// <param name="id">ID po kojem se traži osoba koju zajedno s njeim kaznama treba urediti</param>
        /// <returns>Vraća View na stranicu za uređivanje osobe i njenih kazni</returns>
        public ActionResult Uredi(int id=-757)
        {
            if (id == -757)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var oso = new OsobaBLL().Fetch(id);

            if (oso == null)
            {
                return HttpNotFound();
            }

            var KazneSve = new KaznaBLL().Fetch(oso.IDOsobe);

            foreach (Kazna item in KazneSve)
            {
                item.Naziv = new KaznaBLL().vrstaKazne((int)item.Vrsta).ToString();
                item.Presuda = new KaznaBLL().vrstaPresude((int)item.IDPresude).ToString();
            }

            Edit_lista model = new Edit_lista
            {
                IDOsobe=oso.IDOsobe,
                Ime=oso.Ime,
                ImeOca=oso.ImeOca,
                Prezime=oso.Prezime,
                JMBG=oso.JMBG,
                datumRod=oso.DatumRod,
                Kazne = KazneSve.ToList(),
                ulica = oso.ulica,
                pbr=oso.pbr
            };

            var mjesta = new MjestoBLL().FetchAll();
            List<Mjesto> mj = new List<Mjesto>();
            foreach (var item in mjesta) mj.Add(item);
            ViewBag.Mjesta = mj;

            var presude = new PresudaBLL().FetchAll();
            List<Presuda> pre = new List<Presuda>();
            foreach (var item in presude) pre.Add(item);
            ViewBag.Presude = pre;

            ViewBag.Mj = oso.pbr;
            ViewBag.IDOsobe = oso.IDOsobe;

            var vrste = new VrKaBLL().FetchAll();
            List<VrKa> vrk = new List<VrKa>();
            foreach (var item in vrste) vrk.Add(item);
            ViewBag.VrstaKazne=vrk;
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Uredi( Edit_lista podaci)
        {
     //------------------------------------------------------
            try
                {

            foreach (Kazna kazna in podaci.Kazne)
            {
                
                    new KaznaBLL().Update(kazna);
                
            }

            FizickaOsoba osoba = new FizickaOsoba
            {
                IDOsobe = podaci.IDOsobe,
                Ime = podaci.Ime,
                Prezime = podaci.Prezime,
                ImeOca = podaci.ImeOca,
                DatumRod = podaci.datumRod,
                JMBG = podaci.JMBG.ToString(),
                Adresa = podaci.ulica,
                pbr = podaci.pbr
            };
            new OsobaBLL().Update(osoba);

            return RedirectToAction("Index");
                }
            catch (Exception e)
            {
                ViewData["Pogreška"] = e.Message;
            }

            var oso = new OsobaBLL().Fetch(podaci.IDOsobe);

            if (oso == null)
            {
                return HttpNotFound();
            }

            var KazneSve = new KaznaBLL().Fetch(oso.IDOsobe);

            foreach (Kazna item in KazneSve)
            {
                item.Naziv = new KaznaBLL().vrstaKazne((int)item.Vrsta).ToString();
                item.Presuda = new KaznaBLL().vrstaPresude((int)item.IDPresude).ToString();
            }

            Edit_lista model = new Edit_lista
            {
                IDOsobe = oso.IDOsobe,
                Ime = oso.Ime,
                ImeOca = oso.ImeOca,
                Prezime = oso.Prezime,
                JMBG = oso.JMBG,
                datumRod = oso.DatumRod,
                Kazne = KazneSve.ToList(),
                ulica = oso.ulica,
                pbr = oso.pbr
            };

            var mjesta = new MjestoBLL().FetchAll();
            List<Mjesto> mj = new List<Mjesto>();
            foreach (var item in mjesta) mj.Add(item);
            ViewBag.Mjesta = mj;

            var presude = new PresudaBLL().FetchAll();
            List<Presuda> pre = new List<Presuda>();
            foreach (var item in presude) pre.Add(item);
            ViewBag.Presude = pre;

            ViewBag.Mj = oso.pbr;
            ViewBag.IDOsobe = oso.IDOsobe;

            var vrste = new VrKaBLL().FetchAll();
            List<VrKa> vrk = new List<VrKa>();
            foreach (var item in vrste) vrk.Add(item);
            ViewBag.VrstaKazne = vrk;
            return View(model);
        }

        /// <summary>
        /// Ova funkcija prikazuje straicu za dodvanje kazne nekoj osobi u bazi
        /// </summary>
        /// <returns>Vraća View na stranicu za kažnjavanje osoba</returns>
        public ActionResult Kazni()
        {
            List<FizickaOsoba> osobe = new OsobaBLL().FetchAll().ToList();
            if (osobe == null)
            {
                return HttpNotFound();
            }
            ViewBag.Osobe = osobe;
            ViewBag.IDOsobe = new SelectList(db.Osoba, "IDOsobe", "IDOsobe", 1);
            ViewBag.IDPresude = new SelectList(db.Presuda, "IDStavke", "IDStavke");
            ViewBag.Vrsta = new SelectList(db.VrstaKazne, "SifraVrste", "NazivVrste");
            ViewData["Pogreška"] = "-";
            return View();
        }

        /// <summary>
        /// Ovom funkcijom se dodaje kazna nekoj osobi
        /// </summary>
        /// <param name="kazna">Parametar tipa Kazna koji se dodaje nekoj osobi u bazi</param>
        /// <returns>Vraća View na početnu stranicu</returns>
        [HttpPost]
        public ActionResult Kazni([Bind(Include = "IDKazne,IDPresude,IDOsobe,Vrsta,Iznos,Opis")] Kazna kazna)
        {
            try
            {
                new KaznaBLL().Insert(kazna);
            }
            catch (Exception e)
            {
                ViewData["Pogreška"] = e.Data;
                List<FizickaOsoba> osobe = new OsobaBLL().FetchAll().ToList();
                if (osobe == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Osobe = osobe;
                ViewBag.IDOsobe = new SelectList(db.Osoba, "IDOsobe", "IDOsobe", 1);
                ViewBag.IDPresude = new SelectList(db.Presuda, "IDStavke", "IDStavke");
                ViewBag.Vrsta = new SelectList(db.VrstaKazne, "SifraVrste", "NazivVrste");
                return View();
            }
            return RedirectToAction("Index");
        }

    }
}
