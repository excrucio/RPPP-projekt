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
    
    public partial class Optuzba
    {
        public int IDOptuzbe { get; set; }
        public Nullable<int> IDOptuzenika { get; set; }
        public Nullable<int> IDZakona { get; set; }
        public Nullable<int> IDPresude { get; set; }
    
        public virtual Optuzenik Optuzenik { get; set; }
        public virtual Presuda Presuda { get; set; }
        public virtual Zakon Zakon { get; set; }
    }
}
