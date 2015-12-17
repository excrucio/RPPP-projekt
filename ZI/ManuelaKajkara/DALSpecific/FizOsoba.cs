using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManuelaKajkara
{
    public partial class FizOsoba
    {
        internal void UcitajIzBaze(DAL.EF.FizickaOsoba a)
        {
            this.IDOsobe = a.IDOsobe;
            this.Ime = a.Ime;
            this.Prezime = a.Prezime;
            this.ImeOca = a.ImeOca;
            this.Datum = (DateTime)a.DatumRod;
            this.JMBG = a.JMBG;
            if (a.Poslodavac != null)
            {
                this.Poslodavac = (int)a.Poslodavac;
            }
            this.Sudac = (bool)a.Sudac;
            this.Odvjetnik = (bool)a.Odvjetnik;
            this.OIB = a.Osoba.OIB;
            this.Adresa = a.Osoba.UlicaIKucniBr;
            this.Mjesto = a.Osoba.Mjesto.Naziv;
        }
    }
}