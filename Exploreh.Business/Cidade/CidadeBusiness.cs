using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Cidade;
using Exploreh.Repository.Repository;

namespace Exploreh.Business.Cidade
{
    public class CidadeBusiness
    {
        private readonly GenericRepository<Database.Cidade> _rep;

        public CidadeBusiness()
        {
            this._rep = new GenericRepository<Database.Cidade>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CidadeModel> Get()
        {
            return _rep.Get().ToList().ConvertAll<CidadeModel>(x => x);
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
            return _rep.Get().Where(c => c.EstadoId == id).ToList().ConvertAll<CidadeModel>(x => x);
        }
    }
}
