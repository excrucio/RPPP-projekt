//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RPPP
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tuzitelj
    {
        public int IDTuzitelja { get; set; }
        public Nullable<int> IDOsobe { get; set; }
        public Nullable<int> IDProcesa { get; set; }
    
        public virtual FizickaOsoba FizickaOsoba { get; set; }
        public virtual Proces Proces { get; set; }
    }
}
