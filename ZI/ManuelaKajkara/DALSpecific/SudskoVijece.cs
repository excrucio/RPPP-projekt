using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManuelaKajkara
{
    public partial class SudskoVijece
    {
        internal void LoadFromDB(DAL.EF.SudskoVijece a)
        {
            this.IDProcesa = a.IDProcesa;
            this.IDSuca = a.IDSuca;
            this.IDVijeca = a.IDSudskogVijeca;
            this.presjedavatelj = a.Predsjedavatelj;
        }
    }
}