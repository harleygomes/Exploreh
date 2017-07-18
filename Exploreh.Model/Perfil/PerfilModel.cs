using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Usuario;

namespace Exploreh.Model.Perfil
{
    public class PerfilModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool IsChecked { get; set; }
        public virtual ICollection<UsuarioModel> UsuarioModel { get; set; }

        public static implicit operator PerfilModel(Database.Perfil perfil)
        {
            return new PerfilModel
            {
                Id = perfil.Id,
                Nome = perfil.Nome,
                Ativo = perfil.Ativo,
                DataCadastro = perfil.DataCadastro,
                DataAlteracao = perfil.DataAlteracao
            };
        }
        public static implicit operator Database.Perfil(PerfilModel perfil)
        {
            return new Database.Perfil
            {
                Id = perfil.Id,
                Nome = perfil.Nome,
                Ativo = perfil.Ativo,
                DataCadastro = perfil.DataCadastro,
                DataAlteracao = perfil.DataAlteracao
            };
        }
    }
}
