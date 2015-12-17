using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.EF;
using Firma.Framework;
using ManuelaKajkara.Models;
using System.Text.RegularExpressions;

namespace ManuelaKajkara.Controllers
{
    /// <summary>
    /// Upravljači za web aplikaciju.
    /// </summary>
    internal static class NamespaceDoc { }

    /// <summary>
    /// Razred za postavljanje pogleda oblika zaglavlje-detalji sudova i sudaca
    /// </summary>
    public class Sud_MasterController : Controller
    {
        //private RPPP10 db = new RPPP10();

        /// <summary>
        /// pageSize označava broj sudova koji će se nalaziti na jednoj stranici.
        /// </summary>
        int pageSize = 1;
                
        // GET: /Sud_Master/
        /// <summary>
        /// Postupak za prikaz početne stranice. Dohvaća popis svih sudova s pripadajućim sucima, postavlja straničenje i predaje model pogledu.
        /// </summary>
        /// <param name="page">Broj stranice.</param>
        /// <returns>Rezultat akcije upravljača prikazuje pogled Index.</returns>
        public ActionResult Index(int page = 1)
        {
            var sudovi = new SudBLL().FetchAll();
            Sud sud_novi = new SudBLL().FetchOneFromPosition(page-1);

            int count = sudovi.Count;

                

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

            var suci = new SudacBLL().FetchFromSud(sud_novi.ID);    //samo oni s tog suda

            var mjesto = new MjestoBLL().Fetch(sud_novi.pbr);
            ViewBag.Mjesto_naziv = mjesto.naziv;

            SudMaster_list model = new SudMaster_list
            {
                PagingInfo = pagingInfo,
                suci =suci.ToList(),
                sud = sud_novi
            };


            var suciSvi = new SudacBLL().FetchAll();  //svi koji postoje
            List<Sudac> listaSudaca = new List<Sudac>();
            List<int> idSvi = new List<int>();
            List<int> idPostojeci = new List<int>();

            foreach (Sudac s in suciSvi)
                idSvi.Add(s.IDOsobe);

            foreach (Sudac s in suci)
                idPostojeci.Add(s.IDOsobe);

            foreach (int item in idSvi)
            {
                if (!idPostojeci.Contains(item))
                {
                    Sudac sudac = new SudacBLL().FetchJednog(item);
                    listaSudaca.Add(sudac);
                }
            }

            ViewBag.Suci = listaSudaca;

            return View(model);	
        }

        #region details

        // GET: /Sud_Master/Details/5
        //public ActionResult Details(int? id)
        //{
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Sud sud = db.Sud.Find(id);
            //if (sud == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(sud);
        //}
        #endregion


        #region Create
        /// <summary>
        /// GET Postupak za dodavanje novog suda.
        /// </summary>
        /// <param name="page">Broj stranice.</param>
        /// <returns>Rezultat akcije upravljača prikazuje pogled Create.</returns>
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
        /// <summary>
        /// POST Postupak za potvrdu dodavanja novog suda.
        /// </summary>
        /// <param name="sud">Novi sud koji se dodaje</param>
        /// <param name="page">Broj stranice.</param>
        /// <returns>Rezultat akcije upravljača prikazuje pogled Create ili Index.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Sud sud, int page = 1)
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
            int new_id = lista.Max() + 1;

