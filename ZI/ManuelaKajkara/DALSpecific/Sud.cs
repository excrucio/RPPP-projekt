using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// bilo je prije namespace ManuelaKajkara.DALSpecific
namespace ManuelaKajkara
{
    public partial class Sud
    {
        internal void LoadFromDB(DAL.EF.Sud a)
        {
            this.ID = a.IDSuda;
            this.naziv = a.Naziv;
            this.adresa = a.UlicaIKucniBr;
            this.pbr = a.PBr;
            this.kategorija = a.Kategorija;
        }
    }
}
