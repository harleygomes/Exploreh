using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Database;
using Exploreh.Model.Perfil;
using Exploreh.Model.PerfilTela;

namespace Exploreh.Model.Telas
{
    public class TelaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public virtual List<PerfilTelaModel> PerfilTelaModel { get; set; }
        public string Descricao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<PerfilModel> PerfilModel { get; set; }

        public static implicit operator TelaModel(Database.Tela telas)
        {
            if(telas == null) return new TelaModel();

            return new TelaModel
            {
                Id = telas.Id,
                Nome = telas.Nome,
                Ativo = telas.Ativo,
                DataCadastro = telas.DataCadastro,
                DataAlteracao = telas.DataAlteracao,
                Descricao = telas.Descricao,
                PerfilTelaModel = telas.PerfilTela?.ToList().ConvertAll<PerfilTelaModel>(x => x) 
            };
        }

        public static implicit operator Database.Tela(TelaModel telas)
        {
            if(telas == null) return new Tela();

            return new Database.Tela
            {
                Id = telas.Id,
                Nome = telas.Nome,
                Ativo = telas.Ativo,
                DataCadastro = telas.DataCadastro,
                DataAlteracao = telas.DataAlteracao,
                Descricao = telas.Descricao,
                PerfilTela = telas.PerfilTelaModel?.ToList().ConvertAll<Database.PerfilTela>(x => x)
            };
        }
    }
}
