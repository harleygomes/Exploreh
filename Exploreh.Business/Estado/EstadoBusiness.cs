using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Estado;
using Exploreh.Repository.Repository;

namespace Exploreh.Business.Estado
{
    public class EstadoBusiness
    {
        private readonly GenericRepository<Database.Estado> _rep;


        public EstadoBusiness()
        {
            this._rep = new GenericRepository<Database.Estado>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<EstadoModel> Get()
        {
            return _rep.Get().ToList().ConvertAll<EstadoModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EstadoModel Get(int id)
        {
            return _rep.Get(id);
        }

    }
}
