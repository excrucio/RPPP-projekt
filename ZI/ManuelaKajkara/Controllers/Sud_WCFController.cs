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
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceModel;
using System.Text.RegularExpressions;

namespace ManuelaKajkara.Controllers
{
    public class Sud_WCFController : Controller
    {
        private RPPP10 db = new RPPP10();

        int pageSize = 20;


        #region Index
        // GET: /Sud_WCF/
        public ActionResult Index(int page = 1, int sort = 1)
        {
 
            ServiceReference1.FirmaServisClient WCF = new ServiceReference1.FirmaServisClient();
            var sudoviSVI = WCF.PopisSudova();
            List<ServiceReference1.Sud> sudListaPrebroji = sudoviSVI.ToList();
            int count = sudListaPrebroji.Count();
            IEnumerable<ServiceReference1.Sud> list;

            list = sudoviSVI.Skip((page - 1) * pageSize).Take(pageSize);

            #region pozabavi se stranicama
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = count,
                Sort = sort
            };

            if (pagingInfo.TotalPages < page)
            {
                page = pagingInfo.TotalPages;
                pagingInfo.CurrentPage = page;
            }
            #endregion

            Sudovi_listWCF model = new Sudovi_listWCF
            {
                PagingInfo = pagingInfo,
                SudList = list
            };

            return View(model);
        }
        #endregion

        #region Details
        public ActionResult Details(int id, int page = 1)
        {
            ServiceReference1.FirmaServisClient WCF = new ServiceReference1.FirmaServisClient();
            ServiceReference1.Sud sud = WCF.DohvatiJedan(id);
            ViewBag.CurrentPage = page;
            return View(sud);
        }
        #endregion

        #region Create
        public ActionResult Create(int page = 1)
        {
            ServiceReference1.FirmaServisClient WCF = new ServiceReference1.FirmaServisClient();
            
            var mjesta = WCF.PopisMjesta();
            List<ServiceReference1.Mjesto> mj = mjesta.ToList();
            ViewBag.Mjesta = mj;

            var kategorije = WCF.PopisKategorija();
            List<ServiceReference1.Kategorija> kat = kategorije.ToList();
            ViewBag.Kategorije = kat;

            ViewBag.CurrentPage = page;

            return View();
        }

        //[HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(ServiceReference1.Sud sud, int page = 1)
        {
            ServiceReference1.FirmaServisClient WCF = new ServiceReference1.FirmaServisClient();

            string errorNaziv_s = "";
            int errorNaziv = 0;

            string errorAdresa_s = "";
            int errorAdresa = 0;

            string pattern = "[-!?$%^&*()_+|~=`{}:'.<>,\\@#]";


            if (sud.Naziv == null) errorNaziv = 1;
            else
            {
                errorNaziv = Regex.Matches(sud.Naziv, pattern).Count;
            }
            if (errorNaziv != 0) errorNaziv_s = "Naziv je pogrešno unesen!";


            if (sud.Adresa == null) errorAdresa = 1;
            else
            {
                errorAdresa = Regex.Matches(sud.Adresa, pattern).Count;
            }

            if (errorAdresa != 0) errorAdresa_s = "Adresa je pogrešno unesena!";

            if (errorNaziv != 0 || errorAdresa != 0)
            {
                #region isto kao GET edit
                ViewData["Pogreska"] = "Podaci su neispravno uneseni, molimo Vas ispravite ih.";
                var mjesta = WCF.PopisMjesta();
                List<ServiceReference1.Mjesto> mj = mjesta.ToList();
                ViewBag.Mjesta = mj;

                var kategorije = WCF.PopisKategorija();
                List<ServiceReference1.Kategorija> kat = kategorije.ToList();
                ViewBag.Kategorije = kat;

                ViewBag.CurrentPage = page;

                return View();
                #endregion
            }

            Sud original = new Sud();

            var sudoviSVI = WCF.PopisSudova();
            List<ServiceReference1.Sud> sudListaPrebroji = sudoviSVI.ToList();

            List<int> id_s = new List<int>();
            foreach (var item in sudoviSVI) id_s.Add(item.ID);
            IEnumerable<int> lista = (IEnumerable<int>)id_s;
            int new_id = lista.Max() + 1;

            int id = new_id;
            string naziv = sud.Naziv;
            string adresa = sud.Adresa;
            int pbr = (int)sud.PBr;
            int kategorija = (int)sud.kategorija;

            try
            {
                WCF.DodajNoviSud(id,naziv,adresa,pbr,kategorija);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ViewData["Pogreška"] = e.Message;
            }


            ServiceReference1.FirmaServisClient WCF1 = new ServiceReference1.FirmaServisClient();

            var mjesta1 = WCF1.PopisMjesta();
            List<ServiceReference1.Mjesto> mj1 = mjesta1.ToList();
            ViewBag.Mjesta = mj1;

            var kategorije1 = WCF1.PopisKategorija();
            List<ServiceReference1.Kategorija> kat1 = kategorije1.ToList();
            ViewBag.Kategorije = kat1;

            ViewBag.CurrentPage = page;

            return View();
        }

