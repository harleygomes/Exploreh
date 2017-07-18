using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Cliente;
using Exploreh.Model.Perfil;
using Exploreh.Repository.Repository;

namespace Exploreh.Business.Perfil
{
    public class PerfilBusiness 
    {
        private readonly GenericRepository<Database.Perfil> _rep = new GenericRepository<Database.Perfil>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PerfilModel> Get()
        {
            return _rep.Get().Where(a => a.Ativo).ToList().ConvertAll<PerfilModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PerfilModel Get(int id)
        {
            return _rep.Get(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(PerfilModel model)
        {
            #region Regras
            model.DataCadastro = DateTime.Now;
            model.Ativo = true;
            #endregion

            return _rep.Add(model);
        }

        /// <summary>
        /// Método para retornar o Id após cadastro
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PerfilModel AddToReturnEntity(PerfilModel model)
        {
            #region Regras
            model.DataCadastro = DateTime.Now;
            model.Ativo = true;
            #endregion

            return _rep.AddToReturnEntity(model);
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
        public bool Update(PerfilModel model)
        {
            #region Regras

            var update = Get(model.Id);

            update.Nome = !string.IsNullOrEmpty(model.Nome)? model.Nome:update.Nome;
            update.Ativo = model.Ativo;
            update.DataAlteracao = DateTime.Now;
            #endregion

            return _rep.Update(update);
        }

    }
}
