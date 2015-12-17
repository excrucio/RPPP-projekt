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
    public class RocisteController : Controller
    {
       
        // GET: /Rociste/
        public ActionResult Index()
        {
            return View( new RocisteBLL().FetchAll());
        }

        // GET: /Rociste/Details/5
        public ActionResult Details(int? id)
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

        // GET: /Rociste/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Rociste/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDRocista,IDProcesa,Datum,Trajanje")] Rociste rociste)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var e in errors) 
                System.Diagnostics.Debug.WriteLine("ModelState: {0}", e.ErrorMessage);
            if (ModelState.IsValid)
            {
                new RocisteBLL().Insert(rociste);
                return RedirectToAction("Index");
            }

            return View(rociste);
        }

        // GET: /Rociste/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rociste rociste = new RocisteBLL().Fetch((int) id);
            if (rociste == null)
            {
                return HttpNotFound();
            }

            return View(rociste);
        }

        // POST: /Rociste/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDRocista,IDProcesa,Datum,Trajanje")] Rociste rociste)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    RocisteBLL bll = new RocisteBLL();
                    bll.Update(rociste);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ViewData["Pogreška"] = e.Message;
                    ViewBag.error = e.Message;
                }
            }
            return View(rociste);
        }

        // GET: /Rociste/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rociste rociste = new RocisteBLL().Fetch((int) id);
            if (rociste == null)
            {
                return HttpNotFound();
            }
            return View(rociste);
        }

        // POST: /Rociste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RocisteBLL bll = new RocisteBLL();
            Rociste rociste = bll.Fetch(id);
            try
            {
                bll.Delete(rociste);
            }
            catch (Exception e)
            {
                TempData["pogreskaBrisanja"] = string.Format("Ročište nije moguće izbrisati jer postoje podaci koji su povezani s njime.");
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
}
