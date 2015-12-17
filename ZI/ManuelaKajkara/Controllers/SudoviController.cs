using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManuelaKajkara.Models;
using Firma.Framework;
using System.Data;
using System.Data.Entity;
using System.Net;
using DAL.EF;
using System.ComponentModel;

namespace ManuelaKajkara.Controllers
{
    public class SudoviController : Controller
    {
        int pageSize = 20;

        //
        // GET: /Sudovi/
        public ActionResult Main(int page = 1, int sort=1)
        {
            var sudoviBLL = new SudBLL().FetchFromPosition((page - 1) * pageSize, pageSize);
            var sudoviSVI = new SudBLL().FetchAll();
            List<Sud> sudLista = sudoviBLL.ToList();
            List<Sud> sudListaPrebroji = sudoviSVI.ToList();
            int count = sudListaPrebroji.Count();
            IEnumerable<Sud> list;
            
            if (sort == 2)
            {
                list = sudoviSVI.OrderBy(m => m.naziv);
            }
            else if (sort == 3)
            {
                list = sudoviSVI.OrderBy(m => m.adresa);
            }
            else if (sort == 4)
            {
                list = sudoviSVI.OrderBy(m => m.pbr);
            }
            else
            {
                list = sudoviSVI.OrderBy(m => m.ID);
            }

            list = list.Skip((page - 1) * pageSize).Take(pageSize);

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

            Sudovi_list model = new Sudovi_list
            {
                PagingInfo = pagingInfo,
                SudList = list
            };

            return View(model);	
        }

        #region Edit
        public ActionResult Edit(int id, int page = 1)
        {
            var bll = new SudBLL();
            Sud sud = bll.Fetch(id);

            var mjesta = new MjestoBLL().FetchAll();
            List<Mjesto> mj = new List<Mjesto>();
            foreach (var item in mjesta) mj.Add(item);
            ViewBag.Mjesta = mj;

            var kategorija = new KategorijaBLL().FetchAll();
            List<Kategorija> kat = new List<Kategorija>();
            foreach (var item in kategorija) kat.Add(item);
            ViewBag.Kategorije = kat;

            ViewBag.CurrentPage = page;
            return View(sud);
        }

        //[HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int page, Sud sud)
        {
            if (!ModelState.IsValid)
            {
                var bll1 = new SudBLL();
                Sud sud1 = bll1.Fetch(sud.ID);

                var mjesta = new MjestoBLL().FetchAll();
                List<Mjesto> mj = new List<Mjesto>();
                foreach (var item in mjesta) mj.Add(item);
                ViewBag.Mjesta = mj;

                var kategorija = new KategorijaBLL().FetchAll();
                List<Kategorija> kat = new List<Kategorija>();
                foreach (var item in kategorija) kat.Add(item);
                ViewBag.Kategorije = kat;

                ViewBag.CurrentPage = page;
                return View(sud1);

            }

            var bll = new SudBLL();
            Sud original = bll.Fetch(sud.ID);

            try
            {
                original.naziv = sud.naziv;
                original.adresa = sud.adresa;
                original.pbr = sud.pbr;
                original.kategorija = sud.kategorija.Value;

                //ModelState.ValidateBusinessObject((BusinessBase)original);
                bll.Update(original);
                return RedirectToAction("Main");
            
            }
            catch(Exception e)
            {
                ViewData["Pogreška"] = e.Message;
            }
            return View();
        }
        #endregion

        #region Create
        public ActionResult Create(int page = 1)
        {
            var mjesta = new MjestoBLL().FetchAll();
            List<Mjesto> mj = new List<Mjesto>();
            foreach (var item in mjesta) mj.Add(item);
            ViewBag.Mjesta = mj;

            var kategorija = new KategorijaBLL().FetchAll();
            List<Kategorija> kat = new List<Kategorija>();
            foreach (var item in kategorija) kat.Add(item);
            ViewBag.Kategorije = kat;

            return View();
        }

        //[HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Sud sud, int page=1 )
        {
            if (!ModelState.IsValid)
            {
                var mjesta1 = new MjestoBLL().FetchAll();
                List<Mjesto> mj1 = new List<Mjesto>();
                foreach (var item in mjesta1) mj1.Add(item);
                ViewBag.Mjesta = mj1;

                var kategorija1 = new KategorijaBLL().FetchAll();
                List<Kategorija> kat1 = new List<Kategorija>();
                foreach (var item in kategorija1) kat1.Add(item);
                ViewBag.Kategorije = kat1;

                return View();
            }

            var bll = new SudBLL();
            Sud original = new Sud();

            var sudovi = new SudBLL().FetchAll();
            List<int> id_s = new List<int>();
            foreach (var item in sudovi) id_s.Add(item.ID);
            IEnumerable<int> lista = (IEnumerable<int>)id_s;
            int new_id=lista.Max()+1;

            try
            {
                original.ID = new_id;
                original.naziv = sud.naziv;
                original.adresa = sud.adresa;
                original.pbr = sud.pbr;
                original.kategorija = sud.kategorija.Value;

                //ModelState.ValidateBusinessObject(original);
                bll.Insert(original);
                return RedirectToAction("Main");

            }
            catch (Exception e)
            {
                ViewData["Pogreška"] = e.Message;
            }
            var mjesta = new MjestoBLL().FetchAll();
            List<Mjesto> mj = new List<Mjesto>();
            foreach (var item in mjesta) mj.Add(item);
            ViewBag.Mjesta = mj;

            var kategorija = new KategorijaBLL().FetchAll();
            List<Kategorija> kat = new List<Kategorija>();
            foreach (var item in kategorija) kat.Add(item);
            ViewBag.Kategorije = kat;

            return View();
        }

