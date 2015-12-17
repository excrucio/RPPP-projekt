using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;


namespace ManuelaKajkara
{
    class SudionikBLL
    {
        private SudionikDAL dal = new SudionikDAL();

        public BindingList<Sudionik> FetchAll()
        {
            BindingList<Sudionik> lista = new BindingList<Sudionik>();
            var dalCollection = dal.FetchAll();
            foreach (var dalObject in (IEnumerable<DAL.EF.Sudionik>)dalCollection)
            {
                Sudionik sudionik = new Sudionik();
                sudionik.LoadFromDB(dalObject);
                lista.Add(sudionik);
            }
            return lista;
        }

        public Sudionik Fetch(int IDSudionika)
        {
            Sudionik sudionik = null;
            var dalObject = dal.Fetch(IDSudionika);
            if (dalObject != null)
            {
                sudionik = new Sudionik();
                 sudionik.LoadFromDB(dalObject);
           }
            return sudionik;

        }

        public BindingList<Sudionik> FetchByOsoba(int IDOsobe)
        {
            BindingList<Sudionik> lista = new BindingList<Sudionik>();
            var dalObject = dal.FetchByOsoba(IDOsobe);
            if (dalObject != null)
            {
                foreach (var elem in dalObject) {
                    Sudionik sudionik = new Sudionik();
                    sudionik.LoadFromDB(elem);
                    lista.Add(sudionik);
                }
            }
            return lista;
        }

        public BindingList<Sudionik> FetchByRociste(int IDRocista)
        {
            BindingList<Sudionik> lista = new BindingList<Sudionik>();
            var dalObject = dal.FetchByRociste(IDRocista);
            if (dalObject != null)
            {
                foreach (var elem in dalObject)
                {
                    Sudionik sudionik = new Sudionik();
                    sudionik.LoadFromDB(elem);
                    lista.Add(sudionik);
                }
            }
            return lista;
        }

        public void Insert(Sudionik a)
        {
            if (string.IsNullOrEmpty(a.Error))
            {
                dal.Insert(a.IDSudionika, a.IDOsobe, a.IDRocista, a.Uloga);
            }
            else
            {
                throw new Exception("Validacija neuspješna: " + a.Error);
            }
        }

        public void Delete(Sudionik a)
        {
            dal.Delete(a.IDSudionika);
        }

        public void Update(Sudionik a)
        {
            if (string.IsNullOrEmpty(a.Error))
            {
                dal.Update(a.IDSudionika, a.IDOsobe, a.IDRocista, a.Uloga);
            }
            else
            {
                throw new Exception("Validacija neuspješna: " + a.Error);
            }
        }

        public void RefreshSudionik(object datasource, int position, object current)
        {
            BindingList<Sudionik> list = (BindingList<Sudionik>)datasource;
            Sudionik a = list[position];
            list[position] = Fetch(a.IDSudionika);
        }
    }
}
