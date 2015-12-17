using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;
using _DAL = DAL.EF;

namespace ManuelaKajkara.BLLProviders
{
    public class RazinaZakonaBLL
    {
        private _DAL.RazinaZakonDAL Klasa = new _DAL.RazinaZakonDAL();

        public BindingList<RazinaZakona> DajSveRazine()
        {
            BindingList<RazinaZakona> list = new BindingList<RazinaZakona>();
            var dalCollection = Klasa.DajSveRazine();
            foreach (var dalObject in (IEnumerable<DAL.EF.RazinaZakona>)dalCollection)
            {
                RazinaZakona razina = new RazinaZakona();
                razina.UcitajIzBaze(dalObject);
                list.Add(razina);
            }
            return list;
        }

        public RazinaZakona DajRazinu(int Indeks)
        {
            RazinaZakona razina = null;
            var Objekt = Klasa.DajRazinu(Indeks);
            razina = new RazinaZakona();
            razina.UcitajIzBaze(Objekt);
            return razina;
        }

        public void RazinaUnesi(RazinaZakona a)
        {
            Klasa.RazinaUnesi(a.Naziv);
        }

        public void RazinaPromijeni(RazinaZakona a)
        {
            Klasa.RazinaPromijeni(a.IDRazine, a.Naziv);
        }

        public void RazinaObrisi(int ID)
        {
            Klasa.RazinaObrisi(ID);
        }
    }
}