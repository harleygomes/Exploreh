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
    
    public partial class ClienteContato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int ClienteId { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public bool Ativo { get; set; }
    
        public virtual Cliente Cliente { get; set; }
    }
}
