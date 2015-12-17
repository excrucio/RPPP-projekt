using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using _DAL = DAL.EF;

namespace ManuelaKajkara
{
    public class PravnaOsobaBLL
    {
        private _DAL.PravnaOsobaDAL Klasa = new _DAL.PravnaOsobaDAL();

        public BindingList<PravnaOsoba> DajSveOsobe()
        {
            BindingList<PravnaOsoba> list = new BindingList<PravnaOsoba>();
            var dalCollection = Klasa.DajSve();
            foreach (var dalObject in (IEnumerable<DAL.EF.PravnaOsoba>)dalCollection)
            {
                PravnaOsoba osoba = new PravnaOsoba();
                osoba.UcitajIzBaze(dalObject);
                list.Add(osoba);
            }
            return list;
        }

        public PravnaOsoba DajJednuID(int ID)
        {
            PravnaOsoba osoba = null;
            var Objekt = Klasa.DajJednuID(ID);
            osoba = new PravnaOsoba();
            osoba.UcitajIzBaze(Objekt);
            return osoba;
        }

        public PravnaOsoba DajJednuIndeks(int Indeks)
        {
            PravnaOsoba osoba = null;
            var Objekt = Klasa.DajJednuIndeks(Indeks);
            osoba = new PravnaOsoba();
            osoba.UcitajIzBaze(Objekt);
            return osoba;
        }

        public void Unesi(PravnaOsoba a)
        {
            Klasa.Unesi(a.Naziv, a.MB, a.OIB, a.Adresa, a.Mjesto);
        }

        public void Promijeni(PravnaOsoba a)
        {
            Klasa.Promijeni(a.IDOsobe, a.Naziv, a.MB, a.OIB, a.Adresa, a.Mjesto);
        }

        public void Brisi(int ID)
        {
            Klasa.Brisi(ID);
        }
    }
}