            try
            {
                original.ID = new_id;
                original.naziv = sud.naziv;
                original.adresa = sud.adresa;
                original.pbr = sud.pbr;
                original.kategorija = sud.kategorija.Value;

                //ModelState.ValidateBusinessObject(original);
                bll.Insert(original);
                return RedirectToAction("Index", new { page = page });

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


        #region Insert
        //[HttpPost]
        /// <summary>
        /// POST Postupak za pridruživanje novog suca sudu.
        /// </summary>
        /// <param name="idOsobe">ID osobe koja se dodaje.</param>
        /// <param name="id">ID suda kojem se sudac dodaje.</param>
        /// <param name="page">Broj stranice.</param>
        /// <returns>Rezultat akcije upravljača vraća pogled Index.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult InsertSudac(int? idOsobe, int id, int page)
        {
            if (idOsobe == null)
            {
                TempData["pogreskaBrisanja"] = string.Format("Nije moguće dodati prazan unos!");
                return RedirectToAction("Index", new { page =page});
            }

            if (ModelState.IsValid)
            {
                SudacBLL bll = new SudacBLL();
                bll.Update((int)idOsobe, id);
            }

            return RedirectToAction("Index", new { page =page});
        }
        #endregion



        #region edit
        // GET: /Sud_Master/Edit/5
        /// <summary>
        /// GET Postupak za prikaz stranice za uređivanje.
        /// </summary>
        /// <param name="id">ID suda koji se uređuje.</param>
        /// <param name="page">Broj stranice.</param>
        /// <returns>Rezultat akcije vraća pogled na upravljač Edit.</returns>
        public ActionResult Edit(int id, int page = 1)
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

            var sudovi = new SudBLL().FetchAll();
            //Sud sud_novi = new SudBLL().FetchOneFromPosition(page - 1);

            int count = sudovi.Count;


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

            var suci = new SudacBLL().FetchFromSud(sud.ID);    //samo oni s tog suda

            var mjesto = new MjestoBLL().Fetch(sud.pbr);
            ViewBag.Mjesto_naziv = mjesto.naziv;

            var mjesta = new MjestoBLL().FetchAll();
            List<Mjesto> mj = new List<Mjesto>();
            foreach (var item in mjesta) mj.Add(item);
            ViewBag.Mjesta = mj;

            var kategorija = new KategorijaBLL().FetchAll();
            List<Kategorija> kat = new List<Kategorija>();
            foreach (var item in kategorija) kat.Add(item);
            ViewBag.Kategorije = kat;

            var suciSvi = new SudacBLL().FetchAll();  //svi koji postoje
            List<Sudac> listaSudaca = new List<Sudac>();
            List<int> idSvi = new List<int>();
            List<int> idPostojeci = new List<int>();

            foreach (Sudac s in suciSvi)
                idSvi.Add(s.IDOsobe);

            foreach (Sudac s in suci)
                idPostojeci.Add(s.IDOsobe);

            foreach (int item in idSvi)
            {
                if (!idPostojeci.Contains(item))
                {
                    Sudac sudac = new SudacBLL().FetchJednog(item);
                    listaSudaca.Add(sudac);
                }
            }
            List<string> listaSudacaString = new List<string>();
            foreach (Sudac item in suciSvi)
            {
                string s = item.ime + " " + item.prezime;
                listaSudacaString.Add(s);
            }
            IDictionary<int, string> rjecnik = listaSudaca.ToDictionary(p => p.IDOsobe, p => p.JMBG);

            ViewBag.popisSudaca = listaSudacaString;
            ViewBag.popisSudaca1 = listaSudaca;
            ViewBag.popisSudaca2 = suciSvi;
            ViewBag.popisSudaca3 = rjecnik;

            var dropdownOptions = suciSvi.Select(d => new
            {
                id = d.IDOsobe,
                ime = d.ime
            });

            ViewBag.DropdownListOptions = new SelectList(dropdownOptions, "id", "ime");


            ViewBag.CurrentPage = page;

            SudMaster_list model = new SudMaster_list
            {
                PagingInfo = pagingInfo,
                suci = suci.ToList(),
                sud = sud
            };


            //var suciSvi = new SudacBLL().FetchAll();  //svi koji postoje
            //List<Sudac> listaSudaca = new List<Sudac>();
            //List<int> idSvi = new List<int>();
            //List<int> idPostojeci = new List<int>();

            //foreach (Sudac s in suciSvi)
            //    idSvi.Add(s.IDOsobe);

            //foreach (Sudac s in suci)
            //    idPostojeci.Add(s.IDOsobe);

            //foreach (int item in idSvi)
            //{
            //    if (!idPostojeci.Contains(item))
            //    {
            //        Sudac sudac = new SudacBLL().FetchJednog(item);
            //        listaSudaca.Add(sudac);
            //    }
            //}

            //ViewBag.Suci = listaSudaca;

            return View(model);

        }

