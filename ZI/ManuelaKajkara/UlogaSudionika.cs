using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace ManuelaKajkara
{
    public partial class UlogaSudionika : IDataErrorInfo
    {
        public int SifraUloge { get; set; }
        
        [Required]
        public string NazivUloge { get; set; }

        public string Error
        {
            get
            {

                StringBuilder sb = new StringBuilder();
                string s = this["NazivUloge"];
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
                   
                    case "NazivUloge":
                        if (string.IsNullOrWhiteSpace(NazivUloge))
                        {
                            error = "Naziv uloge je obavezno polje!";
                        }
                        break;
                   default: break;
                }
                return error;
            }
        }
    }
}
