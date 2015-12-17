using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManuelaKajkara.Models
{
    public class Vijece
    {
        public int? IDVijeca { get; set; }
        public int? IDSuca { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }

        public int? IDProcesa { get; set; }
        public string nazivProcesa { get; set; }

        public bool presjedavatelj { get; set; }


    }
}