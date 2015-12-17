using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManuelaKajkara.Models
{
    public class Osobe_lista
    {
        public FizickaOsoba osoba { get; set; }
        public IEnumerable<Kazna> kazne { get; set; }
        public int VrstaKazne { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}