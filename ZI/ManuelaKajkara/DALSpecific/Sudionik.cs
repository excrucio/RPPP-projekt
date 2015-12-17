using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManuelaKajkara
{
    public partial class Sudionik
    {
        internal void LoadFromDB(DAL.EF.Sudionik sudionik)
        {
            this.IDSudionika = sudionik.IDSudionika;
            this.IDOsobe = sudionik.IDOsobe;
            this.IDRocista = sudionik.IDRocista;
            this.Uloga = sudionik.Uloga;
        }
    }
}
