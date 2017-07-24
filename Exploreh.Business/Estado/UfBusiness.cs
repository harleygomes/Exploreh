using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Uf;
using Exploreh.Model.UnidadeFederacao;
using Exploreh.Repository.Repository;

namespace Exploreh.Business.Estado
{
    public class UfBusiness
    {
        private readonly GenericRepository<Database.Estado> _rep;


        public UfBusiness()
        {
            this._rep = new GenericRepository<Database.Estado>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UfModel> Get()
        {
            return _rep.Get().ToList().ConvertAll<UfModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UfModel Get(int id)
        {
            return _rep.Get(id);
        }

        public bool Add(UfModel model)
        {
            return _rep.Add(model);
        }

    }
}
