//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dbVinhosEFA
{
    using System;
    using System.Collections.Generic;
    [Serializable]
    public partial class Regiao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Regiao()
        {
            this.Vinhoes = new HashSet<Vinho>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Nullable<bool> Activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vinho> Vinhoes { get; set; }
    }
}
