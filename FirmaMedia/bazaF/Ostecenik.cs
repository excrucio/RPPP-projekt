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
    
    public partial class Ostecenik
    {
        public int IDOstecenika { get; set; }
        public Nullable<int> IDOsobe { get; set; }
        public Nullable<int> IDProces { get; set; }
    
        public virtual Osoba Osoba { get; set; }
        public virtual Proces Proces { get; set; }
    }
}
