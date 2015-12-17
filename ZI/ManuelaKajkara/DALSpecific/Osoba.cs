using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.EF;
using System.ComponentModel;

namespace ManuelaKajkara
{
    public partial class FizickaOsoba
    {

        internal void LoadFromDB(DAL.EF.FizickaOsoba a)
        {
            this.IDOsobe = a.IDOsobe;
            this.Ime = a.Ime;
            this.Prezime = a.Prezime;
            this.ImeOca = a.ImeOca;
            this.DatumRod = (DateTime)a.DatumRod;
            this.JMBG = a.JMBG;
            this.ImePrezime = a.Ime + ' ' + a.Prezime;
            this.Adresa = new OsobaBLL().DajAdresu(a.IDOsobe);
            this.ulica = this.Adresa.Split(',')[0].Trim();
            this.pbr = new MjestoBLL().DajPoImenu(this.Adresa.Split(',')[1].Trim());
        }
    }

}
