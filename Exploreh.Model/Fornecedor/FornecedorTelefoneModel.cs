using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Database;
using Exploreh.Model.Cidade;

namespace Exploreh.Model.Fornecedor
{
    public class FornecedorTelefoneModel
    {
        public int Id { get; set; }
        public string Ddd { get; set; }
        public string DddEstrangeiro { get; set; }
        public string Telefone { get; set; }
        public string TelefoneEstrangeiro { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public int FornecedorId { get; set; }
        public string TipoTelefone { get; set; }
        public bool flgDelete { get; set; }

        public virtual FornecedorModel Fornecedor { get; set; }

        public static implicit operator FornecedorTelefoneModel(Database.FornecedorTelefone ct)
        {
            return new FornecedorTelefoneModel
            {
                Id = ct.Id,
                FornecedorId = ct.FornecedorId,
                Ddd = ct.Ddd,
                Telefone = ct.Telefone,
                DataCadastro = ct.DataCadastro,
                DataAlteracao = ct.DataAlteracao,
                Ativo = ct.Ativo
            };
        }
        public static implicit operator FornecedorTelefone(FornecedorTelefoneModel ct)
        {
            return new FornecedorTelefone
            {
                Id = ct.Id,
                FornecedorId = ct.FornecedorId,
                Ddd = ct.Ddd,
                Telefone = ct.Telefone,
                DataCadastro = ct.DataCadastro,
                DataAlteracao = ct.DataAlteracao,
                Ativo = ct.Ativo
            };
        }
    }
}
