//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZOO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cleanings
    {
        public int CleaningId { get; set; }
        public int EmployeeId { get; set; }
        public int PavilionId { get; set; }
        public System.DateTime CleaningDate { get; set; }
        public int TimeForCleaning { get; set; }
    
        public virtual Employees Employees { get; set; }
        public virtual Pavilions Pavilions { get; set; }
    }
}
