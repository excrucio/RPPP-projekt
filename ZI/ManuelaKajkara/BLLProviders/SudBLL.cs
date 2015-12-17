using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _DAL = DAL.EF;

using System.Data;
using System.ComponentModel;

// namespace ManuelaKajkara.BLLProviders
namespace ManuelaKajkara
{

    /// <summary>
    /// Koristi se u BLL sloju.
    /// </summary>
    internal static class NamespaceDoc { }

    /// <summary>
    /// Razred koji pruža objekte BLL sloja.
    /// </summary>
    public class SudBLL
    {

        /// <summary>
        /// Pružatelj funkcionalnosti DAL sloja
        /// </summary>
        private _DAL.SudDAL dal = new _DAL.SudDAL();  
        
        /// <summary>
        /// Postupak za dohvat svih sudova.
        /// </summary>
        /// <returns>Rezultat je lista svih dohvaćenih sudova.</returns>
        public BindingList<Sud> FetchAll() 
        {
            BindingList<Sud> list = new BindingList<Sud>();
            var dalCollection = dal.FetchAll();
            
            foreach (var dalObject in (IEnumerable<DAL.EF.Sud>)dalCollection)
            {
                Sud sud = new Sud();
                sud.LoadFromDB(dalObject);
                list.Add(sud);
            }

            return list;
        }

        /// <summary>
        /// Postupak za dohvat jednog suda.
        /// </summary>
        /// <param name="id">ID suda koji se dohvaća.</param>
        /// <returns>Rezultat je traženi sud.</returns>
        public Sud Fetch(int id)
        {
            Sud sud = null;
            var dalObject = dal.Fetch(id);
            if (dalObject != null)
            {
                sud = new Sud();
                sud.LoadFromDB(dalObject);
            }
            return sud;
        }

