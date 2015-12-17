using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ManuelaKajkara.DALSpecific
namespace ManuelaKajkara
{
    public partial class Sudac
    {
        internal void LoadFromDB(DAL.EF.Sudac a)
        {
            this.IDOsobe = a.IDOsobe;
            this.IDSuda = a.IDSuda;
        }

        internal void LoadFromDB(DAL.EF.Sudac a, DAL.EF.FizickaOsoba b)
        {
            this.IDOsobe = a.IDOsobe;
            this.IDSuda = a.IDSuda;

            this.ime = b.Ime;
            this.prezime = b.Prezime;
            this.JMBG = b.JMBG;
        }
    }
}
