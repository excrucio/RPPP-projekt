using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManuelaKajkara.BLLProviders;


namespace ManuelaKajkara
{
    public partial class ProcesPD
    {
        internal void LoadFromDB(DAL.EF.Proces proces)
        {
            this.IDProcesa = proces.IDProcesa;
            this.Naziv = proces.Naziv;
            this.Oznaka = proces.Oznaka;
            this.Sud = (int)proces.Sud;
            this.NazivSuda = new SudBLL().Fetch(this.Sud).naziv;
            this.VrstaProcesa = new VrstaOznakeBLL().DajOznaku(this.Oznaka).Opis;
        }
    }
}
