using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;
using _DAL = DAL.EF;

namespace ManuelaKajkara.BLLProviders
{
    public class VrstaOznakeBLL
    {
        private _DAL.VrstaOznakeDAL Klasa = new _DAL.VrstaOznakeDAL();

        public BindingList<VrstaOznake> DajSveOznake()
        {
            BindingList<VrstaOznake> list = new BindingList<VrstaOznake>();
            var dalCollection = Klasa.DajSveOznake();
            foreach (var dalObject in (IEnumerable<DAL.EF.VrstaOznake>)dalCollection)
            {
                VrstaOznake razina = new VrstaOznake();
                razina.UcitajIzBaze(dalObject);
                list.Add(razina);
            }
            return list;
        }

        public VrstaOznake DajOznaku(string Sifra)
        {
            VrstaOznake oznaka = null;
            var Objekt = Klasa.DajOznaku(Sifra);
            oznaka = new VrstaOznake();
            oznaka.UcitajIzBaze(Objekt);
            return oznaka;
        }

        public void UnesiOznaku(VrstaOznake a)
        {
            Klasa.UnesiOznaku(a.SifraOznake, a.Opis);
        }

        public void PromijeniOznaku(string sifra, VrstaOznake a)
        {
            Klasa.PromijeniOznaku(sifra, a.SifraOznake, a.Opis);
        }


        public void ObrisiOznaku(string Sifra)
        {
            Klasa.RazinaObrisi(Sifra);
        }
    }
}