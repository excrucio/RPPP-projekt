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
    public class UlogaBLL
    {
        private UlogaDAL dal = new UlogaDAL();

        public BindingList<UlogaSudionika> FetchAll()
        {
            BindingList<UlogaSudionika> lista = new BindingList<UlogaSudionika>();
            var dalCollection = dal.FetchAll();
            foreach (var dalObject in (IEnumerable<DAL.EF.UlogaSudionika>)dalCollection)
            {
                UlogaSudionika uloga = new UlogaSudionika();
                uloga.LoadFromDB(dalObject);
                lista.Add(uloga);
            }
            return lista;
        }

        public UlogaSudionika Fetch(int Sifra)
        {
            UlogaSudionika uloga = null;
            var dalObject = dal.Fetch(Sifra);
            if (dalObject != null)
            {
                uloga = new UlogaSudionika();
                uloga.LoadFromDB(dalObject);
            }
            return uloga;
        }

        public void Insert(UlogaSudionika a)
        {
            if (string.IsNullOrEmpty(a.Error))
            {
                dal.Insert(a.SifraUloge, a.NazivUloge);
            }
            else
            {
                throw new Exception("Validacija neuspješna: " + a.Error);
            }
        }

        public void Delete(UlogaSudionika a)
        {
            dal.Delete(a.SifraUloge);
        }

        public void Update(UlogaSudionika a)
        {
            if (string.IsNullOrEmpty(a.Error))
            {
                dal.Update(a.SifraUloge, a.NazivUloge);
            }
            else
            {
                throw new Exception("Validacija neuspješna: " + a.Error);
            }
        }

        public void RefreshSudionik(object datasource, int position, object current)
        {
            BindingList<UlogaSudionika> list = (BindingList<UlogaSudionika>)datasource;
            UlogaSudionika a = list[position];
            list[position] = Fetch(a.SifraUloge);
        }
    }
}
