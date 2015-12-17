using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManuelaKajkara
{
    public partial class Kategorija
    {
        public int id { get; set; }

        [Required]
        [StringLength(60)]
        [RegularExpression("[a-zA-Z0-9,Č,č,Ć,ć,Đ,đ,Ž,ž,\\s]+")]
        public string naziv { get; set; }

    }
}