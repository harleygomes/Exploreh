//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Exploreh.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblUnidadeFederacao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblUnidadeFederacao()
        {
            this.TblCidade = new HashSet<TblCidade>();
        }
    
        public int IdUnidadeFederacao { get; set; }
        public Nullable<int> IdPais { get; set; }
        public string DcrSiglaPais { get; set; }
        public string DcrSigla { get; set; }
        public string DcrChaveUf { get; set; }
        public string DcrNome { get; set; }
        public string AbrevNome { get; set; }
        public Nullable<System.DateTime> DataReg { get; set; }
        public string EstReg { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblCidade> TblCidade { get; set; }
        public virtual TblPais TblPais { get; set; }
    }
}
