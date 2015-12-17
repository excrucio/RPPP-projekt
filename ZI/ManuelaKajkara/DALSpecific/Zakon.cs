using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManuelaKajkara
{
    public partial class Zakon
    {
        internal void UcitajIzBaze(DAL.EF.Zakon zakon)
        {
            this.IDZakona = zakon.IDZakona;
            this.Naziv = zakon.Naziv;
            if (zakon.Razina == null)
            {
                this.Razina = -1;
            }
            else this.Razina = (int)zakon.Razina;
            if (zakon.IDNadredenog == null)
            {
                this.IDNadredenog = -1;
            }
            else this.IDNadredenog = (int)zakon.IDNadredenog;
            this.Dokument = zakon.Dokument;
        }
    }
}