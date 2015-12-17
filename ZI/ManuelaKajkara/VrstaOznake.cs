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
    public partial class VrstaOznake
    {
        [Required]
        [StringLength(7)]
        [RegularExpression("^(?!\\s*$).+")]
        public string SifraOznake { get; set; }

        [Required]
        [StringLength(255)]
        [RegularExpression("^(?!\\s*$).+")]
        public string Opis { get; set; }
    }
}