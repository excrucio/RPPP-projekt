using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bazaF
{
    public partial class FizickaOsoba
    {
        public string imeStr
        {
            get
            {
                return this.Ime + " " + this.Prezime;
            }
        }

    }
}
