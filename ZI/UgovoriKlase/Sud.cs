using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UgovoriKlase
{
    public class Sud
    {
        public int ID { get; set; }

        [Required]
        [StringLength(60)]
        [RegularExpression("[a-zA-Z0-9,Č,č,Ć,ć,Đ,đ,Ž,ž,Š,š\\s]+")]
        public string Naziv { get; set; }

        [Required]
        [StringLength(60)]
        [RegularExpression("[a-zA-Z0-9,Č,č,Ć,ć,Đ,đ,Ž,ž,\\s]+")]
        public string Adresa { get; set; }

        [Required]
        public int PBr { get; set; }

        [Required]
        public int kategorija { get; set; }
    }
}
