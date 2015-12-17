using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManuelaKajkara.Models
{
    public class Zakoni_lista
    {
        public Zakon zakon{ get; set; }
        public IEnumerable<Zakon> clanci { get; set; }
        public IEnumerable<Zakon> stavci { get; set; }
        public PagingInfo PagingInfoZakoni { get; set; }
    }
}