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
    
    public partial class Potrebnost
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Potrebnost()
        {
            this.Potrebnost_apartment = new HashSet<Potrebnost_apartment>();
            this.Potrebnost_earth = new HashSet<Potrebnost_earth>();
            this.Potrebnost_house = new HashSet<Potrebnost_house>();
            this.Predlozheniye = new HashSet<Predlozheniye>();
        }
    
        public int ID { get; set; }
        public string Adres { get; set; }
        public Nullable<int> Min_price { get; set; }
        public Nullable<int> Max_price { get; set; }
        public Nullable<int> FK_Client { get; set; }
        public Nullable<int> Min_P { get; set; }
        public Nullable<int> Max_P { get; set; }
        public Nullable<int> Min_R { get; set; }
        public Nullable<int> Max_R { get; set; }
        public Nullable<int> Min_F { get; set; }
        public Nullable<int> Max_F { get; set; }
        public string Tip_object { get; set; }
    
        public virtual Client Client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Potrebnost_apartment> Potrebnost_apartment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Potrebnost_earth> Potrebnost_earth { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Potrebnost_house> Potrebnost_house { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Predlozheniye> Predlozheniye { get; set; }
    }
}
