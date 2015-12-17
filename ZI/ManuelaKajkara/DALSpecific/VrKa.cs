using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManuelaKajkara
{
    public partial class VrKa
    {
        internal void LoadFromDB(DAL.EF.VrstaKazne a)
        {
            this.Naziv = a.NazivVrste;
            this.Sifra = a.SifraVrste;
        }
    }
}