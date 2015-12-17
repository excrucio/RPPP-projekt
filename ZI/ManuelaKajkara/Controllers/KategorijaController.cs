using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.EF;
using System.ComponentModel;
using ManuelaKajkara.Models;


namespace ManuelaKajkara.Controllers
{
    public class KategorijaController : Controller
    {
        private RPPP10 db = new RPPP10();


        // GET: /Kategorija/
        public ActionResult Index()
        {
            var kategorijaBLL = new KategorijaBLL().FetchAll();
            List<Kategorija> kategorijaLista = kategorijaBLL.ToList();

            Kategorija_list model = new Kategorija_list
            {
                KategorijaList = kategorijaLista
            };

            return View(model);	
        }

        // GET: /Kategorija/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var kategorijasuda = new KategorijaBLL().Fetch(id);
            if (kategorijasuda == null)
            {
                return HttpNotFound();
            }
            return View(kategorijasuda);
        }

        #region create

        // GET: /Kategorija/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Kategorija/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,naziv")] Kategorija kategorijasuda)
        {
            if (ModelState.IsValid)
            {
                KategorijaBLL kat = new KategorijaBLL();
                kat.Add(kategorijasuda);
                return RedirectToAction("Index");
            }

            return View(kategorijasuda);
        }
        #endregion

        #region edit
        // GET: /Kategorija/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategorijaBLL bll = new KategorijaBLL();
            Kategorija kategorijasuda = bll.Fetch(id);
            if (kategorijasuda == null)
            {
                return HttpNotFound();
            }
            return View(kategorijasuda);
        }

        // POST: /Kategorija/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,naziv")] Kategorija kategorijasuda)
        {
            if (ModelState.IsValid)
            {
                KategorijaBLL bll = new KategorijaBLL();
                bll.Update(kategorijasuda);
                //db.Entry(kategorijasuda).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategorijasuda);
        }
        #endregion

        #region delete

        // GET: /Kategorija/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            KategorijaBLL bll = new KategorijaBLL();
            Kategorija kategorijasuda = bll.Fetch(id);
            if (kategorijasuda == null)
            {
                return HttpNotFound();
            }
            return View(kategorijasuda);
        }

        // POST: /Kategorija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KategorijaBLL bll = new KategorijaBLL();
            Kategorija kategorijasuda = bll.Fetch(id);
            try
            {
                bll.Delete(kategorijasuda);
            }
            catch (Exception e)
            {
                TempData["pogreskaBrisanja"] = string.Format("Kategoriju nije moguće izbrisati jer postoje podaci koji su povezani s njome.");
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
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
