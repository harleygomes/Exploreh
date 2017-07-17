using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Cliente;
using Exploreh.Repository.Repository;

namespace Exploreh.Business.ClienteContato
{
    public class ClienteContatoBusiness
    {
        private readonly GenericRepository<Database.ClienteContato> _rep;


        public ClienteContatoBusiness()
        {
            this._rep = new GenericRepository<Database.ClienteContato>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ClienteContatoModel> Get()
        {
            return _rep.Get().ToList().ConvertAll<ClienteContatoModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClienteContatoModel Get(int id)
        {
            return _rep.Get(id);
        }

    }
}
