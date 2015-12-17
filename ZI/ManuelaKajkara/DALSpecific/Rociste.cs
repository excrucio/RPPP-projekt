using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManuelaKajkara
{
    public partial class Rociste
    {
        internal void LoadFromDB(DAL.EF.Rociste rociste)
        {
            this.IDRocista = rociste.IDRocista;
            this.IDProcesa = (int)rociste.IDProcesa;
            this.Datum = (DateTime)rociste.Datum;
            this.Trajanje = (decimal)rociste.Trajanje;
        }
    }
}
