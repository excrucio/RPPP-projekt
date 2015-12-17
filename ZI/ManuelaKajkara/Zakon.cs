using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManuelaKajkara
{
    public partial class Zakon
    {
        public int IDZakona { get; set; }

        [Required]
        [StringLength(255)]
        [RegularExpression("^(?!\\s*$).+")]
        public string Naziv { get; set; }
        public int Razina { get; set; }
        public int IDNadredenog { get; set; }
        public byte[] Dokument { get; set; }

        [RegularExpression("^(?!\\s*$).+")]
        public string Stavak { get; set; }
    }
}