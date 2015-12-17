using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManuelaKajkara
{
    public partial class RazinaZakona
    {
        internal void UcitajIzBaze(DAL.EF.RazinaZakona razina)
        {
            this.IDRazine = razina.SifraRazine;
            this.Naziv = razina.NazivRazine;
        }
    }
}