using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Database;
using Exploreh.Model.Cidade;

namespace Exploreh.Model.Cliente
{
    public class ClienteTelefoneModel
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Ops! O campo DDD é obrigatório")]
        public string Ddd { get; set; }
        //[Required(ErrorMessage = "Ops! O campo Telefone é obrigatório")]
        public string Telefone { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public int ClienteId { get; set; }
        public string TipoTelefone { get; set; }

        public virtual ClienteModel Cliente { get; set; }

        public static implicit operator ClienteTelefoneModel(Database.ClienteTelefone ct)
        {
            return new ClienteTelefoneModel
            {
                Id = ct.Id,
                ClienteId = ct.ClienteId,
                Ddd = ct.Ddd,
                Telefone = ct.Telefone,
                DataCadastro = ct.DataCadastro,
                DataAlteracao = ct.DataAlteracao,
                Ativo = ct.Ativo
            };
        }
        public static implicit operator ClienteTelefone(ClienteTelefoneModel ct)
        {
            return new ClienteTelefone
            {
                Id = ct.Id,
                ClienteId = ct.ClienteId,
                Ddd = ct.Ddd,
                Telefone = ct.Telefone,
                DataCadastro = ct.DataCadastro,
                DataAlteracao = ct.DataAlteracao,
                Ativo = ct.Ativo
            };
        }
    }
}
