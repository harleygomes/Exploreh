using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Database;
using Exploreh.Model.Banco;

namespace Exploreh.Model.Fornecedor
{
    public partial class FornecedorDadosBancariosModel
    {
        public int Id { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string Tipo { get; set; }
        public int BancoId { get; set; }
        public int FornecedorId { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual BancoModel Banco { get; set; }
        public virtual FornecedorModel Fornecedor { get; set; }

        public bool flgDelete { get; set; }


        public static implicit operator FornecedorDadosBancariosModel(Database.FornecedorDadosBancarios c)
        {
            return new FornecedorDadosBancariosModel
            {
                Id = c.Id,
                Agencia = c.Agencia,
                Conta = c.Conta,
                Tipo = c.Tipo,
                BancoId = c.BancoId,
                FornecedorId = c.FornecedorId,
                DataCadastro = c.DataCadastro,
                DataAlteracao = c.DataAlteracao,
                Ativo = c.Ativo
            };
        }

        public static implicit operator FornecedorDadosBancarios(FornecedorDadosBancariosModel c)
        {
            return new FornecedorDadosBancarios
            {
                Id = c.Id,
                Agencia = c.Agencia,
                Conta = c.Conta,
                Tipo = c.Tipo,
                BancoId = c.BancoId,
                FornecedorId = c.FornecedorId,
                DataCadastro = c.DataCadastro,
                DataAlteracao = c.DataAlteracao,
                Ativo = c.Ativo
            };
        }
    }
}
