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
    using System.ComponentModel.DataAnnotations;

    public partial class Employees
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employees()
        {
            this.Cleanings = new HashSet<Cleanings>();
            this.Feedings = new HashSet<Feedings>();
        }
    
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "The name is required")]
        [MinLength(3, ErrorMessage = "Minimal length of the name is 3 characters")]
        [MaxLength(20, ErrorMessage = "Maximum length of the name is 20 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The lastname is required")]
        [MinLength(3, ErrorMessage = "Minimal length of the lastname is 3 characters")]
        [MaxLength(20, ErrorMessage = "Maximum length of the lastname is 20 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The salary is required")]
        public int Salary { get; set; }
        [Required(ErrorMessage = "The position is required")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Login is required")]
        public string login { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }
        public int RowVersion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cleanings> Cleanings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedings> Feedings { get; set; }
    }
}
