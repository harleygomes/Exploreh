using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Repository.Repository;
using Exploreh.Model.UnidadeFederacao;

namespace Exploreh.Business.Estado
{
    public class EstadoBusiness
    {
        private readonly GenericRepository<Database.TblUnidadeFederacao> _rep;


        public EstadoBusiness()
        {
            this._rep = new GenericRepository<Database.TblUnidadeFederacao>();
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

    }
}
