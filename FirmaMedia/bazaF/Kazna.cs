//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bazaF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kazna
    {
        public int IDKazne { get; set; }
        public Nullable<int> IDPresude { get; set; }
        public Nullable<int> IDOsobe { get; set; }
        public Nullable<int> Vrsta { get; set; }
        public Nullable<decimal> Iznos { get; set; }
        public string Opis { get; set; }
    
        public virtual Osoba Osoba { get; set; }
        public virtual TipPresude TipPresude { get; set; }
        public virtual VrstaKazne VrstaKazne { get; set; }
    }
}