using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Cliente;
using Exploreh.Model.UnidadeFederacao;
using Exploreh.Model.Fornecedor;

namespace Exploreh.Model.Banco
{
    public class BancoModel
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Nome { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public Nullable<System.DateTime> DataAtualizacao { get; set; }
        public bool Ativo { get; set; }
        public virtual List<FornecedorDadosBancariosModel> FornecedorDadosBancarios { get; set; }

        public static implicit operator BancoModel(Database.Banco banco)
        {
            return new BancoModel
            {
                Id = banco.Id,
               Numero = banco.Numero,
               Nome = banco.Nome,
               DataCadastro = banco.DataCadastro,
               DataAtualizacao = banco.DataAtualizacao,
               Ativo = banco.Ativo
            };
        }

        public static implicit operator Database.Banco(BancoModel banco)
        {
            return new Database.Banco
            {

                Id = banco.Id,
                Numero = banco.Numero,
                Nome = banco.Nome,
                DataCadastro = banco.DataCadastro,
                DataAtualizacao = banco.DataAtualizacao,
                Ativo = banco.Ativo
            };
        }
    }
}
