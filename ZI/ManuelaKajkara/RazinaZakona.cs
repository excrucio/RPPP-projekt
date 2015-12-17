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
    public partial class RazinaZakona
    {
        public int IDRazine { get; set; }

        [Required]
        [StringLength(255)]
        [RegularExpression("^(?!\\s*$).+")]
        public string Naziv { get; set; }
    }
}