using System;
using System.Collections.Generic;
using System.Linq;
using Exploreh.Repository.Repository;
using Exploreh.Model.Fornecedor;

namespace Exploreh.Business.RamoAtividade
{
    public class RamoAtividadeBusiness 
    {
        private readonly GenericRepository<Database.RamoAtividade> _rep = new GenericRepository<Database.RamoAtividade>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<RamoAtividadeModel> Get()
        {
            return _rep.Get().Where(a => a.Ativo).ToList().ConvertAll<RamoAtividadeModel>(x => x);
        }

        public List<RamoAtividadeModel> FiltroClienteByName(string nome)
        {
            return _rep.Where(n => n.Nome.ToLower().Contains(nome.ToLower())).ToList().ConvertAll<RamoAtividadeModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RamoAtividadeModel Get(int id)
        {
            return _rep.Get(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(RamoAtividadeModel model)
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
        public RamoAtividadeModel AddToReturnEntity(RamoAtividadeModel model)
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
        public bool Update(RamoAtividadeModel model)
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
