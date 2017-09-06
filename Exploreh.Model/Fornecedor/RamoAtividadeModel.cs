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
    public class RamoAtividadeModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public Nullable<System.DateTime> DataAtualizacao { get; set; }
        public bool Ativo { get; set; }

        public virtual FornecedorModel Fornecedor { get; set; }

        public static implicit operator RamoAtividadeModel(Database.RamoAtividade ct)
        {
            return new RamoAtividadeModel
            {
                Id = ct.Id,
                Nome = ct.Nome,
                DataCadastro = ct.DataCadastro,
                DataAtualizacao = ct.DataAtualizacao,
                Ativo = ct.Ativo
            };
        }
        public static implicit operator RamoAtividade(RamoAtividadeModel ct)
        {
            return new RamoAtividade
            {
                Id = ct.Id,
                Nome = ct.Nome,
                DataCadastro = ct.DataCadastro,
                DataAtualizacao = ct.DataAtualizacao,
                Ativo = ct.Ativo
            };
        }
    }
}
