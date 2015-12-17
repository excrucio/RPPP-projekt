using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _DAL = DAL.EF;

using System.Data;
using System.ComponentModel;

namespace ManuelaKajkara
{
    public class KategorijaBLL
    {
        private _DAL.KategorijaDAL dal = new _DAL.KategorijaDAL();

        public BindingList<Kategorija> FetchAll()
        {
            BindingList<Kategorija> list = new BindingList<Kategorija>();
            var dalCollection = dal.FetchAll();

            foreach (var dalObject in (IEnumerable<DAL.EF.KategorijaSuda>)dalCollection)
            {
                Kategorija kategorija= new Kategorija();
                kategorija.LoadFromDB(dalObject);
                list.Add(kategorija);
            }

            return list;
        }

        public Kategorija Fetch(int id)
        {
            Kategorija kat = new Kategorija();
            var dalObject = dal.Fetch(id);
            if (dalObject != null)
            {
                kat = new Kategorija();
                kat.LoadFromDB(dalObject);
            }
            return kat;

        }

        public void Add(Kategorija a)
        {
            if ( /* validacija uspješna */  true /*string.IsNullOrEmpty(a.Error)*/)
            {
                var kategorije = new KategorijaBLL().FetchAll();
                List<int> id_s = new List<int>();
                foreach (var item in kategorije) id_s.Add(item.id);
                IEnumerable<int> lista = (IEnumerable<int>)id_s;
                int new_id = lista.Max() + 1;

                dal.Insert(a.naziv, new_id);
                // public void Insert(int id, string naziv, string adresa, int pbr, int kategorija)
            }
            else
            {
                throw new Exception("Validacija neuspješna: " /*+ a.Error*/);
            }
        }

        public void Delete(Kategorija a)
        {
            _DAL.SudDAL dalSud = new _DAL.SudDAL();
            var lista = dalSud.FetchForKetgorija(a.id);
            if (lista.Count()!=0) throw new Exception("Brisanje nije izvedivo");
            else dal.Delete(a.id);
        }

        public void Update(Kategorija a)
        {
            if (    // validacija nekakva je potrebna
                //string.IsNullOrEmpty(a.Error)
                true)
            {
                dal.Update(a.id, a.naziv);
            }
            else
            {
                throw new Exception("Validacija neuspješna: " /*+ a.Error*/);
            }
        }
    }
}