        #endregion

        #region Search
        public ActionResult Search(int page = 1)
        {
            var mjesta = new MjestoBLL().FetchAll();
            List<Mjesto> mj = new List<Mjesto>();
            foreach (var item in mjesta) mj.Add(item);
            ViewBag.Mjesta = mj;

            var kategorija = new KategorijaBLL().FetchAll();
            List<Kategorija> kat = new List<Kategorija>();
            foreach (var item in kategorija) kat.Add(item);
            ViewBag.Kategorije = kat;
            ViewBag.SudNew = false;
            //ViewBag.CurrentPage = page;
            return View();
        }

        [HttpPost]
        public ActionResult Search(Sud sud, int page=1)
        {
            var bll = new SudBLL();
            Sud original = bll.Fetch(sud.ID);
            IEnumerable<Sud> sudovi_pbr = new List<Sud>();
            IEnumerable<Sud> sudovi_naziv = new List<Sud>();
            IEnumerable<Sud> sudovi_adresa = new List<Sud>();
            IEnumerable<Sud> model = null;
            List<Sud> model_pom;
            Sudovi_list lista = new Sudovi_list();
            ViewBag.SudNew = false;

            try
            {
                if (sud.pbr != null)
                {
                    var sudovi = new SudBLL().FetchPbr((int)sud.pbr);
                    sudovi_pbr = (IEnumerable<Sud>)sudovi;
                    ViewBag.SudNew = true;
                    model = sudovi_pbr;
                }
                if (sud.naziv != null)
                {
                    ViewBag.SudNew = true;
                    var sudovi = new SudBLL().FetchNaziv((string)sud.naziv);
                    sudovi_naziv = (IEnumerable<Sud>)sudovi;
                    if (model != null)
                    {
                        model_pom = new List<Sud>();
                        foreach (var item in model)
                        {
                            foreach( var item2 in sudovi_naziv)
                            {
                                if (item.naziv == item2.naziv) model_pom.Add(item2);
                            }
                        }
                        model = (IEnumerable<Sud>)model_pom;
                        //model = model.Intersect(sudovi_naziv);
                        //model = model.Join(sudovi_naziv, x=>x.);
                        //var results = original.Where(x => yourEnumerable.Contains(x.ID));
                       
                    }
                    else model = sudovi_naziv;
                }
                if (sud.adresa != null)
                {
                    ViewBag.SudNew = true;
                    var sudovi = new SudBLL().FetchAdr((string)sud.adresa);
                    sudovi_adresa = (IEnumerable<Sud>)sudovi;

                    if (model != null)
                    {
                        model_pom = new List<Sud>();
                        foreach (var item in model)
                        {
                            foreach (var item2 in sudovi_adresa)
                            {
                                if (item.adresa == item2.adresa) model_pom.Add(item2);
                            }
                        }
                        model = (IEnumerable<Sud>)model_pom;
                    }
                    else model = sudovi_adresa;

                }
                
                //ViewBag
                var mjesta = new MjestoBLL().FetchAll();
                List<Mjesto> mj = new List<Mjesto>();
                foreach (var item in mjesta) mj.Add(item);
                ViewBag.Mjesta = mj;

                var kategorija = new KategorijaBLL().FetchAll();
                List<Kategorija> kat = new List<Kategorija>();
                foreach (var item in kategorija) kat.Add(item);
                ViewBag.Kategorije = kat;

                List<Sud> sudListaPrebroji = model.ToList();
                int count = sudListaPrebroji.Count();

                #region pozabavi se stranicama
                PagingInfo pagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = count
                };

                if (pagingInfo.TotalPages < page)
                {
                    page = pagingInfo.TotalPages;
                    pagingInfo.CurrentPage = page;
                }
                #endregion

                lista = new Sudovi_list
                {
                    PagingInfo = pagingInfo,
                    SudList = model
                };

            }
            catch (Exception e)
            {
                ViewData["Pogreška"] = e.Message;
            }

            ViewBag.popis = model;
            return View();
        }


        #endregion

        #region Details
        public ActionResult Details(int id)
        {
            Sud sud = new SudBLL().Fetch(id);
            if (sud == null)
            {
                return HttpNotFound();
            }
            return View(sud);
        }
        #endregion

        #region delete
        // GET: /Mjesto/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sud sud = new SudBLL().Fetch(id);
            if (sud == null)
            {
                return HttpNotFound();
            }
            return View(sud);
        }

        // POST: /Mjesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SudBLL bll = new SudBLL();
            Sud sud = bll.Fetch(id);

            try
            {
                bll.Delete(sud);
                SudacBLL bllS = new SudacBLL();
                bllS.DeleteSud(id); //svim sucima koji sude na sudu koji se briše, stavi null za idSuda
            }
            catch (Exception e)
            {
                TempData["pogreskaBrisanja"] = string.Format("Sud nije moguće izbrisati jer postoje podaci koji su povezani s njime.");
                return RedirectToAction("Main");
            }

            return RedirectToAction("Main");
        }
        #endregion 
    }

}