using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Pais;
using Exploreh.Repository.Repository;

namespace Exploreh.Business.Pais
{
    public class PaisBusiness
    {
        private readonly GenericRepository<Database.TblPais> _rep;

        public PaisBusiness()
        {
            this._rep = new GenericRepository<Database.TblPais>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PaisModel> Get()
        {
            return _rep.Get().ToList().ConvertAll<PaisModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PaisModel Get(int id)
        {
            return _rep.Get(id);
        }

        public List<PaisModel> GetPais(int id)
        {
            return _rep.Get().Where(c => c.IdPais == id).ToList().ConvertAll<PaisModel>(x => x);
        }
    }
}
