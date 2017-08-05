using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Crypt;
using Exploreh.Model.Perfil;
using Exploreh.Model.Usuario;
using Exploreh.Repository.Repository;

namespace Exploreh.Business.Usuario
{
    public class UsuarioBusiness
    {
        private readonly GenericRepository<Database.Usuario> _rep = new GenericRepository<Database.Usuario>();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UsuarioModel> Get()
        {
            return _rep.Get().ToList().ConvertAll<UsuarioModel>(x => x);
        }

        /// <summary>
        /// Capturar usuario pelo nome
        /// </summary>
        /// <param name="nome">Nome do usuario</param>
        /// <returns></returns>
        public List<UsuarioModel> FiltroClienteByName(string nome)
        {
            return _rep.Where(n => n.Nome.ToLower().Contains(nome.ToLower())).ToList().ConvertAll<UsuarioModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UsuarioModel Get(int id)
        {
            return _rep.Get(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(UsuarioModel model)
        {
            #region Regras
            model.DataCadastro = DateTime.Now;
            model.Ativo = true;
            model.Senha = Crypt.Base64Encode(model.Senha);
            #endregion

            return _rep.Add(model);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _rep.Delete(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(UsuarioModel model)
        {
            #region Regras
            var update = Get(model.Id);

            update.Nome = !string.IsNullOrEmpty(model.Nome)?model.Nome:update.Nome;
            update.Email = !string.IsNullOrEmpty(model.Email) ? model.Email : update.Email;
            update.Ativo = model.Ativo;
            update.PerfilId = model.PerfilId;
            update.DataAlteracao = DateTime.Now;
            if (!string.IsNullOrEmpty(model.Senha))
                update.Senha = Crypt.Base64Encode(model.Senha);
            #endregion

            return _rep.Update(update);
        }
    }
}
