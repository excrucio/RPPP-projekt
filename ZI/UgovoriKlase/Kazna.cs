using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UgovoriKlase
{
    public class Kazna
    {
        public int IDKazne { get; set; }
        public int? IDPresude { get; set; }
        public int IDOsobe { get; set; }
        public int Vrsta { get; set; }
        public decimal Iznos { get; set; }
        public string Opis { get; set; }
        public string Presuda { get; set; }
        public string Naziv { get; set; }
        public FOsoba Osoba { get; set; }
    }
}
