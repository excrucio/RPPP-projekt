using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using DAL.EF;

namespace ManuelaKajkara
{
    public partial class Kazna
    {

        internal void LoadFromDB(DAL.EF.Kazna a)
        {
            
                this.IDKazne = a.IDKazne;
                this.IDOsobe = (int)a.IDOsobe;
                this.IDPresude = (int)a.IDPresude;
                this.Vrsta = (int)a.Vrsta;
                this.Iznos = (decimal)a.Iznos;
                this.Opis = a.Opis;
                this.Osoba = new FizickaOsobaBLL().Fetch((int)a.IDOsobe);

        }
    }
}