        /// <summary>
        /// POST Postupak za spremanje izmjena nad sudom.
        /// </summary>
        /// <param name="id">ID suda čiji podaci se mijenjaju.</param>
        /// <param name="lista"></param>
        /// <param name="BrisiSuca">Lista kojom se određuje koji se suci uklanjaju s popisa suda</param>
        /// <param name="page">Broj stranice</param>
        /// <returns>Rezultat akcije vraća pogled na upravljač Edit ili Index</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, SudMaster_list lista, List<bool> BrisiSuca, int page=1)
        {
            //pageNew = 1;

            var bll = new SudBLL();
            var bllFO = new FizickaOsobaBLL();
            SudacBLL bllS = new SudacBLL();
            Sud original = bll.Fetch(lista.sud.ID);

            int error = 0;
            int error1 = 0;
            int error2 = 0;

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Validacija neuspješna");
                }

                original.naziv = lista.sud.naziv;
                original.adresa = lista.sud.adresa;
                original.pbr = lista.sud.pbr;
                original.kategorija = lista.sud.kategorija.Value;

                bll.Update(original);

                try
                {
                    if (lista.suci != null)
                    {
                        var dups = lista.suci.GroupBy(x => x.IDOsobe)
                                    .Where(x => x.Count() > 1)
                                    .Select(x => x.Key)
                                    .ToList();
                        if (dups.Count != 0)
                        {
                            error = 1;
                            throw new Exception("Validacija neuspješna");
                        }
                    
                    #region sredi suce
                    var suciStari = new SudacBLL().FetchFromSud(lista.sud.ID);
                    foreach (var item in suciStari)
                    {
                        SudacBLL sBll = new SudacBLL();
                        sBll.Delete(item.IDOsobe);
                    }

                    for (int i = 0; i < lista.suci.Count(); i++)
                    {
                        /*      //////  Nepotrebno sad  ////////
                        FizickaOsoba originalFO = bllFO.Fetch(lista.suci[i].IDOsobe);

                        string pattern = "[-!?$%^&*()_+|~=`{}:'.<>,\\@#]";
                        error = Regex.Matches(lista.suci[i].ime, pattern).Count;
                        if (lista.suci[i].ime.Equals("")) error = 1;

                        error1 = Regex.Matches(lista.suci[i].prezime, pattern).Count;
                        if (lista.suci[i].prezime.Equals("")) error1 = 1;

                        pattern = "[a-zA-Z]+";
                        error2 = Regex.Matches(lista.suci[i].JMBG, pattern).Count;
                        pattern = "[-!?$%^&*()_+|~=`{}:'.<>,\\@#]";
                        error2 = Regex.Matches(lista.suci[i].JMBG, pattern).Count;
                        if (lista.suci[i].JMBG.Length != 13) error2 = 1;
                        */
                        if (error == 0 && error1 == 0 && error2 == 0)
                        {
                            //originalFO.Ime = lista.suci[i].ime;
                            //originalFO.Prezime = lista.suci[i].prezime;
                            //originalFO.JMBG = lista.suci[i].JMBG;

                            //bllFO.UpdateSudac(originalFO);
                           

                            SudacBLL Sudacbll = new SudacBLL();
                            Sudacbll.Update(lista.suci[i].IDOsobe, lista.sud.ID);
                        }
                        else
                        {
                            ViewBag.Error_save = "Podaci su neispravno uneseni!";
                            throw new Exception("Validacija neuspješna");
                        }
                    }
                    try
                    {
                        for (int j = 0; j < BrisiSuca.Count(); j++)
                        {
                            if (BrisiSuca[j] == true)
                            {
                                bllS.Delete(lista.suci[j].IDOsobe);
                            }
                        }

                        return RedirectToAction("Index", new { page = page });

                    }
                    catch (Exception e)
                    {
                        ViewBag.Error_save = "Došlo je do pogreške, provjerite sve podatke još jednom!";
                    }
                    #endregion
                    
                }
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ViewBag.Error_save = "Došlo je do pogreške, provjerite sve podatke još jednom!";
                }
            }
            catch (Exception e)
            {
                ViewBag.Error_save = "Došlo je do pogreške, provjerite sve podatke još jednom!";
            }
            finally
            {
                //if (error != 0)  ViewBag.Error_save3 = "Ime suca je u neispravnom formatu!\n";
                //if (error1 != 0) ViewBag.Error_save1 = "Prezime suca je u neispravnom formatu!\n";
                //if (error2 != 0) ViewBag.Error_save2 = "JMBG suca je u neispravnom formatu!";
                ViewBag.Error_save = "Došlo je do pogreške, provjerite sve podatke još jednom!";

            }
            #region SetEdit
            //int page = 1;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sud sud = new SudBLL().Fetch(id);
            if (sud == null)
            {
                return HttpNotFound();
            }

