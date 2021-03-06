﻿using System;
using System.Collections.Generic;
using System.Linq;
using Exploreh.Repository.Repository;
using Exploreh.Model.Fornecedor;
using Exploreh.Model.Perfil;

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

        public List<PerfilModel> FiltroClienteByName(string nome)
        {
            return _rep.Where(n => n.Nome.ToLower().Contains(nome.ToLower())).ToList().ConvertAll<PerfilModel>(x => x);
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
