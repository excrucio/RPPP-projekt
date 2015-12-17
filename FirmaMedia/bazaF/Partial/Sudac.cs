using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bazaF
{
    public partial class Sudac
    {
        public string Ime
        {
            get
            {
                if (this.Osoba == null) return "1";
                if (this.Osoba.FizickaOsoba == null) return "2";
                if (this.Osoba.FizickaOsoba.Ime == null) return "3";
                return this.Osoba.FizickaOsoba.Ime;
            }
        }

        public string Prezime
        {
            get
            {
                if (this.Osoba == null) return "";
                if (this.Osoba.FizickaOsoba == null) return "";
                if (this.Osoba.FizickaOsoba.Prezime == null) return "";
                return this.Osoba.FizickaOsoba.Prezime;
            }
        }

        public string IMePrezime
        {
            get
            {
                if (this.Osoba == null) return "";
                if (this.Osoba.FizickaOsoba == null) return "";
                if (this.Osoba.FizickaOsoba.Prezime == null) return "";
                return this.Osoba.FizickaOsoba.Ime+" "+this.Osoba.FizickaOsoba.Prezime;
            }
        }

        public string JMBG
        {
            get
            {
                if (this.Osoba == null) return "";
                if (this.Osoba.FizickaOsoba == null) return "";
                if (this.Osoba.FizickaOsoba.JMBG == null) return "";
                return this.Osoba.FizickaOsoba.JMBG;
            }
        }

        public DateTime DatumRod
        {
            get
            {
                
                if (this.Osoba == null) return DateTime.Today;
                if (this.Osoba.FizickaOsoba == null) return DateTime.Today;
                if (this.Osoba.FizickaOsoba.DatumRod == null) return DateTime.Today;
                return (DateTime)this.Osoba.FizickaOsoba.DatumRod;
            }

        }

    }
}