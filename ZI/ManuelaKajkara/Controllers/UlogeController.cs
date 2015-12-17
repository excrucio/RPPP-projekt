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
    public class UlogeController : Controller
    {
        
        // GET: /Uloge/
        public ActionResult Index()
        {
            return View(new UlogaBLL().FetchAll());
        }

        // GET: /Uloge/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UlogaSudionika ulogasudionika = new UlogaBLL().Fetch((int)id);
            if (ulogasudionika == null)
            {
                return HttpNotFound();
            }
            return View(ulogasudionika);
        }

        // GET: /Uloge/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Uloge/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SifraUloge,NazivUloge")] UlogaSudionika ulogasudionika)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var e in errors)
                System.Diagnostics.Debug.WriteLine("ModelState: {0}", e.ErrorMessage);
            if (ModelState.IsValid)
            {
                new UlogaBLL().Insert(ulogasudionika);
                return RedirectToAction("Index");
            }

            return View(ulogasudionika);
        }

        // GET: /Uloge/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UlogaSudionika ulogasudionika = new UlogaBLL().Fetch((int)id);
            if (ulogasudionika == null)
            {
                return HttpNotFound();
            }
            return View(ulogasudionika);
        }

        // POST: /Uloge/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SifraUloge,NazivUloge")] UlogaSudionika ulogasudionika)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UlogaBLL bll = new UlogaBLL();
                    bll.Update(ulogasudionika);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ViewData["Pogreška"] = e.Message;
                    ViewBag.error = e.Message;
                }
            }
            return View(ulogasudionika);
        }

        // GET: /Uloge/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UlogaSudionika ulogasudionika = new UlogaBLL().Fetch((int)id);
            if (ulogasudionika == null)
            {
                return HttpNotFound();
            }
            return View(ulogasudionika);
        }

        // POST: /Uloge/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UlogaBLL bll = new UlogaBLL();
            UlogaSudionika ulogasudionika = bll.Fetch(id);
            try
            {
                bll.Delete(ulogasudionika);
            }
            catch (Exception e)
            {
                TempData["pogreskaBrisanja"] = string.Format("Ulogu nije moguće izbrisati jer postoje podaci koji su povezani s njome.");
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
}
