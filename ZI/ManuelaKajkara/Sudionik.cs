using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManuelaKajkara
{
    public partial class Sudionik : IDataErrorInfo
    {
        public int IDSudionika { get; set; }

        [Required]
        public int IDOsobe { get; set; }

        [Required]
        public int IDRocista { get; set; }

        [Required]
        public int Uloga { get; set; }

        public string Error
        {
            get
            {

                StringBuilder sb = new StringBuilder();
                string s = this["IDOsobe"];
                if (!string.IsNullOrEmpty(s))
                {
                    sb.AppendLine(s);
                }
                
                s = this["Uloga"];
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
                    
                    case "IDOsobe":
                        if (IDOsobe == 0)
                        {
                            error = "Osoba je obavezno polje!";
                        }
                        break;
                   
                    case "Uloga":
                        if (Uloga == 0)
                        {
                            error = "Uloga je obavezno polje!";
                        }
                        break;
                    default: break;
                }
                return error;
            }
        }
    }
}
