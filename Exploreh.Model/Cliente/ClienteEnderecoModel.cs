using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Database;
using Exploreh.Model.Cidade;
using Exploreh.Model.Estado;

namespace Exploreh.Model.Cliente
{
    public class ClienteEnderecoModel
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public bool Ativo { get; set; }
        public int ClienteId { get; set; }
        public int CidadeId { get; set; }
        public int EstadoId { get; set; }

        public virtual ClienteModel Cliente { get; set; }
        public virtual CidadeModel Cidade { get; set; }
        public virtual EstadoModel Estado { get; set; }

        public static implicit operator ClienteEnderecoModel(Database.ClienteEndereco ce)
        {
            return new ClienteEnderecoModel
            {
                Id = ce.Id,
                ClienteId = ce.ClienteId,
                Logradouro = ce.Logradouro,
                Numero = ce.Numero,
                Bairro = ce.Bairro,
                Complemento = ce.Complemento,
                CEP = ce.CEP,
                CidadeId = ce.EstadoId,
                EstadoId = ce.EstadoId,
                DataCadastro = ce.DataCadastro,
                DataAlteracao = ce.DataAlteracao,
                Ativo = ce.Ativo,
            };
        }

        public static implicit operator ClienteEndereco(ClienteEnderecoModel ce)
        {
            return new ClienteEndereco
            {
                Id = ce.Id,
                ClienteId = ce.ClienteId,
                Logradouro = ce.Logradouro,
                Numero = ce.Numero,
                Bairro = ce.Bairro,
                Complemento = ce.Complemento,
                CEP = ce.CEP,
                CidadeId = ce.EstadoId,
                EstadoId = ce.EstadoId,
                DataCadastro = ce.DataCadastro,
                DataAlteracao = ce.DataAlteracao,
                Ativo = ce.Ativo,
            };
        }
    }
}
