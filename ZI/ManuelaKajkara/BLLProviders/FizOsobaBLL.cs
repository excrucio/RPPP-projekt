using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using _DAL = DAL.EF;
using System.Data;

namespace ManuelaKajkara
{
    public class FizOsobaBLL
    {
        private _DAL.FizOsobaDAL Klasa = new _DAL.FizOsobaDAL();

        public BindingList<FizOsoba> DajSveOsobe()
        {
            BindingList<FizOsoba> list = new BindingList<FizOsoba>();
            var dalCollection = Klasa.DajSve();
            foreach (var dalObject in (IEnumerable<DAL.EF.FizickaOsoba>)dalCollection)
            {
                FizOsoba osoba = new FizOsoba();
                osoba.UcitajIzBaze(dalObject);
                list.Add(osoba);
            }
            return list;
        }

        public FizOsoba DajJednuID(int ID)
        {
            FizOsoba osoba = null;
            var Objekt = Klasa.DajJednuID(ID);
            osoba = new FizOsoba();
            osoba.UcitajIzBaze(Objekt);
            return osoba;
        }

        public FizOsoba DajJednuIndeks(int Indeks)
        {
            FizOsoba osoba = null;
            var Objekt = Klasa.DajJednuIndeks(Indeks);
            osoba = new FizOsoba();
            osoba.UcitajIzBaze(Objekt);
            return osoba;
        }

        public void Unesi(FizOsoba a)
        {
            Klasa.Unesi(a.Ime, a.Prezime, a.ImeOca, a.Datum, a.JMBG, a.Poslodavac, a.Odvjetnik, a.Sudac, a.OIB, a.Adresa, a.Mjesto);
        }

        public void Promijeni(FizOsoba a)
        {
            Klasa.Promijeni(a.IDOsobe, a.Ime, a.Prezime, a.ImeOca, a.Datum, a.JMBG, a.Poslodavac, a.Odvjetnik, a.Sudac, a.OIB, a.Adresa, a.Mjesto);
        }

        public void Brisi(int ID)
        {
            Klasa.Brisi(ID);
        }
    }
}