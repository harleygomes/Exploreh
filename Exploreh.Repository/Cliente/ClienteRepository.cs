using System.Collections.Generic;
using Exploreh.Model.Cliente;
using Exploreh.Repository.Base;

namespace Exploreh.Repository.Cliente
{
    public class ClienteRepository : IBase.IBaseRepository<ClienteModel>
    {

        private BaseRepository<Database.Cliente> repository;

        public ClienteRepository()
        {
            this.repository = new BaseRepository<Database.Cliente>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ClienteModel> Get()
        {
            return this.repository.Get().ConvertAll<ClienteModel>(x => x);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClienteModel Get(int id)
        {
           return this.repository.Get(id);
         
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(ClienteModel model)
        {
            return this.repository.Update(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(ClienteModel model)
        {
            return this.repository.Add(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return this.repository.Delete(this.repository.Get(id));
        }
    }
}
