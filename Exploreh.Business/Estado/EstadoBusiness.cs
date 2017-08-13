using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Business.Pais;
using Exploreh.Repository.Repository;
using Exploreh.Model.UnidadeFederacao;

namespace Exploreh.Business.Estado
{
    public class EstadoBusiness
    {
        private readonly GenericRepository<Database.TblUnidadeFederacao> _rep;
        private readonly PaisBusiness _busPais;


        public EstadoBusiness()
        {
            this._rep = new GenericRepository<Database.TblUnidadeFederacao>();
            this._busPais = new PaisBusiness();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UnidadeFederacaoModel> Get()
        {
            return _rep.Get().ToList().ConvertAll<UnidadeFederacaoModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UnidadeFederacaoModel Get(int id)
        {
            return _rep.Get(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UnidadeFederacaoModel> GetByPais(int id)
        {
            var retorno = _rep.Get().Where(e => e.IdPais == id).ToList().ConvertAll<UnidadeFederacaoModel>(x => x);

            if (!retorno.Any())
                retorno = _rep.Get().Where(e => e.IdPaisEstrangeiro == id).ToList().ConvertAll<UnidadeFederacaoModel>(x => x);

            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(UnidadeFederacaoModel model)
        {
            model.DcrChaveUf = Convert.ToString(Get().Count() + 1);
            model.EstReg = "A";
            model.DataReg = DateTime.Now;
            model.DcrSigla = model.DcrSigla.ToUpper();
            
            /*
             * O tipo de FK autoincrement nos obriga a passar o IdPais num campo adicional
             * criado para esse propósito 
             */
            model.IdPaisEstrangeiro = model.IdPais;
            
            if (model.IdPais.HasValue)
                model.DcrSiglaPais = _busPais.Get(model.IdPais.Value).DcrSigla;
            
            return _rep.AddWithModifiedOrUnchanged(model);
        }
    }
}
