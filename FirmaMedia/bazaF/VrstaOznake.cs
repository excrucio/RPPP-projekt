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
    
    public partial class VrstaOznake
    {
        public VrstaOznake()
        {
            this.Proces = new HashSet<Proces>();
        }
    
        public string SifraOznake { get; set; }
        public string OpisOznake { get; set; }
    
        public virtual ICollection<Proces> Proces { get; set; }
    }
}
