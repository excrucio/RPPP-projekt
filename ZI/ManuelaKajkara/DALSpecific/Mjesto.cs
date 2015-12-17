using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManuelaKajkara
{
    public partial class Mjesto
    {
        internal void LoadFromDB(DAL.EF.Mjesto a)
        {
            this.naziv = a.Naziv;
            this.pbr = a.PBr;
        }
    }
}
