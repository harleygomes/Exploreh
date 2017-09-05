using System;
using System.Collections.Generic;
using System.Linq;
using Exploreh.Repository.Repository;
using Exploreh.Model.Fornecedor;
using Exploreh.Model.Banco;

namespace Exploreh.Business.Banco
{
    public class BancoBusiness 
    {
        private readonly GenericRepository<Database.Banco> _rep = new GenericRepository<Database.Banco>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<BancoModel> Get()
        {
            //return _rep.Get().Where(a => a.Ativo).ToList().ConvertAll<BancoModel>(x => x);
            return _rep.Get().ToList().ConvertAll<BancoModel>(x => x);
        }

        public List<BancoModel> FiltroClienteByName(string nome)
        {
            return _rep.Where(n => n.Nome.ToLower().Contains(nome.ToLower())).ToList().ConvertAll<BancoModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BancoModel Get(int id)
        {
            return _rep.Get(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(BancoModel model)
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
        public BancoModel AddToReturnEntity(BancoModel model)
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
        public bool Update(BancoModel model)
        {
            #region Regras

            var update = Get(model.Id);

            update.Nome = !string.IsNullOrEmpty(model.Nome)? model.Nome:update.Nome;
            update.Ativo = model.Ativo;
            update.DataAtualizacao = DateTime.Now;
            #endregion

            return _rep.Update(update);
        }

    }
}
