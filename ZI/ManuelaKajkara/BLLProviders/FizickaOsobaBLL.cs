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
    public class FizickaOsobaBLL
    {
        private FizickaOsobaDAL dal = new FizickaOsobaDAL();

        public BindingList<FizickaOsoba> FetchAll()
        {
            BindingList<FizickaOsoba> lista = new BindingList<FizickaOsoba>();
            var dalCollection = dal.FetchAll();
            foreach (var dalObject in (IEnumerable<DAL.EF.FizickaOsoba>)dalCollection)
            {
                FizickaOsoba fizOsoba = new FizickaOsoba();
                fizOsoba.LoadFromDB(dalObject);
                lista.Add(fizOsoba);
            }
            return lista;
        }

        public FizickaOsoba Fetch(int IDOsobe)
        {
            FizickaOsoba fizOsoba = null;
            var dalObject = dal.Fetch(IDOsobe);
            if (dalObject != null)
            {
                fizOsoba = new FizickaOsoba();
                fizOsoba.LoadFromDB(dalObject);
            }
            return fizOsoba;

        }

        public void UpdateSudac(FizickaOsoba a)
        {
            try
            {
                //public void UpdateSudac(int id, string ime, string prezime, string jmbg)
                dal.UpdateSudac(a.IDOsobe, a.Ime, a.Prezime, a.JMBG);
            }
            catch
            {
                throw new Exception("Validacija neuspješna!");
            }
        }
        
    }
}
