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
using System.ComponentModel;


namespace ManuelaKajkara.Controllers
{
    public class RocisteSudioniciMDController : Controller
    {
        //
        // GET: /RocisteSudioniciMD/
        public ActionResult Index(int Page = 1, int Sort = 1)
        {
            var rocista = new RocisteBLL().FetchAll();
            var rociste = rocista[Page-1];
            int broj = rocista.Count;
            var sudioniciN = new SudionikBLL().FetchByRociste(rociste.IDRocista);
            var proces = new ProcesBLL().Fetch(rociste.IDProcesa);
            IEnumerable<Sudionik> sudionici;

            if (Sort == 2) 
            {
                sudionici = sudioniciN.OrderBy(s => s.IDOsobe);
            }
            else
            {
                sudionici = sudioniciN.OrderBy(s => s.Uloga);
            }
            
            PagingInfo pagingInfoRocista = new PagingInfo
            {
                CurrentPage = Page,
                ItemsPerPage = 1,
                TotalItems = broj
            };

            if (pagingInfoRocista.TotalPages < Page)
            {
                Page = pagingInfoRocista.TotalPages;
                pagingInfoRocista.CurrentPage = Page;
            }

            Rocista_lista model = new Rocista_lista
            {
                rociste = rociste,
                sudionici = sudionici,
                pagingInfoRocista = pagingInfoRocista,
                proces = proces
            };

            return View(model);
        }

        public ActionResult CreateMaster()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMaster([Bind(Include = "IDRocista,IDProcesa,Datum,Trajanje")] Rociste rociste)
        {
            if (ModelState.IsValid)
            {
                new RocisteBLL().Insert(rociste);
                return RedirectToAction("Index");
            }

            return View(rociste);
        }

        public ActionResult CreateDetail(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sudionik sudionik = new Sudionik();
            TempData["IDRocista"] = (int)ID;
            return View(sudionik);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDetail([Bind(Include = "IDSudionika,IDOsobe,IDRocista,Uloga")] Sudionik sudionik)
        {
            sudionik.IDRocista = Int32.Parse(TempData["IDRocista"].ToString());
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var e in errors)
                System.Diagnostics.Debug.WriteLine(e.ErrorMessage);
            if (ModelState.IsValid)
            {
                new SudionikBLL().Insert(sudionik);
                return RedirectToAction("Index");
            }

            return View(sudionik);
        }
       
        public ActionResult EditMaster(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rociste rociste = new RocisteBLL().Fetch((int)ID);
            if (rociste == null)
            {
                return HttpNotFound();
            }
            return View(rociste);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMaster([Bind(Include = "IDRocista,IDProcesa,Datum,Trajanje")] Rociste rociste)
        {
            if (ModelState.IsValid)
            {
                new RocisteBLL().Update(rociste);
                return RedirectToAction("Index");
            }
            return View(rociste);
        }

        public ActionResult EditDetail(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sudionik sudionik = new SudionikBLL().Fetch((int)ID);
            System.Diagnostics.Debug.WriteLine("U gornjoj EditDetail metodi ID sudionike je {0}.", sudionik.IDSudionika);
            if (sudionik == null)
            {
                return HttpNotFound();
            }
            TempData["IDSudionika"] = sudionik.IDSudionika;
            TempData["IDRocista"] = sudionik.IDRocista;

            return View(sudionik);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDetail([Bind(Include = "IDSudionika,IDOsobe,IDRocista,Uloga")] Sudionik sudionik)
        {
            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("U EditDetail metodi ID sudionike je {0}.", TempData["IDSudionika"]);
                sudionik.IDSudionika = Int32.Parse(TempData["IDSudionika"].ToString());
                sudionik.IDRocista = Int32.Parse(TempData["IDRocista"].ToString());
                new SudionikBLL().Update(sudionik);
                return RedirectToAction("Index");
            }
            return View(sudionik);
        }

        public ActionResult DeleteMaster(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rociste rociste = new RocisteBLL().Fetch((int)id);
            if (rociste == null)
            {
                return HttpNotFound();
            }
            return View(rociste);
        }

        [HttpPost, ActionName("DeleteMaster")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMasterConfirmed(int id)
        {
            List<Sudionik> sudionici = new SudionikBLL().FetchByRociste(id).ToList();

            foreach (Sudionik sudionik in sudionici)
            {
                new SudionikBLL().Delete(sudionik);
            }

            new RocisteBLL().Delete(new RocisteBLL().Fetch(id));

            return RedirectToAction("Index");
        }

        public ActionResult DeleteDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sudionik sudionik = new SudionikBLL().Fetch((int)id);
            System.Diagnostics.Debug.WriteLine("U gornjoj DeleteDetail metodi ID sudionike je {0}.", sudionik.IDSudionika);

            if (sudionik == null)
            {
                return HttpNotFound();
            }
            return View(sudionik);
        }

        [HttpPost, ActionName("DeleteDetail")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDetailConfirmed(int id)
        {
            System.Diagnostics.Debug.WriteLine("U donjoj DeleteDetail metodi ID sudionike je {0}.", id);

            new SudionikBLL().Delete(new SudionikBLL().Fetch(id));
            
            return RedirectToAction("Index");
        }

	}
}