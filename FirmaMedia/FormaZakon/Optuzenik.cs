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
    
    public partial class Optuzenik
    {
        public Optuzenik()
        {
            this.Branitelj = new HashSet<Branitelj>();
            this.Optuzba = new HashSet<Optuzba>();
        }
    
        public int IDOptuzenika { get; set; }
        public Nullable<int> IDOsobe { get; set; }
        public Nullable<int> IDProces { get; set; }
    
        public virtual ICollection<Branitelj> Branitelj { get; set; }
        public virtual ICollection<Optuzba> Optuzba { get; set; }
        public virtual Osoba Osoba { get; set; }
        public virtual Proces Proces { get; set; }
    }
}
