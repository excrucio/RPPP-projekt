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
    public class MjestoController : Controller
    {
        private RPPP10 db = new RPPP10();

        // GET: /Mjesto/
        public ActionResult Index()
        {
            var mjestaBLL = new MjestoBLL().FetchAll();
            List<Mjesto> mjestoLista = mjestaBLL.ToList();

            Mjesto_list model = new Mjesto_list
            {
                MjestoList = mjestoLista
            };

            return View(model);		
        }

        // GET: /Mjesto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mjesto mjesto = new MjestoBLL().Fetch(id);
            if (mjesto == null)
            {
                return HttpNotFound();
            }
            return View(mjesto);
        }

        #region create

        // GET: /Mjesto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Mjesto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PBr,Naziv")] Mjesto mjesto)
        {
            if (ModelState.IsValid)
            {
                MjestoBLL bll = new MjestoBLL();
                bll.Add(mjesto);
                return RedirectToAction("Index");
            }

            return View(mjesto);
        }

        #endregion

        #region edit
        // GET: /Mjesto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mjesto mjesto = new MjestoBLL().Fetch(id);
            if (mjesto == null)
            {
                return HttpNotFound();
            }
            return View(mjesto);
        }

        // POST: /Mjesto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PBr,Naziv")] Mjesto mjesto, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MjestoBLL bll = new MjestoBLL();
                    bll.Update(mjesto, id);
                    return RedirectToAction("Index");
                }
                catch(Exception e)
                {
                    ViewData["Pogreška"] = e.Message;
                    ViewBag.error = e.Message;
                }
            }
            return View(mjesto);
        }

        #endregion

        #region delete
        // GET: /Mjesto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mjesto mjesto = new MjestoBLL().Fetch(id);
            if (mjesto == null)
            {
                return HttpNotFound();
            }
            return View(mjesto);
        }

        // POST: /Mjesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MjestoBLL bll = new MjestoBLL();
            Mjesto mjesto = bll.Fetch(id);
            try
            {
                bll.Delete(mjesto);
            }
            catch (Exception e)
            {
                TempData["pogreskaBrisanja"] = string.Format("Mjesto nije moguće izbrisati jer postoje podaci koji su povezani s njime.");
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
