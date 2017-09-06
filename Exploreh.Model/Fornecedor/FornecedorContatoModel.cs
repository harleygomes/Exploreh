using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Database;

namespace Exploreh.Model.Fornecedor
{
     public class FornecedorContatoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int FornecedorId { get; set; }

        public System.DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool Ativo { get; set; }
        public bool flgDelete { get; set; }
        public string Skype { get; set; }

        public virtual FornecedorModel Fornecedor { get; set; }

        public static implicit operator FornecedorContatoModel(Database.FornecedorContato c)
        {
            return new FornecedorContatoModel
            {
                Id = c.Id,
                FornecedorId = c.FornecedorId,
                Nome = c.Nome,
                Email = c.Email,
                Skype = c.Skype,
                DataCadastro = c.DataCadastro,
                DataAlteracao = c.DataAlteracao,
                Ativo = c.Ativo
            };
        }

        public static implicit operator FornecedorContato(FornecedorContatoModel c)
        {
            return new FornecedorContato
            {
                Id = c.Id,
                FornecedorId = c.FornecedorId,
                Nome = c.Nome,
                Email = c.Email,
                Skype = c.Skype,
                DataCadastro = c.DataCadastro,
                DataAlteracao = c.DataAlteracao?? DateTime.Now,
                Ativo = c.Ativo
            };
        }
    }
}
