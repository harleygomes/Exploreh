using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Database;
using Exploreh.Model.Cidade;

namespace Exploreh.Model.Fornecedor
{
    public class FornecedorEnderecoModel
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public bool Ativo { get; set; }
        public int IdCidade { get; set; }
        public int IdEstado { get; set; }
        public int IdPais { get; set; }

        public int FornecedorId { get; set; }
        public string CEP { get; set; }

        public virtual FornecedorModel Fornecedor { get; set; }
        public virtual CidadeModel Cidade { get; set; }
        

        public static implicit operator FornecedorEnderecoModel(Database.FornecedorEndereco ce)
        {
            return new FornecedorEnderecoModel
            {
                Id = ce.Id,
                FornecedorId = ce.FornecedorId,
                Logradouro = ce.Logradouro,
                Numero = ce.Numero,
                Bairro = ce.Bairro,
                Complemento = ce.Complemento,
                CEP = ce.CEP,
                IdCidade = ce.CidadeId,
                DataCadastro = ce.DataCadastro,
                DataAlteracao = ce.DataAlteracao,
                Ativo = ce.Ativo,
            };
        }

        public static implicit operator FornecedorEndereco(FornecedorEnderecoModel ce)
        {
            return new FornecedorEndereco
            {
                Id = ce.Id,
                FornecedorId = ce.FornecedorId,
                Logradouro = ce.Logradouro,
                Numero = ce.Numero,
                Bairro = ce.Bairro,
                Complemento = ce.Complemento,
                CEP = ce.CEP,
                CidadeId = ce.IdCidade,
                DataCadastro = ce.DataCadastro,
                DataAlteracao = ce.DataAlteracao,
                Ativo = ce.Ativo,
            };
        }
    }
}