        #region FetchFor
        /// <summary>
        /// Postupak za dohvat liste sudova.
        /// </summary>
        /// <param name="pbr">PBr je poštanski broj mjesta prema kojem se dohvaćaju sudovi.</param>
        /// <returns>Rezultat je lista sudova.</returns>
        public BindingList<Sud> FetchPbr(int pbr)
        {
            BindingList<Sud> list = new BindingList<Sud>();
            var dalCollection = dal.FetchForPBR(pbr);
            if (dalCollection != null)
            {
                foreach (var dalObject in (IEnumerable<DAL.EF.Sud>)dalCollection)
                {
                    Sud sud = new Sud();
                    sud.LoadFromDB(dalObject);
                    list.Add(sud);
                }

                return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Postupak za dohvaćanje liste sudova.
        /// </summary>
        /// <param name="adr">Adr je adresa prema kojoj se dohvaćaju sudovi.</param>
        /// <returns>Rezultat je lista sudova.</returns>
        public BindingList<Sud> FetchAdr(string adr)
        {
            BindingList<Sud> list = new BindingList<Sud>();
            var dalCollection = dal.FetchForAdr(adr);
            if (dalCollection != null)
            {
                foreach (var dalObject in (IEnumerable<DAL.EF.Sud>)dalCollection)
                {
                    Sud sud = new Sud();
                    sud.LoadFromDB(dalObject);
                    list.Add(sud);
                }

                return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Postupak za dohvaćanje liste sudova.
        /// </summary>
        /// <param name="naziv">naziv je naziv prema kojem se dohvaćaju sudovi.</param>
        /// <returns>Rezultat je lista sudova ili null ako nema takvih.</returns>
        public BindingList<Sud> FetchNaziv(string naziv)
        {
            BindingList<Sud> list = new BindingList<Sud>();
            var dalCollection = dal.FetchForNaziv(naziv);
            if (dalCollection != null)
            {
                foreach (var dalObject in (IEnumerable<DAL.EF.Sud>)dalCollection)
                {
                    Sud sud = new Sud();
                    sud.LoadFromDB(dalObject);
                    list.Add(sud);
                }

                return list;
            }
            else
            {
                return null;
            }
        }
        #endregion

        //public BindingList<Sud> FetchAdr(string adr)
        //{
        //    BindingList<Sud> list = new BindingList<Sud>();
        //    var dalCollection = dal.FetchForAdr(adr);
        //    if (dalCollection != null)
        //    {
        //        foreach (var dalObject in (IEnumerable<DAL.EF.Sud>)dalCollection)
        //        {
        //            Sud sud = new Sud();
        //            sud.LoadFromDB(dalObject);
        //            list.Add(sud);
        //        }

        //        return list;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        /// <summary>
        /// Postupak za dohvat jednog suda.
        /// </summary>
        /// <param name="naziv"> naziv je naziv prema koje se dohvaća sud.</param>
        /// <returns>Rezultat vraća pronađeni sud.</returns>
        public Sud Fetch(string naziv)
        {
            Sud sud = null;
            var dalObject = dal.Fetch(naziv);
            if (dalObject != null)
            {
                //sud = new Sud();
                sud.LoadFromDB(dalObject);
            }
            return sud;
        }


        //public BindingList<Zakon> FetchAll()
        //{
        //    BindingList<Zakon> list = new BindingList<Zakon>();
        //    var dalCollection = Klasa.FetchAll();
        //    foreach (var dalObject in (IEnumerable<DAL.EF.Zakon>)dalCollection)
        //    {
        //        Zakon zakon = new Zakon();
        //        zakon.LoadFromDB(dalObject);
        //        list.Add(zakon);
        //    }
        //    return list;
        //}

        /// <summary>
        /// Postupak za dohvat liste sudova od zadane pozicije i sa zadanim brojem sudova.
        /// </summary>
        /// <param name="position">Position je indeks od kojeg dohvaćamo sudove.</param>
        /// <param name="count">Count je broj sudova koji dohvaćamo.</param>
        /// <returns>Rezultat je lista sudova.</returns>
        public BindingList<Sud> FetchFromPosition(int position, int count) 
        {
            BindingList<Sud> lista = new BindingList<Sud>();
            var dalCollection = dal.FetchFromPosition(position, count);
            if (dalCollection == null) 
            {
                return null;
            }

            else
            {
                foreach (var item in (IEnumerable<DAL.EF.Sud>)dalCollection)
                {
                    Sud sud = new Sud();
                    sud.LoadFromDB(item);
                    lista.Add(sud);
                }
                return lista;
            }  

        }

        /// <summary>
        /// Postupak za dohvat jednog suda prema zadanom indeksu.
        /// </summary>
        /// <param name="position">Postion je indeks s kojeg dohvaćamo sud.</param>
        /// <returns>Rezultat je pronađeni sud.</returns>
        public Sud FetchOneFromPosition(int position)
        {
            Sud sud = new Sud();
            var dalCollection = dal.FetchOneFromPosition(position);
            if (dalCollection == null)
            {
                return null;
            }

            else
            {
                sud.LoadFromDB(dalCollection);
            }
            return sud;

        }

        /// <summary>
        /// Postupak za dodavanje suda.
        /// </summary>
        /// <param name="a">a je sud koji dodajemo.</param>
        public void Insert(Sud a)
        {
            if ( /* validacija uspješna */  true /*string.IsNullOrEmpty(a.Error)*/)
            {
                dal.Insert(a.ID, a.naziv, a.adresa, a.pbr, a.kategorija);
                // public void Insert(int id, string naziv, string adresa, int pbr, int kategorija)
            }
            else
            {
                throw new Exception("Validacija neuspješna: " /*+ a.Error*/);
            }
        }

        /// <summary>
        /// Postupak za brisanje suda.
        /// </summary>
        /// <param name="a">a je sud koji brišemo.</param>
        public void Delete(Sud a)
        {
            _DAL.ProcesDAL dalProces = new _DAL.ProcesDAL();
            var lista = dalProces.FetchForIDsuda(a.ID);

            if (lista.Count() != 0) throw new Exception("Brisanje nije izvedivo");
            else dal.Delete(a.ID);
        }

        /// <summary>
        /// Postupak za pohranu izmjena nad sudom.
        /// </summary>
        /// <param name="a">a je sud čije podatke mijenjamo.</param>
        public void Update(Sud a)
        {
            try
            {
                dal.Update(a.ID, a.naziv, a.adresa, a.pbr, a.kategorija);
            }
            catch
            {
                throw new Exception("Validacija neuspješna: " /*+ a.Error*/);
            }
        }

        /// <summary>
        /// Postupak za osvježavanje podataka
        /// </summary>
        /// <param name="datasource">Lista objekata nad kojim se vrši osvježavanje mijenja.</param>
        /// <param name="position">Position označava indeks u listi.</param>
        /// <param name="current">Current označava trenutni objekt.</param>
        public void RefreshArtikl(object datasource, int position, object current)
        {
            BindingList<Sud> list = (BindingList<Sud>)datasource;
            Sud a = list[position];
            list[position] = Fetch(a.ID);
        }
    }
}
