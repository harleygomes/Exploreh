using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Bairro;
using Exploreh.Repository.Repository;

namespace Exploreh.Business.Bairro
{
    public class BairroBusiness
    {
        private readonly GenericRepository<Database.TblBairro> _rep;

        public BairroBusiness()
        {
            this._rep = new GenericRepository<Database.TblBairro>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<BairroModel> Get()
        {
            return _rep.Get().ToList().ConvertAll<BairroModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BairroModel Get(int id)
        {
            return _rep.Get(id);
        }

        public List<BairroModel> GetBairro(int id)
        {
            return _rep.Get().Where(c => c.IdBairro == id).ToList().ConvertAll<BairroModel>(x => x);
        }
    }
}
