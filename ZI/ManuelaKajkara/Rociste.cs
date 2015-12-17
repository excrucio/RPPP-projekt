using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManuelaKajkara
{
    public partial class Rociste : IDataErrorInfo
    {
        public int IDRocista { get; set; }

        [Required]
        public int IDProcesa { get; set; }

        [Required]
        public System.DateTime Datum { get; set; }

        [Required]
        [Range(0, 12)]
        public decimal Trajanje { get; set; }

        public string Error
        {
            get
            {

                StringBuilder sb = new StringBuilder();
                string s = this["IDRocista"];
                if (!string.IsNullOrEmpty(s))
                {
                    sb.AppendLine(s);
                }
                s = this["IDProcesa"];
                if (!string.IsNullOrEmpty(s))
                {
                    sb.AppendLine(s);
                }
                s = this["Datum"];
                if (!string.IsNullOrEmpty(s))
                {
                    sb.AppendLine(s);
                }
                s = this["Trajanje"];
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
                    case "Proces":
                        if (IDProcesa == 0)
                        {
                            error = "Proces je obavezno polje!";
                        }
                        break;
                    case "Datum":
                        if (Datum == null)
                        {
                            error = "Datum je obavezno polje!";
                        }
                        break;
                    case "Trajanje":
                        if (Trajanje == 0)
                        {
                            error = "Trajanje je obavezno polje!";
                        }
                        else if (Trajanje > 12)
                        {
                            error = "Trajanje može biti maksimalno 12 sati!";
                        }
                        break;
                    default: break;
                }
                return error;
            }
        }
    }
}
