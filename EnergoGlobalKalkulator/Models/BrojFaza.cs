//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnergoGlobalKalkulator.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BrojFaza
    {
        public BrojFaza()
        {
            this.Koraks = new HashSet<Korak>();
        }
    
        public int Id { get; set; }
        public Nullable<decimal> Broj_faza { get; set; }
    
        public virtual ICollection<Korak> Koraks { get; set; }
    }
}
