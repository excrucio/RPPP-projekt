using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UgovoriKlase
{
    public class FOsoba
    {
        public int IDOsobe { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string ImeOca { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string JMBG { get; set; }
        public string OIB { get; set; }
        public string Adresa { get; set; }
        public string Mjesto { get; set; }
        public string Poslodavac { get; set; }
        public bool Odvjetnik { get; set; }
        public bool Sudac { get; set; }
    }
}
