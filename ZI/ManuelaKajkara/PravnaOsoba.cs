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
    public partial class PravnaOsoba
    {

        public int IDOsobe { get; set; }

        [Required]
        [StringLength(255)]
        public string Naziv { get; set; }

        [Required]
        [StringLength(7, MinimumLength = 7)]
        [RegularExpression("^[0-9]+$")]
        public string MB { get; set; }

        [Required]
        [StringLength(255)]
        public string Adresa { get; set; }

        [Required]
        [StringLength(11, MinimumLength=11)]
        [RegularExpression("^[0-9]+$")]
        public string OIB { get; set; }

        [Required]
        public string Mjesto { get; set; }
    }
}