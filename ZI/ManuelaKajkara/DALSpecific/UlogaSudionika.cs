using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManuelaKajkara
{
    public partial class UlogaSudionika
    {
        internal void LoadFromDB(DAL.EF.UlogaSudionika uloga)
        {
            this.SifraUloge = uloga.SifraUloge;
            this.NazivUloge = uloga.NazivUloge;
        }
    }
}
