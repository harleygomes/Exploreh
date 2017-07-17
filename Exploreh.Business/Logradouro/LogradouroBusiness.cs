using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Logradouro;
using Exploreh.Repository.Repository;

namespace Exploreh.Business.Logradouro
{
    public class LogradouroBusiness
    {
        private readonly GenericRepository<Database.TblLogradouro> _rep;

        public LogradouroBusiness()
        {
            this._rep = new GenericRepository<Database.TblLogradouro>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<LogradouroModel> Get()
        {
            return _rep.Get().ToList().ConvertAll<LogradouroModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LogradouroModel Get(int id)
        {
            return _rep.Get(id);
        }

        public List<LogradouroModel> GetLogradouro(int id)
        {
            return _rep.Get().Where(c => c.IdLogradouro == id).ToList().ConvertAll<LogradouroModel>(x => x);
        }

        public LogradouroModel GetCep(string cep)
        {
            return _rep.Where(i=>i.DcrCep == cep).AsQueryable().FirstOrDefault();
        }

    }
}
