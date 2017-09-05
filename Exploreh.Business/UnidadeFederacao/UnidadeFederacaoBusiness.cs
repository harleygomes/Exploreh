using Exploreh.Business.Pais;
using Exploreh.Model.UnidadeFederacao;
using Exploreh.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exploreh.Business.UnidadeFederacao
{
    public class UnidadeFederacaoBusiness
    {
        private readonly GenericRepository<Database.TblUnidadeFederacao> _rep;
        private PaisBusiness _busPais;

        public UnidadeFederacaoBusiness()
        {
            this._rep = new GenericRepository<Database.TblUnidadeFederacao>();
            this._busPais = new PaisBusiness();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(UnidadeFederacaoModel model)
        {
            #region Regras
            model.DataReg = DateTime.Now;
            model.EstReg = model.DcrNome.Substring(0, 1);
            model.DcrSiglaPais = _busPais.Get(model.IdPais.Value).DcrSigla;
            #endregion

            return _rep.Add(model);
        }

        public bool Update(UnidadeFederacaoModel model)
        {
            var update = _rep.Get(model.IdUnidadeFederacao);

            #region Regras
            model.DataReg = DateTime.Now;
            model.EstReg = model.DcrNome.Substring(0, 1);
            model.DcrSiglaPais = _busPais.Get(model.IdPais.Value).DcrSigla;
            #endregion

            return _rep.Add(model);
        }
    }
}
