﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Business.Estado;
using Exploreh.Business.Pais;
using Exploreh.Model.Cidade;
using Exploreh.Repository.Repository;

namespace Exploreh.Business.Cidade
{
    public class CidadeBusiness
    {
        private readonly GenericRepository<Database.TblCidade> _rep;
        private readonly PaisBusiness _busPais;
        private readonly EstadoBusiness _busEstado;

        public CidadeBusiness()
        {
            this._rep = new GenericRepository<Database.TblCidade>();
            this._busPais = new PaisBusiness();
            this._busEstado = new EstadoBusiness();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CidadeModel> Get()
        {
            return _rep.Get().Where(n=>n.EstReg.Contains("A")).ToList().ConvertAll<CidadeModel>(x => x);
        }

        /// <summary>
        /// Recupera cidade pelo nome
        /// </summary>
        /// <param name="nome">string</param>
        /// <returns>Um ou muitos registros </returns>
        public List<CidadeModel> FiltroCidadeByEstado(int estado)
        {
            return _rep.Where(n => n.IdUnidadeFederacao == estado && n.EstReg.Contains("A")).ToList().ConvertAll<CidadeModel>(x => x);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public List<CidadeModel> FiltroCidadeByCidadeNome(int estado, string nome)
        {
            return _rep.Where(n => n.DcrNome.ToLower().Contains(nome.ToLower()) && n.IdUnidadeFederacao == estado && n.EstReg.Contains("A")).ToList().ConvertAll<CidadeModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CidadeModel Get(int id)
        {
            return _rep.Get(id);
        }

        public List<CidadeModel> GetCidade(int id)
        {
            return _rep.Get().Where(c => c.IdUnidadeFederacao == id && c.EstReg.Contains("A")).ToList().ConvertAll<CidadeModel>(x => x);
        }

        public bool Add(CidadeModel model)
        {
            model.DcrSiglaPais = _busEstado.Get(model.IdUnidadeFederacao.Value).DcrSiglaPais;
            model.DcrChaveLocalidade = Convert.ToString(Get().Count() + 1);
            model.AbrevNome = model.DcrNome;
            model.TipLocalidade = "M";
            model.SituacaoLocalidade = "N";
            model.DcrSiglaUf = _busEstado.Get(model.IdUnidadeFederacao.Value).DcrSigla;
            model.EstReg = "A";
            model.DataReg = DateTime.Now;

            return _rep.Add(model);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(CidadeModel model)
        {
            var update = Get(model.IdCidade);

            update.DcrNome = model.DcrNome;
            update.IdUnidadeFederacao = model.IdUnidadeFederacao;            

            return _rep.Update(update);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(CidadeModel model)
        {
            var update = Get(model.IdCidade);

            update.EstReg = "N";

            return _rep.Update(update);
        }
    }
}
