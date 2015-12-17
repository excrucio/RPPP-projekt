using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManuelaKajkara
{
    public partial class PravnaOsoba
    {
        internal void UcitajIzBaze(DAL.EF.PravnaOsoba a)
        {
            this.IDOsobe = a.IDOsobe;
            this.Naziv = a.Naziv;
            this.MB = a.MB;
            this.OIB = a.Osoba.OIB;
            this.Adresa = a.Osoba.UlicaIKucniBr;
            this.Mjesto = a.Osoba.Mjesto.Naziv;
        }
    }
}