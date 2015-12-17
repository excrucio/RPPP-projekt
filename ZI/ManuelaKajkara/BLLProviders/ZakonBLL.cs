using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;
using _DAL = DAL.EF;

namespace ManuelaKajkara.BLLProviders
{
    public class ZakonBLL
    {
        private _DAL.ZakonDAL Klasa = new _DAL.ZakonDAL();

        public BindingList<Zakon> DajSveZakone()
        {
            BindingList<Zakon> list = new BindingList<Zakon>();
            var dalCollection = Klasa.DajSveZakone();
            foreach (var dalObject in (IEnumerable<DAL.EF.Zakon>)dalCollection)
            {
                Zakon zakon = new Zakon();
                zakon.UcitajIzBaze(dalObject);
                list.Add(zakon);
            }
            return list;
        }

        public Zakon DajZakon(int Indeks, int i)
        {
            Zakon zakon = null;
            var Objekt = Klasa.DajZakon(Indeks, i);
            zakon = new Zakon();
            zakon.UcitajIzBaze(Objekt);
            return zakon;
        }

        public Zakon DajZakon(int Indeks)
        {
            Zakon zakon = null;
            var Objekt = Klasa.DajZakon(Indeks);
            zakon = new Zakon();
            zakon.UcitajIzBaze(Objekt);
            return zakon;
        }

        public Zakon DajZakon(string Ime)
        {
            Zakon zakon = null;
            var Objekt = Klasa.DajZakon(Ime);
            zakon = new Zakon();
            zakon.UcitajIzBaze(Objekt);
            return zakon;
        }

        public BindingList<Zakon> DajClanke(int IDNad)
        {
            BindingList<Zakon> list = new BindingList<Zakon>();
            var dalCollection = Klasa.DajClanke(IDNad);
            foreach (var dalObject in (IEnumerable<DAL.EF.Zakon>)dalCollection)
            {
                Zakon zakon = new Zakon();
                zakon.UcitajIzBaze(dalObject);
                list.Add(zakon);
            }
            return list;
        }

        public Zakon DajClanak(string Ime)
        {
            Zakon zakon = null;
            var Objekt = Klasa.DajClanak(Ime);
            zakon = new Zakon();
            zakon.UcitajIzBaze(Objekt);
            return zakon;
        }

        public Zakon DajClanak(int IDClanak, int Indeks)
        {
            Zakon zakon = null;
            var Objekt = Klasa.DajClanak(IDClanak, Indeks);
            zakon = new Zakon();
            zakon.UcitajIzBaze(Objekt);
            return zakon;
        }

        public Zakon DajClanak(int IDClanak)
        {
            Zakon zakon = null;
            var Objekt = Klasa.DajClanak(IDClanak);
            zakon = new Zakon();
            zakon.UcitajIzBaze(Objekt);
            return zakon;
        }

        public BindingList<Zakon> DajStavke(int IDNad)
        {
            BindingList<Zakon> list = new BindingList<Zakon>();
            var dalCollection = Klasa.DajStavke(IDNad);
            foreach (var dalObject in (IEnumerable<DAL.EF.Zakon>)dalCollection)
            {
                Zakon zakon = new Zakon();
                zakon.UcitajIzBaze(dalObject);
                list.Add(zakon);
            }
            return list;
        }

        public Zakon DajStavak(int IDStavak)
        {
            Zakon zakon = null;
            var Objekt = Klasa.DajStavak(IDStavak);
            zakon = new Zakon();
            zakon.UcitajIzBaze(Objekt);
            return zakon;
        }

        public Zakon DajStavak(string Ime)
        {
            Zakon zakon = null;
            var Objekt = Klasa.DajStavak(Ime);
            zakon = new Zakon();
            zakon.UcitajIzBaze(Objekt);
            return zakon;
        }

        public void ZakonUnesi(Zakon a, int i)
        {
            Klasa.ZakonUnesi(i, a.Naziv, a.Razina, a.IDNadredenog, a.Stavak);
        }

        public void ZakonPromijeni(int i, Zakon a)
        {
            a.Razina = i;
            Klasa.ZakonPromijeni(i, a.IDZakona,a.Naziv,a.Razina,a.IDNadredenog,a.Stavak);
        }

        public void BrisiJedan(int ID)
        {
            Klasa.BrisiJedan(ID);
        }

        public void BrisiVise(int IDNad)
        {
            Klasa.BrisiVise(IDNad);
        }
    }
}