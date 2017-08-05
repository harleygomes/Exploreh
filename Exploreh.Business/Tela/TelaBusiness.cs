using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Crypt;
using Exploreh.Model.Telas;
using Exploreh.Model.Usuario;
using Exploreh.Repository.Repository;

namespace Exploreh.Business.Tela
{
    public class TelaBusiness
    {
        private readonly GenericRepository<Database.Tela> _rep = new GenericRepository<Database.Tela>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TelaModel> Get()
        {
            return _rep.Get().ToList().ConvertAll<TelaModel>(x => x);
        }

        public List<TelaModel> FiltroClienteByName(string nome)
        {
            return _rep.Where(n => n.Nome.ToLower().Contains(nome.ToLower())).ToList().ConvertAll<TelaModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TelaModel Get(int id)
        {
            return _rep.Get(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(TelaModel model)
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
        public TelaModel AddToReturnEntity(TelaModel model)
        {
            #region Regras
            model.DataCadastro = DateTime.Now;
            model.Ativo = true;
            #endregion

            return _rep.AddToReturnEntity(model);
        }

        public TelaModel UpdateToReturnEntity(TelaModel model)
        {
            var update = Get(model.Id);

            update.Ativo = model.Ativo;
            update.DataAlteracao = DateTime.Now;

            return _rep.UpdateToReturnEntity(update);

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
        public bool Update(TelaModel model)
        {
            #region Regras
            var update = Get(model.Id);

            update.Nome = !string.IsNullOrEmpty(model.Nome) ? model.Nome : update.Nome;
            update.Ativo = model.Ativo;
            update.DataAlteracao = DateTime.Now;
            update.Descricao = model.Descricao;
            update.Url = model.Url;
            #endregion

            return _rep.Update(update);
        }
    }
}
