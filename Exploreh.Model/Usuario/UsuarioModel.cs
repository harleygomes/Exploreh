using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Perfil;

namespace Exploreh.Model.Usuario
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public string Senha { get; set; }
        public int PerfilId { get; set; }
        public virtual PerfilModel PerfilModel { get; set; }

        #region Atendendo aos Dropdowns apresentados nas telas 
        public List<PerfilModel> ddlPerfil { get; set; }
        #endregion

        public static implicit operator UsuarioModel(Database.Usuario usuario)
        {
            return new UsuarioModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Ativo = usuario.Ativo,
                DataCadastro = usuario.DataCadastro,
                DataAlteracao = usuario.DataAlteracao,
                Senha = usuario.Senha,
                PerfilId = usuario.PerfilId

            };
        }

        public static implicit operator Database.Usuario(UsuarioModel usuario)
        {
            return new Database.Usuario
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Ativo = usuario.Ativo,
                DataCadastro = usuario.DataCadastro,
                DataAlteracao = usuario.DataAlteracao,
                Senha = usuario.Senha,
                PerfilId = usuario.PerfilId
            };
        }
    }
}
