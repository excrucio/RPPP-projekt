using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace ManuelaKajkara
{
    public partial class Kategorija
    {
        internal void LoadFromDB(DAL.EF.KategorijaSuda a)
        {
            this.id = a.SifraKatSuda;
            this.naziv = a.NazivKatSuda;
        }
    }
}