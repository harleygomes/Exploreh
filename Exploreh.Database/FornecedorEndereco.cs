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
    
    public partial class FornecedorEndereco
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public bool Ativo { get; set; }
        public int FornecedorId { get; set; }
        public int CidadeId { get; set; }
        public string CEP { get; set; }
    
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual TblCidade TblCidade { get; set; }
    }
}
