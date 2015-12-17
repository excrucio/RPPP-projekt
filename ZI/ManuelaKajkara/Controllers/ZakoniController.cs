using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Text;
using System.Web.Mvc;
using ManuelaKajkara.BLLProviders;
using ManuelaKajkara.Models;
using Firma.Framework;
using PagedList;

namespace ManuelaKajkara.Controllers
{
    public class ZakoniController : Controller
    {
        //
        // GET: /Zakoni/
        public ActionResult Main(int Page = 1)
        {
            var SviZakoni = new ZakonBLL().DajSveZakone();
            var Zakon = new ZakonBLL().DajZakon(Page - 1, 1);
            int BrojZakona = SviZakoni.Count;
            var Clanci = new ZakonBLL().DajClanke(Zakon.IDZakona);

            List<Zakon> Stavci = new List<Zakon>();

            foreach (Zakon i in Clanci)
            {
                var stavci = new ZakonBLL().DajStavke(i.IDZakona);
                Stavci.AddRange(stavci);
            }

            List<Zakon> ClanakIStavci = new List<Zakon>();

            PagingInfo pagingInfoZakoni = new PagingInfo
            {
                CurrentPage = Page,
                ItemsPerPage = 1,
                TotalItems = BrojZakona
            };

            if (pagingInfoZakoni.TotalPages < Page)
            {
                Page = pagingInfoZakoni.TotalPages;
                pagingInfoZakoni.CurrentPage = Page;
            }

            Zakoni_lista model = new Zakoni_lista
            {
                zakon = Zakon,
                PagingInfoZakoni = pagingInfoZakoni,
                clanci = Clanci,
                stavci = Stavci
            };

            return View(model);
        }

        public ActionResult DodajZakon()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DodajZakon([Bind(Include = "IDZakona,Naziv,Razina,IDNadredenog,Dokument,Stavak")] Zakon zakon)
        {
            if (ModelState.IsValid)
            {
                zakon.Razina = 1;
                new ZakonBLL().ZakonUnesi(zakon, 1);
                return RedirectToAction("Main");
            }

            return View(zakon);
        }

        public ActionResult DodajClanak(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakon clanak = new Zakon();
            TempData["IDNadredjeni"] = (int) ID;
            return View(clanak);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DodajClanak([Bind(Include = "IDZakona,Naziv,Razina,IDNadredenog,Dokument,Stavak")] Zakon zakon)
        {
            if (ModelState.IsValid)
            {
                zakon.Razina = 2;
                zakon.IDNadredenog = Int32.Parse(TempData["IDNadredjeni"].ToString());
                new ZakonBLL().ZakonUnesi(zakon, 2);
                return RedirectToAction("Main");
            }

            return View(zakon);
        }
        public ActionResult DodajStavak(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakon clanak = new Zakon();
            TempData["IDNadredjeni"] = (int)ID;
            return View(clanak);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DodajStavak([Bind(Include = "IDZakona,Naziv,Razina,IDNadredenog,Dokument,Stavak")] Zakon zakon)
        {
            if (ModelState.IsValid)
            {
                zakon.Razina = 3;
                zakon.IDNadredenog = Int32.Parse(TempData["IDNadredjeni"].ToString());
                new ZakonBLL().ZakonUnesi(zakon, 3);
                return RedirectToAction("Main");
            }

            return View(zakon);
        }

        public ActionResult UrediZakon(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakon zakon = new ZakonBLL().DajZakon((int)ID);
            if (zakon == null)
            {
                return HttpNotFound();
            }
            return View(zakon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UrediZakon([Bind(Include = "IDZakona,Naziv,Razina,IDNadredenog,Dokument,Stavak")] Zakon zakon)
        {
            if (ModelState.IsValid)
            {
                new ZakonBLL().ZakonPromijeni(1, zakon);
                return RedirectToAction("Main");
            }
            return View(zakon);
        }

        public ActionResult UrediClanak(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakon zakon = new ZakonBLL().DajZakon((int)ID);
            if (zakon == null)
            {
                return HttpNotFound();
            }
            TempData["IDNadredjeni"] = zakon.IDNadredenog;

            return View(zakon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UrediClanak([Bind(Include = "IDZakona,Naziv,Razina,IDNadredenog,Dokument,Stavak")] Zakon zakon)
        {
            if (ModelState.IsValid)
            {
                zakon.IDNadredenog = Int32.Parse(TempData["IDNadredjeni"].ToString());
                new ZakonBLL().ZakonPromijeni(2, zakon);
                return RedirectToAction("Main");
            }
            return View(zakon);
        }

        public ActionResult UrediStavak(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakon zakon = new ZakonBLL().DajZakon((int)ID);
            if (zakon == null)
            {
                return HttpNotFound();
            }
            TempData["IDNadredjeni"] = zakon.IDNadredenog;

            zakon.Stavak = Encoding.Unicode.GetString(zakon.Dokument);

            return View(zakon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UrediStavak([Bind(Include = "IDZakona,Naziv,Razina,IDNadredenog,Dokument,Stavak")] Zakon zakon)
        {
            if (ModelState.IsValid)
            {
                zakon.IDNadredenog = Int32.Parse(TempData["IDNadredjeni"].ToString());
                new ZakonBLL().ZakonPromijeni(3, zakon);
                return RedirectToAction("Main");
            }
            return View(zakon);
        }

        public ActionResult BrisiZakon(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakon zakon = new ZakonBLL().DajZakon((int)id);
            if (zakon == null)
            {
                return HttpNotFound();
            }
            return View(zakon);
        }

        [HttpPost, ActionName("BrisiZakon")]
        [ValidateAntiForgeryToken]
        public ActionResult BrisiZakonConfirmed(int id)
        {
            List<Zakon> clanci = new ZakonBLL().DajClanke(id).ToList();

            foreach (Zakon i in clanci)
            {
                new ZakonBLL().BrisiVise(i.IDZakona);
            }

            new ZakonBLL().BrisiVise(id);
            new ZakonBLL().BrisiJedan(id);

            return RedirectToAction("Main");
        }

        public ActionResult BrisiClanak(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakon zakon = new ZakonBLL().DajZakon((int)id);
            if (zakon == null)
            {
                return HttpNotFound();
            }
            return View(zakon);
        }

        [HttpPost, ActionName("BrisiClanak")]
        [ValidateAntiForgeryToken]
        public ActionResult BrisiClanakConfirmed(int id)
        {
            new ZakonBLL().BrisiVise(id);
            new ZakonBLL().BrisiJedan(id);

            return RedirectToAction("Main");
        }

        public ActionResult BrisiStavak(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakon zakon = new ZakonBLL().DajZakon((int)id);
            if (zakon == null)
            {
                return HttpNotFound();
            }
            return View(zakon);
        }

        [HttpPost, ActionName("BrisiStavak")]
        [ValidateAntiForgeryToken]
        public ActionResult BrisiStavakConfirmed(int id)
        {
            new ZakonBLL().BrisiJedan(id);
            return RedirectToAction("Main");
        }
	}
}