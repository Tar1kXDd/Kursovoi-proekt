//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kursovoi_proekt
{
    using System;
    using System.Collections.Generic;
    
    public partial class Processor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Processor()
        {
            this.Noutbook = new HashSet<Noutbook>();
        }
    
        public int id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Jadra { get; set; }
        public Nullable<int> Potoki { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Noutbook> Noutbook { get; set; }
    }
}
