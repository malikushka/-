//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Интернет_магазин_Черешня
{
    using System;
    using System.Collections.Generic;
    
    public partial class Predlozheniye
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Predlozheniye()
        {
            this.Object = new HashSet<Object>();
            this.Potrebnost = new HashSet<Potrebnost>();
        }
    
        public int ID { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> FK_Realtor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Object> Object { get; set; }
        public virtual Realtor Realtor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Potrebnost> Potrebnost { get; set; }
    }
}
