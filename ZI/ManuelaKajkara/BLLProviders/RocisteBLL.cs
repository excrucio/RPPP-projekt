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
    class RocisteBLL
    {
        private RocisteDAL dal = new RocisteDAL();

        public BindingList<Rociste> FetchAll()
        {
            BindingList<Rociste> lista = new BindingList<Rociste>();
            var dalCollection = dal.FetchAll();
            foreach (var dalObject in (IEnumerable<DAL.EF.Rociste>)dalCollection)
            {
                Rociste rociste = new Rociste();
                rociste.LoadFromDB(dalObject);
                lista.Add(rociste);
            }
            return lista;
        }

        public Rociste Fetch(int IDRocista)
        {
            Rociste rociste = null;
            var dalObject = dal.Fetch(IDRocista);
            if (dalObject != null)
            {
                rociste = new Rociste();
                rociste.LoadFromDB(dalObject);
            }
            return rociste;

        }

        public BindingList<Rociste> FetchByDatum(DateTime datum)
        {
            BindingList<Rociste> lista = new BindingList<Rociste>();
            var dalObject = dal.FetchByDatum(datum);
            if (dalObject != null)
            {
                foreach (var elem in dalObject)
                {
                    Rociste rociste = new Rociste();
                    rociste.LoadFromDB(elem);
                    lista.Add(rociste);
                }
            }
            return lista;
        }

        public BindingList<Rociste> FetchByDatumInt(DateTime pocetak, DateTime kraj)
        {
            BindingList<Rociste> lista = new BindingList<Rociste>();
            var dalObject = dal.FetchByDatumInt(pocetak, kraj);
            if (dalObject != null)
            {
                foreach (var elem in dalObject)
                {
                    Rociste rociste = new Rociste();
                    rociste.LoadFromDB(elem);
                    lista.Add(rociste);
                }
            }
            return lista;
        }

        public BindingList<Rociste> FetchByProces(int IDProcesa)
        {
            BindingList<Rociste> lista = new BindingList<Rociste>();
            var dalObject = dal.FetchByProces(IDProcesa);
            if (dalObject != null)
            {
                foreach (var elem in dalObject) {
                    Rociste rociste = new Rociste();
                    rociste.LoadFromDB(elem);
                    lista.Add(rociste);
                }
            }
            return lista;
        }

        public void Insert(Rociste a)
        {
            if (string.IsNullOrEmpty(a.Error))
            {
                dal.Insert(a.IDRocista, a.IDProcesa, a.Datum, a.Trajanje);
            }
            else
            {
                throw new Exception("Validacija neuspješna: " + a.Error);
            }
        }

        public void Delete(Rociste a)
        {
            dal.Delete(a.IDRocista);
        }

        public void Update(Rociste a)
        {
            if (string.IsNullOrEmpty(a.Error))
            {
                dal.Update(a.IDRocista, a.IDProcesa, a.Datum, a.Trajanje);
            }
            else
            {
                throw new Exception("Validacija neuspješna: " + a.Error);
            }
        }

        public void RefreshRociste(object datasource, int position, object current)
        {
            BindingList<Rociste> list = (BindingList<Rociste>)datasource;
            Rociste a = list[position];
            list[position] = Fetch(a.IDRocista);
        }
    }
}
