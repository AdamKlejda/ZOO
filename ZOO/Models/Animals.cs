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
    
    public partial class Animals
    {
        public int AnimalId { get; set; }
        public int AnimalGroupId { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public System.DateTime BirthDate { get; set; }
        public Nullable<System.DateTime> DeathDate { get; set; }
        public string Sex { get; set; }
    
        public virtual AnimalGroups AnimalGroups { get; set; }
    }
}
