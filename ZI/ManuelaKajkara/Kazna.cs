using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;

namespace ManuelaKajkara
{
    public partial class Kazna : IDataErrorInfo
    {
        public int IDKazne { get; set; }
        public int? IDPresude { get; set; }
        public int IDOsobe { get; set; }
        public int Vrsta { get; set; }
        public decimal Iznos { get; set; }
        public string Opis { get; set; }
        public string Presuda { get; set; }
        public string Naziv { get; set; }
        public FizickaOsoba Osoba { get; set; }

        public string Error
        {
            get
            {

                StringBuilder sb = new StringBuilder();
                string s = this["IDKazne"];
                if (!string.IsNullOrEmpty(s))
                {
                    sb.AppendLine(s);
                }
                s = this["IDPresude"];
                if (!string.IsNullOrEmpty(s))
                {
                    sb.AppendLine(s);
                }
                s = this["IDOsobe"];
                if (!string.IsNullOrEmpty(s))
                {
                    sb.AppendLine(s);
                }
                s = this["Vrsta"];
                if (!string.IsNullOrEmpty(s))
                {
                    sb.AppendLine(s);
                }
                s = this["Iznos"];
                if (!string.IsNullOrEmpty(s))
                {
                    sb.AppendLine(s);
                }
                s = this["Opis"];
                if (!string.IsNullOrEmpty(s))
                {
                    sb.AppendLine(s);
                }
                return sb.ToString();
            }
        }

        public string this[string columnName]
        {

            get
            {
                string error = "";
                switch (columnName)
                {
                    case "IDKazne":
                        if (string.IsNullOrEmpty(IDKazne.ToString()))
                        {
                            error = "IDKazne je obavezno polje!";
                        }
                        break;
                    case "IDPresude":
                        if (string.IsNullOrEmpty(IDPresude.ToString()))
                        {
                            error = "IDPresude je obavezno polje!";
                        }
                        break;
                    case "Opis":
                        if (string.IsNullOrEmpty(Opis))
                        {
                            error = "Opis je obavezno polje!";
                        }
                        break;
                    case "Naziv":
                        if (string.IsNullOrEmpty(Naziv))
                        {
                            error = "Naziv je obavezno polje!";
                        }
                        break;
                    case "IDOsobe":
                        if (IDOsobe == 0)
                        {
                            error = "IDOsobe je obavezno polje!";
                        }

                        else if ( String.IsNullOrEmpty(Opis) || String.IsNullOrWhiteSpace(Opis) || Opis.Length > 1024)
                        {
                            error = string.Format("Maksimalna duljina opisa je {0}.", 255);
                        }
                        break;
                    case "Vrsta":
                        if (Vrsta < 0)
                        {
                            error = "Vrsta je obavezno polje!";
                        }
                        break;
                    case "Iznos":
                        if (Iznos < 0)
                        {
                            error = "Iznos mora biti veći od 0!";
                        }
                        break;
                    default: break;
                }
                return error;
            }

        }
    }
}
