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
    public class SudskoVijeceController : Controller
    {
        private RPPP10 db = new RPPP10();

        // GET: /SudskoVijece/
        public ActionResult Index()
        {
            var vijeca = new SudskoVijeceBLL().FetchAll();
            List<Vijece> popis = new List<Vijece>();

            foreach (SudskoVijece item in vijeca)
            {
                int idSuca = (int)item.IDSuca;
                int idProcesa = (int)item.IDProcesa; 
                
                var sudac = new OsobaBLL().Fetch(idSuca);
                var nazivProcesa = new SudskoVijeceBLL().Vijece_nazivProcesa(idProcesa);

                Vijece vijece = new Vijece
                {
                    IDProcesa = idProcesa,
                    IDSuca = idSuca,
                    IDVijeca = (int)item.IDVijeca,
                    ime = sudac.Ime,
                    prezime = sudac.Prezime,
                    presjedavatelj = item.presjedavatelj,
                    nazivProcesa = nazivProcesa
                };

                popis.Add(vijece);
            }

            Vijece_list model = new Vijece_list
            {
                VijeceList = popis
            };

            return View(model);	

        }

        #region Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SudskoVijece item = new SudskoVijeceBLL().Fetch((int)id);
            int idSuca = (int)item.IDSuca;
            int idProcesa = (int)item.IDProcesa;

            var sudac = new OsobaBLL().Fetch(idSuca);
            var nazivProcesa = new SudskoVijeceBLL().Vijece_nazivProcesa(idProcesa);

            Vijece vijece = new Vijece
            {
                IDProcesa = idProcesa,
                IDSuca = idSuca,
                IDVijeca = (int)item.IDVijeca,
                ime = sudac.Ime,
                prezime = sudac.Prezime,
                presjedavatelj = item.presjedavatelj,
                nazivProcesa = nazivProcesa
            };

            return View(vijece);
        }
        #endregion

        #region Create
        //// GET: /SudskoVijece/Create
        //public ActionResult Create()
        //{
        //    ViewBag.IDProcesa = new SelectList(db.Proces, "IDProcesa", "Klasa");
        //    ViewBag.IDSuca = new SelectList(db.Sudac, "IDOsobe", "IDOsobe");
        //    return View();
        //}

        //// POST: /SudskoVijece/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="IDSudskogVijeca,IDSuca,IDProcesa,Predsjedavatelj")] SudskoVijece sudskovijece)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.SudskoVijece.Add(sudskovijece);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.IDProcesa = new SelectList(db.Proces, "IDProcesa", "Klasa", sudskovijece.IDProcesa);
        //    ViewBag.IDSuca = new SelectList(db.Sudac, "IDOsobe", "IDOsobe", sudskovijece.IDSuca);
        //    return View(sudskovijece);
        //}
        #endregion

        #region Edit
        //// GET: /SudskoVijece/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SudskoVijece sudskovijece = db.SudskoVijece.Find(id);
        //    if (sudskovijece == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.IDProcesa = new SelectList(db.Proces, "IDProcesa", "Klasa", sudskovijece.IDProcesa);
        //    ViewBag.IDSuca = new SelectList(db.Sudac, "IDOsobe", "IDOsobe", sudskovijece.IDSuca);
        //    return View(sudskovijece);
        //}

        //// POST: /SudskoVijece/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="IDSudskogVijeca,IDSuca,IDProcesa,Predsjedavatelj")] SudskoVijece sudskovijece)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(sudskovijece).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.IDProcesa = new SelectList(db.Proces, "IDProcesa", "Klasa", sudskovijece.IDProcesa);
        //    ViewBag.IDSuca = new SelectList(db.Sudac, "IDOsobe", "IDOsobe", sudskovijece.IDSuca);
        //    return View(sudskovijece);
        //}
        #endregion

        #region delete
        // GET: /Mjesto/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SudskoVijece item = new SudskoVijeceBLL().Fetch((int)id);
            int idSuca = (int)item.IDSuca;
            int idProcesa = (int)item.IDProcesa;

            var sudac = new OsobaBLL().Fetch(idSuca);
            var nazivProcesa = new SudskoVijeceBLL().Vijece_nazivProcesa(idProcesa);

            Vijece vijece = new Vijece
            {
                IDProcesa = idProcesa,
                IDSuca = idSuca,
                IDVijeca = (int)item.IDVijeca,
                ime = sudac.Ime,
                prezime = sudac.Prezime,
                presjedavatelj = item.presjedavatelj,
                nazivProcesa = nazivProcesa
            };

            return View(vijece);
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
