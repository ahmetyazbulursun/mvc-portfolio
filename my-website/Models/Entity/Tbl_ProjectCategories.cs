//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace my_website.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_ProjectCategories
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_ProjectCategories()
        {
            this.Tbl_Projects = new HashSet<Tbl_Projects>();
        }
    
        public int ID { get; set; }
        public string CATEGORY { get; set; }
        public string NAME { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Projects> Tbl_Projects { get; set; }
    }
}
