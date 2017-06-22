using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Database;

namespace Exploreh.Model.Cliente
{
     public class ClienteContatoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int ClienteId { get; set; }

        public System.DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual ClienteModel Cliente { get; set; }

        public static implicit operator ClienteContatoModel(Database.ClienteContato c)
        {
            return new ClienteContatoModel
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                DataCadastro = c.DataCadastro,
                DataAlteracao = c.DataAlteracao,
                Ativo = c.Ativo
            };
        }

        public static implicit operator ClienteContato(ClienteContatoModel c)
        {
            return new ClienteContato
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                DataCadastro = c.DataCadastro,
                DataAlteracao = c.DataAlteracao,
                Ativo = c.Ativo
            };
        }
    }
}
