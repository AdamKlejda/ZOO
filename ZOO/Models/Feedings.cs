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
    
    public partial class Feedings
    {
        public int FeedingId { get; set; }
        public int AnimalGroupId { get; set; }
        public int EmployeeId { get; set; }
        public int FoodProductsId { get; set; }
        public int TimeForFeeding { get; set; }
        public System.DateTime FeedingDate { get; set; }
        public Nullable<int> Quantity { get; set; }
    
        public virtual AnimalGroups AnimalGroups { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual FoodProducts FoodProducts { get; set; }
    }
}
