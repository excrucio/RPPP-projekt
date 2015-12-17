using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManuelaKajkara;

namespace ManuelaKajkara.Models
{
    public class Edit_lista
    {
        public int IDOsobe { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Mjesto { get; set; }
        public DateTime datumRod { get; set; }
        public string ImeOca { get; set; }
        public string JMBG { get; set; }
        public List<Kazna> Kazne { get; set; }
        public string ulica { get; set; }
        public int pbr { get; set; }
    }
}