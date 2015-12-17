using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManuelaKajkara
{
    public partial class VrstaOznake
    {
        internal void UcitajIzBaze(DAL.EF.VrstaOznake Oznaka)
        {
            this.SifraOznake = Oznaka.SifraOznake;
            this.Opis = Oznaka.OpisOznake;
        }
    }
}