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
    public partial class FizOsoba
    {
        public int IDOsobe { get; set; }

        [Required]
        [StringLength(255)]
        public string Ime { get; set; }

        [Required]
        [StringLength(255)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(255)]
        public string ImeOca { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Datum { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 13)]
        [RegularExpression("^[0-9]+$")]
        public string JMBG { get; set; }

        public int Poslodavac { get; set; }

        [Required]
        public bool Odvjetnik { get; set; }

        [Required]
        public bool Sudac { get; set; }

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