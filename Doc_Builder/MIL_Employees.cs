//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Doc_Builder
{
    using System;
    using System.Collections.Generic;
    
    public partial class MIL_Employees
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MIL_Employees()
        {
            this.Mil_ReadyDocuments = new HashSet<Mil_ReadyDocuments>();
        }
    
        public int ID { get; set; }
        public string FullName { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<decimal> Tel { get; set; }
        public string Profession { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mil_ReadyDocuments> Mil_ReadyDocuments { get; set; }
    }
}