            var sudovi = new SudBLL().FetchAll();
            //Sud sud_novi = new SudBLL().FetchOneFromPosition(page - 1);

            int count = sudovi.Count;


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

            var suci = new SudacBLL().FetchFromSud(sud.ID);    //samo oni s tog suda

            var mjesto = new MjestoBLL().Fetch(sud.pbr);
            ViewBag.Mjesto_naziv = mjesto.naziv;

            var mjesta = new MjestoBLL().FetchAll();
            List<Mjesto> mj = new List<Mjesto>();
            foreach (var item in mjesta) mj.Add(item);
            ViewBag.Mjesta = mj;

            var kategorija = new KategorijaBLL().FetchAll();
            List<Kategorija> kat = new List<Kategorija>();
            foreach (var item in kategorija) kat.Add(item);
            ViewBag.Kategorije = kat;

            ViewBag.CurrentPage = page;

            SudMaster_list model = new SudMaster_list
            {
                PagingInfo = pagingInfo,
                suci = suci.ToList(),
                sud = sud
            };


            var suciSvi = new SudacBLL().FetchAll();  //svi koji postoje
            List<Sudac> listaSudaca = new List<Sudac>();
            List<int> idSvi = new List<int>();
            List<int> idPostojeci = new List<int>();

            foreach (Sudac s in suciSvi)
                idSvi.Add(s.IDOsobe);

            foreach (Sudac s in suci)
                idPostojeci.Add(s.IDOsobe);

            foreach (int item in idSvi)
            {
                if (!idPostojeci.Contains(item))
                {
                    Sudac sudac = new SudacBLL().FetchJednog(item);
                    listaSudaca.Add(sudac);
                }
            }

            ViewBag.popisSudaca2 = suciSvi;
            ViewBag.Suci = listaSudaca;

            return View(model);
            #endregion
        }
        #endregion

        #region delete
        #region sudac
        /// <summary>
        /// GET Postupak za prikaz podataka o sucu koji se briše.
        /// </summary>
        /// <param name="id">ID suca koji se briše.</param>
        /// <param name="page">Broj stranice.</param>
        /// <returns>Rezultat akcije upravljača vraća pogled Delete_sudac</returns>
        public ActionResult Delete_sudac(int? id, int? page)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sudac sudac = new SudacBLL().FetchJednog(id);
            if (sudac == null)
            {
                return HttpNotFound();
            }

            ViewBag.CurrentPage = page;

            return View(sudac);
        }

        // POST: /Mjesto/Delete/5
        /// <summary>
        /// POST Postupak za brisanje suca.
        /// </summary>
        /// <param name="id">ID suca koji se briše</param>
        /// <param name="page">Broj stranice.</param>
        /// <returns>Rezultat akcije upravljača prikazuje pogled Delete_sudac ili Index</returns>
        [HttpPost, ActionName("Delete_sudac")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int page)
        {
            SudacBLL bll = new SudacBLL();
            bll.Delete(id);
            return RedirectToAction("Index", new { page=page});
        }
        #endregion

        #region sud
        /// <summary>
        /// GET postupak za prikaz podataka o sudu koji se briše.
        /// </summary>
        /// <param name="id">ID suda koji se briše.</param>
        /// <returns>Rezultat akcije upravljača vraća pogled Delete.</returns>
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
        /// <summary>
        /// POST postupak za brisanje suda.
        /// </summary>
        /// <param name="id">ID suda koji se briše.</param>
        /// <returns>Rezultat akcije upravljača vraća pogled Delete ili Index.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed1(int id)
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
                return RedirectToAction("Index");
            }
           
            return RedirectToAction("Index");
        }
        #endregion

        #endregion


        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
