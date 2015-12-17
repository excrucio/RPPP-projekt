using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManuelaKajkara
{
    public partial class SudskoVijece
    {
        public int? IDVijeca { get; set; }
        public int? IDSuca { get; set; }

        public int? IDProcesa { get; set; }

        public bool presjedavatelj { get; set; }
    }
}