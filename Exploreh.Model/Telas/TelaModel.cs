using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Perfil;

namespace Exploreh.Model.Telas
{
    public class TelaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public virtual ICollection<PerfilModel> PerfilModel { get; set; }

        public string Descricao { get; set; }

        public static implicit operator TelaModel(Database.Tela telas)
        {
            return new TelaModel
            {
                Id = telas.Id,
                Nome = telas.Nome,
                Ativo = telas.Ativo,
                DataCadastro = telas.DataCadastro,
                DataAlteracao = telas.DataAlteracao,
                Descricao = telas.Descricao
            };
        }

        public static implicit operator Database.Tela(TelaModel telas)
        {
            return new Database.Tela
            {
                Id = telas.Id,
                Nome = telas.Nome,
                Ativo = telas.Ativo,
                DataCadastro = telas.DataCadastro,
                DataAlteracao = telas.DataAlteracao,
                Descricao = telas.Descricao
            };
        }
    }
}
