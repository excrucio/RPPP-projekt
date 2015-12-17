using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManuelaKajkara
{
    public partial class Presuda
    {
        internal void LoadFromDB(DAL.EF.Presuda a)
        {
            this.IDPresude = a.IDStavke;
        }
    }
}