        #endregion

        #region Edit
        public ActionResult Edit(int id, int page = 1)
        {
            ServiceReference1.FirmaServisClient WCF = new ServiceReference1.FirmaServisClient();
            ServiceReference1.Sud sud = WCF.DohvatiJedan(id);

            var mjesta = WCF.PopisMjesta();
            List<ServiceReference1.Mjesto> mj = mjesta.ToList();
            ViewBag.Mjesta = mj;

            var kategorije = WCF.PopisKategorija();
            List<ServiceReference1.Kategorija> kat = kategorije.ToList();
            ViewBag.Kategorije = kat;

            ViewBag.CurrentPage = page;

            return View(sud);
        }

        //[HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int page, Sud sud)
        {
            ServiceReference1.FirmaServisClient WCF = new ServiceReference1.FirmaServisClient();
            string errorNaziv_s = "";
            int errorNaziv = 0;

            string errorAdresa_s = "";
            int errorAdresa = 0;

            string pattern = "[-!?$%^&*()_+|~=`{}:'.<>,\\@#]";


            if (sud.naziv == null) errorNaziv = 1;
            else
            {
                errorNaziv = Regex.Matches(sud.naziv, pattern).Count;
            }
            if (errorNaziv != 0) errorNaziv_s = "Naziv je pogrešno unesen!";


            if (sud.adresa == null) errorAdresa = 1;
            else
            {
                errorAdresa = Regex.Matches(sud.adresa, pattern).Count;
            }

            if (errorAdresa != 0) errorAdresa_s = "Adresa je pogrešno unesena!";

            if (errorNaziv != 0 || errorAdresa != 0)
            {
                #region GET Edit
                ServiceReference1.Sud sudOld = WCF.DohvatiJedan(sud.ID);

                var mjesta = WCF.PopisMjesta();
                List<ServiceReference1.Mjesto> mj = mjesta.ToList();
                ViewBag.Mjesta = mj;

                var kategorije = WCF.PopisKategorija();
                List<ServiceReference1.Kategorija> kat = kategorije.ToList();
                ViewBag.Kategorije = kat;

                ViewBag.CurrentPage = page;

                //ViewData["PogreskaNaziv"] = errorNaziv_s;
                //ViewData["PogreskaAdresa"] = errorNaziv_s;

                return View(sudOld);

                #endregion

            }

            try
            {
                int id = sud.ID;
                string naziv = sud.naziv;
                string adresa = sud.adresa;
                int pbr = (int)sud.pbr;
                int kategorija = (int)sud.kategorija;

                WCF.UrediSud(id, naziv, adresa, pbr, kategorija);
                return RedirectToAction("Index", new { page=page});

            }
            catch (Exception e)
            {
                ViewData["Pogreška"] = e.Message;
            }
            return View();
        }
        #endregion

        #region Delete
        // GET: /Mjesto/Delete/5
        public ActionResult Delete(int id, int page=1)
        {
            ServiceReference1.FirmaServisClient WCF = new ServiceReference1.FirmaServisClient();
            ServiceReference1.Sud sud = WCF.DohvatiJedan(id);
            ViewBag.CurrentPage = page;
            return View(sud);
        }

        // POST: /Mjesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ServiceReference1.FirmaServisClient WCF = new ServiceReference1.FirmaServisClient();
                WCF.ObrisiSud(id);
            }
            catch (Exception e)
            {
                TempData["pogreskaBrisanja"] = string.Format("Sud nije moguće izbrisati jer postoje podaci koji su povezani s njime.");
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        #endregion 


    }
}